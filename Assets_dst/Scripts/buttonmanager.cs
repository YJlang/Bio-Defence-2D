using UnityEngine;
using UnityEngine.SceneManagement; // 이 줄을 추가하여 SceneManager를 포함합니다

public class ButtonManager : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // 버튼을 클릭할 때 이 메서드를 호출하게 할 수도 있습니다
    public void OnButtonClick()
    {
        // 여기에 로드하려는 씬의 이름을 입력합니다
        SceneManager.LoadScene("Map");
    }
}
