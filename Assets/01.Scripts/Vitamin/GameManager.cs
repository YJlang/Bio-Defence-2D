using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Text scoreText;
    private int score = 0;
    public bool isGameOver = false;
    public int maxScore = 10;

    public GameObject gameOverUI; 
         // 게임 종료 시 표시할 UI

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 다른 씬으로 이동해도 GameManager가 유지되도록 설정
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateScoreText();
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(false); // 시작 시 게임 종료 UI 비활성화
        }
        InvDataManager.Instance.LoadData();
    }

    public void AddScore(int points)
    {
        if (!isGameOver)
        {
            score += points;
            if (score >= maxScore)
            {
                score = maxScore;
                GameOver();
            }
            UpdateScoreText();
        }
    }

    void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score + "/" + maxScore;
        }
        if (score == maxScore) // 게임 종료 조건
        {
            scoreText.text = "게임종료!";
        }
    }

    void GameOver()
    {
        isGameOver = true;
        DestroyAllBirds();

        // 게임 종료 UI 표시
        if (gameOverUI != null)
        {
            gameOverUI.SetActive(true);
            InvDataManager.Instance.playerInventory = 2;
            InvDataManager.Instance.SaveData();
        }

        // 추가적인 게임 종료 로직을 여기에 구현할 수 있습니다.
        // 예: 최고 점수 저장, 게임 오버 UI 표시 등
    }

    private void DestroyAllBirds()
    {
        GameObject[] birds = GameObject.FindGameObjectsWithTag("Bird");
        foreach (GameObject bird in birds)
        {
            Destroy(bird);
        }
    }
}
