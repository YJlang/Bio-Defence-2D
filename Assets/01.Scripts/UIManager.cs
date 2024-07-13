using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TMP_InputField userInputField;
    public Button sendButton;
    public TextMeshProUGUI responseText;
    public Image imageUI;
    public Button backButton;    // 돌아가기 버튼
    public Button treatButton;   // 치료하기 버튼
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

        // 초기 상태 설정
        if (imageUI != null) imageUI.gameObject.SetActive(false);
        if (backButton != null) backButton.interactable = true;
        if (treatButton != null)
        {
            treatButton.interactable = false;
            treatButton.gameObject.SetActive(false);  // 초기에는 치료하기 버튼을 숨김
        }
    }

    void SendUserInput()
    {
        string userInput = userInputField.text;
        if (!string.IsNullOrEmpty(userInput))
        {
            if (userInput.Trim().Equals("코로나", System.StringComparison.OrdinalIgnoreCase))
            {
                responseText.text = "백신 제조하는 중...";
                sendButton.interactable = false;
                userInputField.interactable = false;

                if (imageUI != null) imageUI.gameObject.SetActive(true);
                if (backButton != null) backButton.interactable = false;
                if (treatButton != null)
                {
                    treatButton.interactable = true;
                    treatButton.gameObject.SetActive(true);  // 치료하기 버튼 표시
                }

                StartCoroutine(gptController.GetGPTResponse(userInput));
                userInputField.text = "";
            }
            else
            {
                responseText.text = "백신 제조 실패했습니다.";
                if (imageUI != null) imageUI.gameObject.SetActive(true);
                // 실패 시에도 버튼 상태 유지
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
        // GPT 응답 후에도 버튼 상태 유지
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