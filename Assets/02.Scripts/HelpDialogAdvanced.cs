using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpDialogAdvanced : MonoBehaviour
{
    [Header("UI References")]
    public GameObject helpPanel;
    public TextMeshProUGUI helpText;
    public Button helpButton;
    public ScrollRect scrollRect;

    [Header("Help Content")]
    public TextAsset helpContentFile;

    [Header("UI Settings")]
    public float panelWidthPercent = 0.83f;
    public float panelHeightPercent = 0.83f;
    public float panelMargin = 20f;

    private RectTransform panelRectTransform;
    private CanvasScaler canvasScaler;

    private void Awake()
    {
        panelRectTransform = helpPanel.GetComponent<RectTransform>();
        FindCanvasScaler();
    }

    private void Start()
    {
        helpPanel.SetActive(false);
        helpButton.onClick.AddListener(ToggleHelpPanel);

        LoadHelpContent();
        SetupUI();
    }

    private void FindCanvasScaler()
    {
        canvasScaler = GetComponentInParent<CanvasScaler>();
        if (canvasScaler == null)
        {
            Canvas canvas = GetComponentInParent<Canvas>();
            if (canvas != null)
            {
                canvasScaler = canvas.GetComponent<CanvasScaler>();
            }
        }

        if (canvasScaler == null)
        {
            Debug.LogWarning("CanvasScaler not found. UI scaling might not work as expected.");
        }
    }

    private void LoadHelpContent()
    {
        if (helpContentFile != null)
        {
            helpText.text = helpContentFile.text;
        }
        else
        {
            Debug.LogError("Help content file is not assigned!");
            helpText.text = "Error: Help content not available.";
        }
    }

    private void SetupUI()
    {
        if (canvasScaler != null)
        {
            float referenceWidth = canvasScaler.referenceResolution.x;
            float referenceHeight = canvasScaler.referenceResolution.y;

            float panelWidth = referenceWidth * panelWidthPercent;
            float panelHeight = referenceHeight * panelHeightPercent;
            panelRectTransform.sizeDelta = new Vector2(panelWidth, panelHeight);

            panelRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            panelRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            panelRectTransform.anchoredPosition = Vector2.zero;

            SetupScrollRect(panelWidth, panelHeight);
        }
        else
        {
            Debug.LogWarning("CanvasScaler not found. Using default resolution for UI setup.");
            SetupScrollRect(1600, 900);  // 기본 크기 사용
        }
    }

    private void SetupScrollRect(float width, float height)
    {
        RectTransform scrollRectTransform = scrollRect.GetComponent<RectTransform>();
        scrollRectTransform.anchorMin = new Vector2(0, 0);
        scrollRectTransform.anchorMax = new Vector2(1, 1);
        scrollRectTransform.sizeDelta = new Vector2(-panelMargin * 2, -panelMargin * 2);
        scrollRectTransform.anchoredPosition = Vector2.zero;

        RectTransform contentRectTransform = scrollRect.content;
        contentRectTransform.anchorMin = new Vector2(0, 1);
        contentRectTransform.anchorMax = new Vector2(1, 1);
        contentRectTransform.sizeDelta = new Vector2(0, 0);
        contentRectTransform.anchoredPosition = Vector2.zero;

        LayoutRebuilder.ForceRebuildLayoutImmediate(contentRectTransform);

        helpText.rectTransform.anchorMin = new Vector2(0, 1);
        helpText.rectTransform.anchorMax = new Vector2(1, 1);
        helpText.rectTransform.sizeDelta = new Vector2(-panelMargin * 2, 0);
        helpText.rectTransform.anchoredPosition = new Vector2(0, -panelMargin);

        // 텍스트 내용이 변경된 후 Content의 높이를 조정
        Canvas.ForceUpdateCanvases();
        float textHeight = LayoutUtility.GetPreferredHeight(helpText.rectTransform);
        contentRectTransform.sizeDelta = new Vector2(0, textHeight + panelMargin * 2);
    }

    private void ToggleHelpPanel()
    {
        helpPanel.SetActive(!helpPanel.activeSelf);
        if (helpPanel.activeSelf)
        {
            scrollRect.normalizedPosition = new Vector2(0, 1);
            Canvas.ForceUpdateCanvases();
            LayoutRebuilder.ForceRebuildLayoutImmediate(scrollRect.content);
        }
    }
}