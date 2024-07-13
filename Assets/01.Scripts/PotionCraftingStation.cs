using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class PotionCraftingStation : MonoBehaviour
{
    public Transform[] ingredientSlots;
    public float snapThreshold = 0.5f;

    private Dictionary<Transform, GameObject> slotContents = new Dictionary<Transform, GameObject>();
    private GameObject draggedIngredient;
    public GameObject coronaAIUI;
    public GameObject potionUI;
    public GameObject craftUI;

    private void Start()
    {
        foreach (Transform slot in ingredientSlots)
        {
            slotContents[slot] = null;
        }
        potionUI.SetActive(true);
        craftUI.SetActive(true);
    }

    private void Update()
    {
        HandleDragAndDrop();
        CheckForPotionCrafting();
    }

    private void HandleDragAndDrop()
    {
        if (Input.GetMouseButtonDown(0))
        {
            draggedIngredient = GetClickedIngredient();
        }
        else if (Input.GetMouseButton(0) && draggedIngredient != null)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            draggedIngredient.transform.position = mousePosition;
        }
        else if (Input.GetMouseButtonUp(0) && draggedIngredient != null)
        {
            SnapToNearestSlot(draggedIngredient);
            draggedIngredient = null;
        }
    }

    private GameObject GetClickedIngredient()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePosition, Vector2.zero);

        if (hit.collider != null && hit.collider.CompareTag("Ingredient"))
        {
            return hit.collider.gameObject;
        }
        return null;
    }

    private void SnapToNearestSlot(GameObject ingredient)
    {
        Transform nearestEmptySlot = null;
        float nearestDistance = float.MaxValue;

        foreach (Transform slot in ingredientSlots)
        {
            if (slotContents[slot] == null)
            {
                float distance = Vector2.Distance(ingredient.transform.position, slot.position);
                if (distance < nearestDistance && distance < snapThreshold)
                {
                    nearestEmptySlot = slot;
                    nearestDistance = distance;
                }
            }
        }

        if (nearestEmptySlot != null)
        {
            foreach (var slot in slotContents.Keys.ToList())
            {
                if (slotContents[slot] == ingredient)
                {
                    slotContents[slot] = null;
                }
            }

            ingredient.transform.position = nearestEmptySlot.position;
            slotContents[nearestEmptySlot] = ingredient;
            Debug.Log($"Ingredient {ingredient.name} snapped to slot {nearestEmptySlot.name}");
        }
        else
        {
            Debug.Log($"No empty slot available for {ingredient.name}");
        }
    }

    private void CheckForPotionCrafting()
    {
        if (AreAllSlotsFilled())
        {
            CraftPotion();
        }
    }

    private bool AreAllSlotsFilled()
    {
        return slotContents.Values.All(ingredient => ingredient != null);
    }

    private void CraftPotion()
    {
        Debug.Log("Crafting potion...");
        List<string> ingredientNames = new List<string>();

        foreach (var ingredient in slotContents.Values)
        {
            ingredientNames.Add(ingredient.name);
            Destroy(ingredient);
        }

        string potionName = string.Join(" ", ingredientNames.Distinct());
        Debug.Log($"Created: {potionName} Potion");

        foreach (Transform slot in ingredientSlots)
        {
            slotContents[slot] = null;
        }

        if (coronaAIUI != null)
        {
            coronaAIUI.SetActive(true);
            potionUI.SetActive(false);
            craftUI.SetActive(false);
        }
    }

    private void DebugSlotContents()
    {
        string status = "Slot contents: ";
        foreach (var slot in slotContents)
        {
            status += $"{slot.Key.name}: {(slot.Value != null ? slot.Value.name : "empty")}, ";
        }
        Debug.Log(status);
    }
}