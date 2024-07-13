using UnityEngine;

public class InvDataManager : MonoBehaviour
{
    public static InvDataManager Instance { get; private set; }

    public int playerInventory;
    public int playerInventorySave1;
    public int playerInventorySave2;
    public int playerInventorySave3;
    public int playerInventorySave4;
    public int playerInventorySave5;
    public int playerInventorySave6;
    public int playerInventorySave7;
    public int indexCount;

    private const string FirstLaunchKey = "IsFirstLaunch";
    private const string IndexCountKey = "IndexCount";

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            if (IsFirstLaunch())
            {
                ResetAllData();
                SetFirstLaunchComplete();
            }
            else
            {
                LoadData();
            }
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    private bool IsFirstLaunch()
    {
        return !PlayerPrefs.HasKey(FirstLaunchKey);
    }

    private void SetFirstLaunchComplete()
    {
        PlayerPrefs.SetInt(FirstLaunchKey, 1);
        PlayerPrefs.Save();
    }

    private void ResetAllData()
    {
        playerInventory = 0;
        indexCount = 0;
        SaveData();
        Debug.Log("All data reset for first launch.");
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("playerInventory", playerInventory);
        PlayerPrefs.SetInt("playerInventorySave1", playerInventorySave1);
        PlayerPrefs.SetInt("playerInventorySave2", playerInventorySave2);
        PlayerPrefs.SetInt("playerInventorySave3", playerInventorySave3);
        PlayerPrefs.SetInt("playerInventorySave4", playerInventorySave4);
        PlayerPrefs.SetInt("playerInventorySave5", playerInventorySave5);
        PlayerPrefs.SetInt("playerInventorySave6", playerInventorySave6);
        PlayerPrefs.SetInt("playerInventorySave7", playerInventorySave7);

        PlayerPrefs.SetInt(IndexCountKey, indexCount);
        PlayerPrefs.Save();
        Debug.Log($"All data saved. playerInventory: {playerInventory},playerInventorySave1: {playerInventorySave1},playerInventorySave2: {playerInventorySave2}, playerInventorySave3: {playerInventorySave3},playerInventorySave4: {playerInventorySave4},playerInventorySave5: {playerInventorySave5},playerInventorySave6: {playerInventorySave6},playerInventorySave7: {playerInventorySave7},indexCount: {indexCount}");
    }

    public void LoadData()
    {
        playerInventory = PlayerPrefs.GetInt("playerInventory", playerInventory);
        playerInventorySave1 = PlayerPrefs.GetInt("playerInventorySave1", playerInventorySave1);
        playerInventorySave2 = PlayerPrefs.GetInt("playerInventorySave2", playerInventorySave2);
        playerInventorySave3 = PlayerPrefs.GetInt("playerInventorySave3", playerInventorySave3);
        playerInventorySave4 = PlayerPrefs.GetInt("playerInventorySave4", playerInventorySave4);
        playerInventorySave5 = PlayerPrefs.GetInt("playerInventorySave5", playerInventorySave5);
        playerInventorySave6 = PlayerPrefs.GetInt("playerInventorySave6", playerInventorySave6);
        playerInventorySave7 = PlayerPrefs.GetInt("playerInventorySave7", playerInventorySave7);
        indexCount = PlayerPrefs.GetInt(IndexCountKey, indexCount);
        Debug.Log($"All data loaded. playerInventory: {playerInventory},playerInventorySave1: {playerInventorySave1},playerInventorySave2: {playerInventorySave2}, playerInventorySave3: {playerInventorySave3},playerInventorySave4: {playerInventorySave4},playerInventorySave5: {playerInventorySave5},playerInventorySave6: {playerInventorySave6},playerInventorySave7: {playerInventorySave7}, indexCount: {indexCount}");
    }
}