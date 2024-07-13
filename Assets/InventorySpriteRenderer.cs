using UnityEngine;
using UnityEngine.SceneManagement;

public class InventorySpriteRenderer : MonoBehaviour
{
    public Sprite[] sourceSprites; // 사용할 스프라이트 배열
    private SpriteRenderer spriteRenderer;
    private int currentIndex = 0;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        SceneManager.sceneLoaded += OnSceneLoaded; // 씬 로드 이벤트에 메서드를 등록합니다.
        LoadAndUpdateSprite();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // 이벤트 리스너를 제거합니다.
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        LoadAndUpdateSprite(); // 씬이 로드될 때마다 데이터를 다시 로드하고 스프라이트를 업데이트합니다.
    }

    private void LoadAndUpdateSprite()
    {
        if (InvDataManager.Instance != null)
        {
            InvDataManager.Instance.LoadData();
            currentIndex = InvDataManager.Instance.playerInventory;
            UpdateSprite();
        }
        else
        {
            Debug.LogError("InvDataManager instance not found!");
        }
    }

    private void Update()
    {
        // currentIndex = InvDataManager.Instance.playerInventory;
        UpdateSprite();
    }

    private void UpdateSprite()
    {
        spriteRenderer.sprite = sourceSprites[InvDataManager.Instance.playerInventory];
        Debug.Log($"스프라이트가 변경되었습니다. 현재 인덱스: {InvDataManager.Instance.playerInventory}");

    }
}