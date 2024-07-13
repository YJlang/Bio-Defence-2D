using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SugarGame : MonoBehaviour
{
    public Text timerText;
    public Text gameStateText;
    public float gameTime = 30f;

    private float timeRemaining;
    private bool isGameActive;
    public GameObject gameOverUI;

    void Start()
    {
        StartGame();
        InvDataManager.Instance.LoadData();
    }

    void Update()
    {
        if (isGameActive)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                UpdateTimerDisplay();
            }
            else
            {
                GameOver();
            }
        }
    }

    void StartGame()
    {
        isGameActive = true;
        timeRemaining = gameTime;
        UpdateTimerDisplay();
        gameStateText.text = "";
    }

    void UpdateTimerDisplay()
    {
        int seconds = Mathf.CeilToInt(timeRemaining);
        timerText.text = "Time: " + seconds.ToString();
    }

    void GameOver()
    {
        isGameActive = false;
        gameStateText.text = "Over!";
        Debug.Log("Over!");
    }

    public void GameClear()
    {
        isGameActive = false;
        gameStateText.text = "Clear!";
        Debug.Log("Clear!");
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            InvDataManager.Instance.playerInventory = 3;
            InvDataManager.Instance.SaveData();
        }
    }

    // 이 메서드는 필요한 경우 외부에서 호출할 수 있습니다.
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}