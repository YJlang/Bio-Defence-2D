using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class RandomImageColor : MonoBehaviour
{
    public Transform parentTransform;
    private int TimeCnt = 0;
    public int ReaptingTime = 50;
    public int ReaptingStartTime = 1;
    private List<Image> images = new List<Image>();
    private Dictionary<string, Color> changedImages = new Dictionary<string, Color>();

    public Slider progressSlider;
    public Text percentageText;

    // 팝업 관련 변수
    public GameObject popupPanel;
    public GameObject popupPanel2;
    public Text popupText;
    public Text popupText2;
    private Coroutine popupCoroutine;

    void Start()
    {
        InitializeImages();
        LoadState();
        StartColorChange();
        UpdateProgressGauge();

    }

    void InitializeImages()
    {
        if (parentTransform != null)
        {
            foreach (Transform child in parentTransform)
            {
                Image img = child.GetComponent<Image>();
                if (img != null)
                {
                    images.Add(img);
                }
            }
        }
    }

    void StartColorChange()
    {
        CancelInvoke("ChangeRandomImageColor");
        InvokeRepeating("ChangeRandomImageColor", ReaptingStartTime, ReaptingTime);
    }

    void ChangeRandomImageColor()
    {
        if (images != null && images.Count > 0)
        {
            TimeCnt++;
            int randomIndex = Random.Range(0, images.Count);
            Image selectedImage = images[randomIndex];
            string imageName = selectedImage.name;
            if (!changedImages.ContainsKey(imageName))
            {
                changedImages[imageName] = Color.red;
                selectedImage.color = Color.red;
                Debug.Log("바이러스 번짐 체크 " + randomIndex);
                SaveState();
                UpdateProgressGauge();
                ShowPopup($"{imageName} 지역이 감염되었습니다!");
                 // 팝업 표시
            }
        }
    }

    void UpdateProgressGauge()
    {
        if (progressSlider != null)
        {
            float progress = (float)changedImages.Count / images.Count;
            progressSlider.value = progress;

            if (percentageText != null)
            {
                percentageText.text = $"{progress * 100:F1}%";
            }
        }
    }

    // 팝업 표시 메서드
    void ShowPopup(string message)
    {
        if (popupPanel != null && popupText != null)
        {
            // 이전 팝업 코루틴이 실행 중이라면 중지
            if (popupCoroutine != null)
            {
                StopCoroutine(popupCoroutine);
            }

            popupText.text = message;
            popupPanel.SetActive(true);

            // 새로운 팝업 코루틴 시작
            popupCoroutine = StartCoroutine(ClosePopupAfterDelay());
        }
    }
    public void ShowPopup2(string message)
    {
        if (popupPanel2 != null && popupText != null)
        {

            popupText2.text = message;
            popupPanel2.SetActive(true);

        }
    }

    // 1초 후 팝업을 닫는 코루틴
    IEnumerator ClosePopupAfterDelay()
    {
        yield return new WaitForSeconds(1f);
        ClosePopup();
    }

    // 팝업 닫기 메서드
    void ClosePopup()
    {
        if (popupPanel != null)
        {
            popupPanel.SetActive(false);
        }
    }

    public void OnButtonClick()
    {
        ChangeRandomImageColor();
    }

    public void SaveState()
    {
        PlayerPrefs.SetInt("TimeCnt", TimeCnt);
        PlayerPrefs.SetString("ChangedImages", string.Join(";", changedImages.Select(kvp => $"{kvp.Key}:{ColorToString(kvp.Value)}")));
        PlayerPrefs.Save();
    }

    public void LoadState()
    {
        TimeCnt = PlayerPrefs.GetInt("TimeCnt", 0);
        string savedChangedImages = PlayerPrefs.GetString("ChangedImages", "");
        changedImages.Clear();
        if (!string.IsNullOrEmpty(savedChangedImages))
        {
            string[] pairs = savedChangedImages.Split(';');
            foreach (string pair in pairs)
            {
                string[] keyValue = pair.Split(':');
                if (keyValue.Length == 2)
                {
                    changedImages[keyValue[0]] = StringToColor(keyValue[1]);
                }
            }
        }
        RestoreImageColors();
        UpdateProgressGauge();
    }

    private void RestoreImageColors()
    {
        foreach (var img in images)
        {
            if (changedImages.TryGetValue(img.name, out Color color))
            {
                img.color = color;
            }
            else
            {
                img.color = Color.white;
            }
        }
    }

    public void ResetState()
    {
        CancelInvoke("ChangeRandomImageColor");
        changedImages.Clear();
        foreach (var img in images)
        {
            img.color = Color.white;
        }
        TimeCnt = 0;
        SaveState();
        StartColorChange();
        UpdateProgressGauge();
        ClosePopup(); // 리셋 시 열려있는 팝업 닫기
        Debug.Log("이미지 색상이 리셋되고 변경 프로세스가 다시 시작되었습니다.");
    }

    private string ColorToString(Color color)
    {
        return $"{color.r},{color.g},{color.b},{color.a}";
    }

    private Color StringToColor(string colorString)
    {
        string[] components = colorString.Split(',');
        return new Color(
            float.Parse(components[0]),
            float.Parse(components[1]),
            float.Parse(components[2]),
            float.Parse(components[3])
        );
    }
}
