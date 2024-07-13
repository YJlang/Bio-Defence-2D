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
        // 현재 활성화된 UI가 있고, 그것이 클릭된 것과 다르다면 비활성화
        if (currentActiveRecipeUI != null && currentActiveRecipeUI != recipeUI)
        {
            currentActiveRecipeUI.SetActive(false);
        }

        // 클릭된 UI가 null이 아니라면 (할당된 레시피가 있다면) 토글
        if (recipeUI != null)
        {
            bool newState = !recipeUI.activeSelf;
            recipeUI.SetActive(newState);
            currentActiveRecipeUI = newState ? recipeUI : null;
        }
        else
        {
            // 클릭된 UI가 null이라면 (할당된 레시피가 없다면) 모든 UI를 비활성화
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