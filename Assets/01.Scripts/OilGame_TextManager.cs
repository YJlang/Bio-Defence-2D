using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OilGame_TextManager : MonoBehaviour
{
    [SerializeField] private GameObject startText;
    [SerializeField] private GameObject getOil1Text;
    [SerializeField] private GameObject getOil2Text;
    [SerializeField] private GameObject getOil3Text;

    private Dictionary<string, GameObject> textBubbles;

    void Awake()
    {
        // 초기화
        textBubbles = new Dictionary<string, GameObject>
        {
            { "start", startText },
            { "getOil1", getOil1Text },
            { "getOil2", getOil2Text },
            { "getOil3", getOil3Text }
        };


        // 모든 텍스트 오브젝트를 비활성화
        foreach (var bubble in textBubbles.Values)
        {
            if (bubble != null)
            {
                bubble.SetActive(false);
            }
            else
            {
                Debug.LogWarning("TextBubble이 null입니다.");
            }
        }


        // 초기 텍스트 설정
        SetText("start", "노란 오일을 나에게 가져와줘! 한 번에 하나씩만 가져와야 해.");
        SetText("getOil1", "고마워! 이 기름은 면역 반응을 강화시키는 데 쓰일 거야.");
        SetText("getOil2", "고마워! 이 기름은 백신 내 성분을 혼합하는 데 쓰일 거야.");
        SetText("getOil3", "수고했어! 완성된 기름을 줄 테니 백신을 만들어서 세상을 구해 줘!");
    }

    // 텍스트를 설정하는 메서드
    public void SetText(string bubbleName, string newText)
    {
        if (textBubbles.ContainsKey(bubbleName))
        {
            var textBubble = textBubbles[bubbleName];
            if (textBubble != null)
            {
                Text textComponent = textBubble.GetComponent<Text>();
                if (textComponent != null)
                {
                    textComponent.text = newText;
                }
                else
                {
                    Debug.LogWarning(bubbleName + "에 Text 컴포넌트가 없습니다.");
                }
            }
            else
            {
                Debug.LogWarning(bubbleName + "이(가) null입니다.");
            }
        }
        else
        {
            Debug.LogWarning("TextBubble " + bubbleName + "을(를) 찾을 수 없습니다.");
        }
    }

    // 특정 텍스트만 표시하는 메서드
    public void ShowText(string bubbleName)
    {
        //모든 텍스트 오브젝트를 비활성화
        foreach (var bubble in textBubbles.Values)
        {
            if (bubble != null)
                bubble.SetActive(false);
            else
                Debug.LogWarning("TextBubble이 null입니다.");
        }

        // 해당 텍스트 오브젝트만 활성화
        if (textBubbles.ContainsKey(bubbleName))
        {
            var textBubble = textBubbles[bubbleName];
            if (textBubble != null)
            {
                textBubble.SetActive(true);
            }
            else
            {
                Debug.LogWarning(bubbleName + "이(가) null입니다.");
            }
        }
        else
        {
            Debug.LogWarning("TextBubble " + bubbleName + "을(를) 찾을 수 없습니다.");
        }
    }
}
