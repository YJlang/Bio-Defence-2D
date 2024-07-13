using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GptRule : MonoBehaviour
{
    public TMP_InputField userInputField;
    public Button sendButton;
    public TextMeshProUGUI responseText;

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
    }

    void SendUserInput()
    {
        string userInput = userInputField.text;
        if (!string.IsNullOrEmpty(userInput))
        {
            responseText.text = "Sending request...";
            sendButton.interactable = false;
            StartCoroutine(gptController.GetGPTResponse(userInput));
            userInputField.text = "";
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
    }

    void OnDestroy()
    {
        if (gptController != null)
        {
            gptController.OnResponseReceived -= UpdateResponseText;
        }
    }
}