using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class HelpScene : MonoBehaviour
{
    public Button transitionButton;
    public string mainSceneName = "HelpScene";

    private void Start()
    {
        // 버튼에 리스너 추가
        if (transitionButton != null)
        {
            transitionButton.onClick.AddListener(TransitionToMainScene);
        }
        else
        {
            Debug.LogError("Transition button is not assigned in the inspector!");
        }
    }

    private void TransitionToMainScene()
    {
        Debug.Log("Transitioning to main scene...");
        SceneManager.LoadScene(mainSceneName);
    }

    // 씬 이름을 코드에서 동적으로 설정하고 싶을 때 사용할 수 있는 메서드
    public void SetMainSceneName(string sceneName)
    {
        mainSceneName = sceneName;
    }

    private void OnDestroy()
    {
        // 리스너 제거 (메모리 누수 방지)
        if (transitionButton != null)
        {
            transitionButton.onClick.RemoveListener(TransitionToMainScene);
        }
    }
}