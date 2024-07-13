using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetManager : MonoBehaviour
{
    public static ResetManager Instance { get; private set; }

    public CountdownTimer countdownTimer;
    public RandomImageColor randomImageColor;
    public DisableObjectOnClick disableObjectOnClick;

    private void Awake()
    {
        InvDataManager.Instance.LoadData();
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if(InvDataManager.Instance.playerInventory == 0) {
            ResetGame();

        }

    }

    void Start() {
        ResetGame();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            ResetGame();
        }
    }

    public void ResetGame()
    {
        Debug.Log("시작할때 리셋 ");
        if (countdownTimer != null)
        {
            countdownTimer.ResetTimer();
        }
        else
        {
            Debug.LogWarning("CountdownTimer is not assigned in ResetManager");
        }

        if (randomImageColor != null)
        {
            randomImageColor.ResetState();
        }
        else
        {
            Debug.LogWarning("RandomImageColor is not assigned in ResetManager");
        }

        if (disableObjectOnClick != null)
        {
            disableObjectOnClick.ResetObjectState();
        }
        else
        {
            Debug.LogWarning("DisableObjectOnClick is not assigned in ResetManager");
        }

        Debug.Log("������ ���µǾ����ϴ�.");
        InvDataManager.Instance.LoadData();
        InvDataManager.Instance.playerInventory = 0;
        InvDataManager.Instance.playerInventorySave1 = 0;
        InvDataManager.Instance.playerInventorySave2 = 0;
        InvDataManager.Instance.playerInventorySave3 = 0;
        InvDataManager.Instance.playerInventorySave4 = 0;
        InvDataManager.Instance.playerInventorySave5 = 0;
        InvDataManager.Instance.playerInventorySave6 = 0;
        InvDataManager.Instance.playerInventorySave7 = 0;

        InvDataManager.Instance.indexCount = 0;
        InvDataManager.Instance.SaveData();
    }

    private void OnApplicationQuit()
    {
        SaveStates();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SaveStates();
        }
    }

    public void SaveStates()
    {
        if (countdownTimer != null)
        {
            countdownTimer.SaveState();
        }

        if (randomImageColor != null)
        {
            randomImageColor.SaveState();
        }

        if (disableObjectOnClick != null)
        {
            disableObjectOnClick.SaveState();
        }
    }
}

