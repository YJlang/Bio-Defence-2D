using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreatColor : MonoBehaviour
{
    public Transform parentTransform;
    public Canvas completionCanvas; // ��� �̹����� ����� �� �� ��Ÿ�� ĵ����
    private List<Image> images = new List<Image>();
    private List<Image> imagesToChange = new List<Image>(); // ���� ������ �̹����� �����ϱ� ���� ����Ʈ

    void Start()
    {
        InitializeImages();
        completionCanvas.gameObject.SetActive(false); // ������ �� ĵ������ ��Ȱ��ȭ
        imagesToChange.AddRange(images); // ������ �̹����� �ʱ�ȭ
        StartCoroutine(ChangeColorsGradually());
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

    IEnumerator ChangeColorsGradually()
    {
        int imagesPerSecond = 3; // 1�ʿ� 2����

        while (imagesToChange.Count > 0)
        {
            for (int i = 0; i < imagesPerSecond && imagesToChange.Count > 0; i++)
            {
                int randomIndex = Random.Range(0, imagesToChange.Count);
                imagesToChange[randomIndex].color = Color.white;
                imagesToChange.RemoveAt(randomIndex);
            }
            yield return new WaitForSeconds(0.5f); // 1�� ���
        }

        Debug.Log("��� �̹����� ������� �����Ǿ����ϴ�.");
        completionCanvas.gameObject.SetActive(true); // ��� �̹����� ����� �� �� ĵ������ Ȱ��ȭ
    }

    // �ʿ��� ��� �ܺο��� ȣ���� �� �ִ� �޼���
    public void ResetToWhite()
    {
        StopAllCoroutines(); // ���� �ڷ�ƾ ����
        foreach (var img in images)
        {
            img.color = Color.white;
        }
        imagesToChange.Clear(); // ���� ������ �̹��� ����Ʈ �ʱ�ȭ
        completionCanvas.gameObject.SetActive(true); // ��� �̹����� ������� ������ �� ĵ������ Ȱ��ȭ
        Debug.Log("��� �̹����� ������� �����Ǿ����ϴ�.");
    }
}
