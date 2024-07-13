using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InventoryManager : MonoBehaviour
{
    public Image targetImage; // 첫 번째 Image 컴포넌트
    public Image targetImage2; // 두 번째 Image 컴포넌트
    public Image targetImage3; // 세 번째 Image 컴포넌트
    public Image targetImage4; // 네 번째 Image 컴포넌트
    public Image targetImage5; // 다섯 번째 Image 컴포넌트
    public Image targetImage6; // 여섯 번째 Image 컴포넌트
    public Image targetImage7; // 일곱 번째 Image 컴포넌트
    public Sprite[] sourceImages; // 저장된 Sprite 배열
    private int playerInventory;
    private int playerInventory1;
    private int playerInventory2;
    private int playerInventory3;
    private int playerInventory4;
    private int playerInventory5;
    private int playerInventory6;
    private int playerInventory7;



    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
        LoadAndUpdateImages();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadAndUpdateImages();
    }

    private void LoadAndUpdateImages()
    {
        if (InvDataManager.Instance != null)
        {
            InvDataManager.Instance.LoadData();
            UpdateImages();
        }
        else
        {
            Debug.LogError("InvDataManager instance not found!");
        }
    }

    private void UpdateImages()
    {
        int indexCount = InvDataManager.Instance.indexCount;

        if (playerInventory >= 0 && playerInventory < sourceImages.Length)
        {
            if (indexCount == 0)
            {
                playerInventory = InvDataManager.Instance.playerInventory;
                UpdateSingleImage(targetImage, playerInventory);
                InvDataManager.Instance.playerInventorySave1 = playerInventory;
                InvDataManager.Instance.indexCount++;
            }
            else if (indexCount == 1)
            {
                playerInventory = InvDataManager.Instance.playerInventorySave1;
                playerInventory2 = InvDataManager.Instance.playerInventory;
                UpdateSingleImage(targetImage, playerInventory);
                UpdateSingleImage(targetImage2, playerInventory2);
                InvDataManager.Instance.indexCount++;
                InvDataManager.Instance.playerInventorySave2 = playerInventory2;
                
            }
            else if (indexCount == 2)
            {
                playerInventory = InvDataManager.Instance.playerInventorySave1;
                playerInventory2 = InvDataManager.Instance.playerInventorySave2;
                playerInventory3 = InvDataManager.Instance.playerInventory;
                UpdateSingleImage(targetImage, playerInventory);
                UpdateSingleImage(targetImage2, playerInventory2);
                UpdateSingleImage(targetImage3, playerInventory3);
                InvDataManager.Instance.indexCount++;
                InvDataManager.Instance.playerInventorySave2 = playerInventory2;
                InvDataManager.Instance.playerInventorySave3 = playerInventory3;
            }
            else if (indexCount == 3)
            {
                playerInventory = InvDataManager.Instance.playerInventorySave1;
                playerInventory2 = InvDataManager.Instance.playerInventorySave2;
                playerInventory3 = InvDataManager.Instance.playerInventorySave3;
                playerInventory4 = InvDataManager.Instance.playerInventory;
                UpdateSingleImage(targetImage, playerInventory);
                UpdateSingleImage(targetImage2, playerInventory2);
                UpdateSingleImage(targetImage3, playerInventory3);
                UpdateSingleImage(targetImage4, playerInventory4);
                InvDataManager.Instance.indexCount++;
                InvDataManager.Instance.playerInventorySave2 = playerInventory2;
                InvDataManager.Instance.playerInventorySave3 = playerInventory3;
                InvDataManager.Instance.playerInventorySave4 = playerInventory4;
            }
            else if (indexCount == 4)
            {
                playerInventory = InvDataManager.Instance.playerInventorySave1;
                playerInventory2 = InvDataManager.Instance.playerInventorySave2;
                playerInventory3 = InvDataManager.Instance.playerInventorySave3;
                playerInventory4 = InvDataManager.Instance.playerInventorySave4;
                playerInventory5 = InvDataManager.Instance.playerInventory;
                UpdateSingleImage(targetImage, playerInventory);
                UpdateSingleImage(targetImage2, playerInventory2);
                UpdateSingleImage(targetImage3, playerInventory3);
                UpdateSingleImage(targetImage4, playerInventory4);
                UpdateSingleImage(targetImage5, playerInventory5);
                InvDataManager.Instance.indexCount++;
                InvDataManager.Instance.playerInventorySave2 = playerInventory2;
                InvDataManager.Instance.playerInventorySave3 = playerInventory3;
                InvDataManager.Instance.playerInventorySave4 = playerInventory4;
                InvDataManager.Instance.playerInventorySave5 = playerInventory5;
            }
            else if (indexCount == 5)
            {
                playerInventory = InvDataManager.Instance.playerInventorySave1;
                playerInventory2 = InvDataManager.Instance.playerInventorySave2;
                playerInventory3 = InvDataManager.Instance.playerInventorySave3;
                playerInventory4 = InvDataManager.Instance.playerInventorySave4;
                playerInventory5 = InvDataManager.Instance.playerInventorySave5;
                playerInventory6 = InvDataManager.Instance.playerInventory;
                UpdateSingleImage(targetImage, playerInventory);
                UpdateSingleImage(targetImage2, playerInventory2);
                UpdateSingleImage(targetImage3, playerInventory3);
                UpdateSingleImage(targetImage4, playerInventory4);
                UpdateSingleImage(targetImage5, playerInventory5);
                UpdateSingleImage(targetImage6, playerInventory6);
                InvDataManager.Instance.indexCount++;
                InvDataManager.Instance.playerInventorySave2 = playerInventory2;
                InvDataManager.Instance.playerInventorySave3 = playerInventory3;
                InvDataManager.Instance.playerInventorySave4 = playerInventory4;
                InvDataManager.Instance.playerInventorySave5 = playerInventory5;
                InvDataManager.Instance.playerInventorySave6 = playerInventory6;
            }
            else if (indexCount == 6)
            {
                playerInventory = InvDataManager.Instance.playerInventorySave1;
                playerInventory2 = InvDataManager.Instance.playerInventorySave2;
                playerInventory3 = InvDataManager.Instance.playerInventorySave3;
                playerInventory4 = InvDataManager.Instance.playerInventorySave4;
                playerInventory5 = InvDataManager.Instance.playerInventorySave5;
                playerInventory6 = InvDataManager.Instance.playerInventorySave6;
                playerInventory7 = InvDataManager.Instance.playerInventory;
                UpdateSingleImage(targetImage, playerInventory);
                UpdateSingleImage(targetImage2, playerInventory2);
                UpdateSingleImage(targetImage3, playerInventory3);
                UpdateSingleImage(targetImage4, playerInventory4);
                UpdateSingleImage(targetImage5, playerInventory5);
                UpdateSingleImage(targetImage6, playerInventory6);
                UpdateSingleImage(targetImage7, playerInventory7);
                InvDataManager.Instance.indexCount++;
                InvDataManager.Instance.playerInventorySave2 = playerInventory2;
                InvDataManager.Instance.playerInventorySave3 = playerInventory3;
                InvDataManager.Instance.playerInventorySave4 = playerInventory4;
                InvDataManager.Instance.playerInventorySave5 = playerInventory5;
                InvDataManager.Instance.playerInventorySave6 = playerInventory6;
                InvDataManager.Instance.playerInventorySave7 = playerInventory7;
            }
            else
            {
                Debug.Log($"Both images are already set. indexCount: {indexCount}");
            }

            InvDataManager.Instance.SaveData();
        }
        else
        {
            Debug.LogWarning($"Invalid playerInventory: {playerInventory}. Image array size: {sourceImages.Length}");
        }
    }

    private void UpdateSingleImage(Image image, int index)
    {
        image.sprite = sourceImages[index];
        Debug.Log($"Image updated. Current index: {index}");
    }
}