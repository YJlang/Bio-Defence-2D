using UnityEngine;
using System.Collections;

public class BirdSpawner : MonoBehaviour
{
    public GameObject birdPrefab;
    public float spawnInterval = 1f;
    public int maxBirds = 10;
    public float initialDelay = 3f;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(StartSpawningAfterDelay());
    }

    private IEnumerator StartSpawningAfterDelay()
    {
        Debug.Log("새 생성 시작까지 " + initialDelay + "초 대기 중...");
        yield return new WaitForSeconds(initialDelay);
        Debug.Log("새 생성 시작!");
        StartCoroutine(SpawnBirdsRoutine());
    }

    private IEnumerator SpawnBirdsRoutine()
    {
        while (!GameManager.Instance.isGameOver)
        {
            SpawnBird();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnBird()
    {
        if (GameObject.FindGameObjectsWithTag("Bird").Length >= maxBirds)
        {
            return;
        }

        Vector3 spawnPosition = GetRandomPositionOnScreen();
        GameObject bird = Instantiate(birdPrefab, spawnPosition, Quaternion.identity);
        bird.tag = "Bird";
        Debug.Log("새로운 새가 생성되었습니다: " + bird.name);
    }

    private Vector3 GetRandomPositionOnScreen()
    {
        Vector3 randomPositionOnScreen = mainCamera.ViewportToWorldPoint(new Vector3(Random.value, Random.value, mainCamera.nearClipPlane));
        randomPositionOnScreen.z = 0;
        return randomPositionOnScreen;
    }
}