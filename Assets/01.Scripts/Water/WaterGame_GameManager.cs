using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaterGame_GameManager : MonoBehaviour
{
    public GameObject rainPrefab;
    public float spawnColltime;
    private float nextSpawntime = 0f;
    private int collectedRainCount = 0; // ���� ���� ������Ʈ ������ ������ ����
    public int targetCount = 10; // ��ǥ ����

    // ���� ���� �� ǥ���� UI �ؽ�Ʈ
    public GameObject endGameText;

    // ������ ǥ���� UI �ؽ�Ʈ
    public Text scoreText;
    private int score = 0;

    void Start() {
        InvDataManager.Instance.LoadData();
    }

    private void Update()
    {
        if (Time.time > nextSpawntime)
        {
            SpawnRain();
            spawnColltime = Random.Range(0.5f, 1.2f);
            nextSpawntime = Time.time + spawnColltime;
        }
    }

    void SpawnRain()
    {
        float randomX = UnityEngine.Random.Range(-8f, 8f);
        Vector2 spawnPosition = new Vector2(randomX, 5.5f);
        Instantiate(rainPrefab, spawnPosition, Quaternion.identity);
    }

    public void CollectRain()
    {
        collectedRainCount++;
        score++;
        UpdateScoreUI();

        if (collectedRainCount >= targetCount)
        {
            EndGame();
        }
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }

    void EndGame()
    {
        Debug.Log("���� ����! 10���� ������� ��ҽ��ϴ�.");
        // ���� ���� UI ǥ��
        InvDataManager.Instance.playerInventory = 1;
        InvDataManager.Instance.SaveData();
        if (endGameText != null)
        {
            endGameText.SetActive(true);
        }
    }
}
