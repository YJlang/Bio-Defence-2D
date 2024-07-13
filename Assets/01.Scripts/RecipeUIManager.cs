using UnityEngine;
using System.Collections.Generic;

public class RecipeUIManager : MonoBehaviour
{
    private List<GameObject> allRecipeUIs = new List<GameObject>();
    private GameObject currentActiveRecipeUI;

    public void RegisterRecipeUI(GameObject recipeUI)
    {
        if (!allRecipeUIs.Contains(recipeUI))
        {
            allRecipeUIs.Add(recipeUI);
            recipeUI.SetActive(false);
        }
    }

    public void ToggleRecipeUI(GameObject recipeUI)
    {
        // ���� Ȱ��ȭ�� UI�� �ְ�, �װ��� Ŭ���� �Ͱ� �ٸ��ٸ� ��Ȱ��ȭ
        if (currentActiveRecipeUI != null && currentActiveRecipeUI != recipeUI)
        {
            currentActiveRecipeUI.SetActive(false);
        }

        // Ŭ���� UI�� null�� �ƴ϶�� (�Ҵ�� �����ǰ� �ִٸ�) ���
        if (recipeUI != null)
        {
            bool newState = !recipeUI.activeSelf;
            recipeUI.SetActive(newState);
            currentActiveRecipeUI = newState ? recipeUI : null;
        }
        else
        {
            // Ŭ���� UI�� null�̶�� (�Ҵ�� �����ǰ� ���ٸ�) ��� UI�� ��Ȱ��ȭ
            HideAllRecipeUIs();
        }
    }

    private void HideAllRecipeUIs()
    {
        foreach (var ui in allRecipeUIs)
        {
            ui.SetActive(false);
        }
        currentActiveRecipeUI = null;
    }
}