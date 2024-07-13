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
        // �ʱ�ȭ
        textBubbles = new Dictionary<string, GameObject>
        {
            { "start", startText },
            { "getOil1", getOil1Text },
            { "getOil2", getOil2Text },
            { "getOil3", getOil3Text }
        };


        // ��� �ؽ�Ʈ ������Ʈ�� ��Ȱ��ȭ
        foreach (var bubble in textBubbles.Values)
        {
            if (bubble != null)
            {
                bubble.SetActive(false);
            }
            else
            {
                Debug.LogWarning("TextBubble�� null�Դϴ�.");
            }
        }


        // �ʱ� �ؽ�Ʈ ����
        SetText("start", "��� ������ ������ ��������! �� ���� �ϳ����� �����;� ��.");
        SetText("getOil1", "����! �� �⸧�� �鿪 ������ ��ȭ��Ű�� �� ���� �ž�.");
        SetText("getOil2", "����! �� �⸧�� ��� �� ������ ȥ���ϴ� �� ���� �ž�.");
        SetText("getOil3", "�����߾�! �ϼ��� �⸧�� �� �״� ����� ���� ������ ���� ��!");
    }

    // �ؽ�Ʈ�� �����ϴ� �޼���
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
                    Debug.LogWarning(bubbleName + "�� Text ������Ʈ�� �����ϴ�.");
                }
            }
            else
            {
                Debug.LogWarning(bubbleName + "��(��) null�Դϴ�.");
            }
        }
        else
        {
            Debug.LogWarning("TextBubble " + bubbleName + "��(��) ã�� �� �����ϴ�.");
        }
    }

    // Ư�� �ؽ�Ʈ�� ǥ���ϴ� �޼���
    public void ShowText(string bubbleName)
    {
        //��� �ؽ�Ʈ ������Ʈ�� ��Ȱ��ȭ
        foreach (var bubble in textBubbles.Values)
        {
            if (bubble != null)
                bubble.SetActive(false);
            else
                Debug.LogWarning("TextBubble�� null�Դϴ�.");
        }

        // �ش� �ؽ�Ʈ ������Ʈ�� Ȱ��ȭ
        if (textBubbles.ContainsKey(bubbleName))
        {
            var textBubble = textBubbles[bubbleName];
            if (textBubble != null)
            {
                textBubble.SetActive(true);
            }
            else
            {
                Debug.LogWarning(bubbleName + "��(��) null�Դϴ�.");
            }
        }
        else
        {
            Debug.LogWarning("TextBubble " + bubbleName + "��(��) ã�� �� �����ϴ�.");
        }
    }
}
