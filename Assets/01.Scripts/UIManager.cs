using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_InputField userInputField;
    public Button sendButton;
    public TextMeshProUGUI responseText;
    public Image imageUI;
    public Button backButton;    // ���ư��� ��ư
    public Button treatButton;   // ġ���ϱ� ��ư
    private GPTAPIController gptController;

    void Start()
    {
        gptController = GetComponent<GPTAPIController>();
        if (gptController == null)
        {
            Debug.LogError("GPTAPIController not found!");
            return;
        }
        gptController.OnResponseReceived += UpdateResponseText;
        sendButton.onClick.AddListener(SendUserInput);

        // �ʱ� ���� ����
        if (imageUI != null) imageUI.gameObject.SetActive(false);
        if (backButton != null) backButton.interactable = true;
        if (treatButton != null)
        {
            treatButton.interactable = false;
            treatButton.gameObject.SetActive(false);  // �ʱ⿡�� ġ���ϱ� ��ư�� ����
        }
    }

    void SendUserInput()
    {
        string userInput = userInputField.text;
        if (!string.IsNullOrEmpty(userInput))
        {
            if (userInput.Trim().Equals("�ڷγ�", System.StringComparison.OrdinalIgnoreCase))
            {
                responseText.text = "��� �����ϴ� ��...";
                sendButton.interactable = false;
                userInputField.interactable = false;

                if (imageUI != null) imageUI.gameObject.SetActive(true);
                if (backButton != null) backButton.interactable = false;
                if (treatButton != null)
                {
                    treatButton.interactable = true;
                    treatButton.gameObject.SetActive(true);  // ġ���ϱ� ��ư ǥ��
                }

                StartCoroutine(gptController.GetGPTResponse(userInput));
                userInputField.text = "";
            }
            else
            {
                responseText.text = "��� ���� �����߽��ϴ�.";
                if (imageUI != null) imageUI.gameObject.SetActive(true);
                // ���� �ÿ��� ��ư ���� ����
                if (backButton != null) backButton.interactable = true;
                if (treatButton != null)
                {
                    treatButton.interactable = false;
                    treatButton.gameObject.SetActive(false);
                }
            }
        }
        else
        {
            responseText.text = "Please enter a message.";
        }
    }

    void UpdateResponseText(string response)
    {
        responseText.text = response;
        sendButton.interactable = true;
        userInputField.interactable = true;
        // GPT ���� �Ŀ��� ��ư ���� ����
        if (backButton != null) backButton.interactable = false;
        if (treatButton != null) treatButton.interactable = true;
    }

    void OnDestroy()
    {
        if (gptController != null)
        {
            gptController.OnResponseReceived -= UpdateResponseText;
        }
    }
}