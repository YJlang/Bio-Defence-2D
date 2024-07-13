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
            Debug.LogError("RecipeUIManager를 찾을 수 없습니다!");
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
                Debug.LogError($"국가 버튼 {i}가 null입니다!");
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