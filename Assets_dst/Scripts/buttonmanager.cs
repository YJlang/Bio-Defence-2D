using UnityEngine;
using UnityEngine.SceneManagement; // �� ���� �߰��Ͽ� SceneManager�� �����մϴ�

public class ButtonManager : MonoBehaviour
{
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    // ��ư�� Ŭ���� �� �� �޼��带 ȣ���ϰ� �� ���� �ֽ��ϴ�
    public void OnButtonClick()
    {
        // ���⿡ �ε��Ϸ��� ���� �̸��� �Է��մϴ�
        SceneManager.LoadScene("Map");
    }
}
