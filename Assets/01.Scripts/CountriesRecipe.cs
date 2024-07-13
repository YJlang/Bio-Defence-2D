using UnityEngine;
using UnityEngine.UI;

public class CountriesRecipe : MonoBehaviour
{
    public GameObject recipeUIElement;
    public Button[] countryButtons;

    private RecipeUIManager recipeUIManager;

    void Start()
    {
        recipeUIManager = FindObjectOfType<RecipeUIManager>();
        if (recipeUIManager == null)
        {
            Debug.LogError("RecipeUIManager�� ã�� �� �����ϴ�!");
            return;
        }

        for (int i = 0; i < countryButtons.Length; i++)
        {
            int index = i;
            if (countryButtons[i] != null)
            {
                countryButtons[i].onClick.RemoveAllListeners();
                countryButtons[i].onClick.AddListener(() => ToggleRecipeUI(index));
            }
            else
            {
                Debug.LogError($"���� ��ư {i}�� null�Դϴ�!");
            }
        }

        if (recipeUIElement != null)
        {
            recipeUIManager.RegisterRecipeUI(recipeUIElement);
        }
    }

    void ToggleRecipeUI(int index)
    {
        recipeUIManager.ToggleRecipeUI(recipeUIElement);
    }
}