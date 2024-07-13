using UnityEngine;
using UnityEngine.UI;

public class ImageBoard : MonoBehaviour
{
    [SerializeField] private float alphaThreshold = 0.1f;

    void Start()
    {
        SetAlphaThresholdForImages();
    }

    void SetAlphaThresholdForImages()
    {
        foreach (Image item in GetComponentsInChildren<Image>())
        {
            if (item != null && item.sprite != null && item.sprite.texture != null)
            {
                // 텍스처가 읽기 가능한지 확인
                if (item.sprite.texture.isReadable)
                {
                    item.alphaHitTestMinimumThreshold = alphaThreshold;
                }
                else
                {
                    Debug.LogWarning($"Image {item.name}의 텍스처가 읽기 불가능합니다. alphaHitTestMinimumThreshold를 설정할 수 없습니다.");
                }
            }
            else
            {
                Debug.LogWarning($"Image {item.name}에 유효한 스프라이트 또는 텍스처가 없습니다.");
            }
        }
    }

    // Update 메서드는 현재 사용되지 않으므로 제거했습니다.
}