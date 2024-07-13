using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreatColor : MonoBehaviour
{
    public Transform parentTransform;
    public Canvas completionCanvas; // 모든 이미지가 흰색이 된 후 나타날 캔버스
    private List<Image> images = new List<Image>();
    private List<Image> imagesToChange = new List<Image>(); // 색을 변경할 이미지를 추적하기 위한 리스트

    void Start()
    {
        InitializeImages();
        completionCanvas.gameObject.SetActive(false); // 시작할 때 캔버스를 비활성화
        imagesToChange.AddRange(images); // 변경할 이미지를 초기화
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
        int imagesPerSecond = 3; // 1초에 2개씩

        while (imagesToChange.Count > 0)
        {
            for (int i = 0; i < imagesPerSecond && imagesToChange.Count > 0; i++)
            {
                int randomIndex = Random.Range(0, imagesToChange.Count);
                imagesToChange[randomIndex].color = Color.white;
                imagesToChange.RemoveAt(randomIndex);
            }
            yield return new WaitForSeconds(0.5f); // 1초 대기
        }

        Debug.Log("모든 이미지가 흰색으로 설정되었습니다.");
        completionCanvas.gameObject.SetActive(true); // 모든 이미지가 흰색이 된 후 캔버스를 활성화
    }

    // 필요한 경우 외부에서 호출할 수 있는 메서드
    public void ResetToWhite()
    {
        StopAllCoroutines(); // 기존 코루틴 중지
        foreach (var img in images)
        {
            img.color = Color.white;
        }
        imagesToChange.Clear(); // 색을 변경할 이미지 리스트 초기화
        completionCanvas.gameObject.SetActive(true); // 모든 이미지가 흰색으로 설정된 후 캔버스를 활성화
        Debug.Log("모든 이미지가 흰색으로 설정되었습니다.");
    }
}
