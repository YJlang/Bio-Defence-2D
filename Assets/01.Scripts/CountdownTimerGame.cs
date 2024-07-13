using UnityEngine;
using TMPro;
using System.Collections;

public class CountdownTimerGame : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    public GameObject bat;
    public float countdownTime = 3f;
    public string goText = "GO!";

    public AudioSource audioSource; // AudioSource 컴포넌트
    public AudioClip countdownSound; // 카운트다운 효과음
    public AudioClip goSound; // GO! 효과음

    private void Start()
    {
        // AudioSource가 할당되지 않았다면 자동으로 추가
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        StartCoroutine(StartCountdown());
    }

    private IEnumerator StartCountdown()
    {
        float currentTime = countdownTime;

        while (currentTime > 0)
        {
            countdownText.text = currentTime.ToString("0");

            // 카운트다운 효과음 재생
            if (countdownSound != null)
            {
                audioSource.PlayOneShot(countdownSound);
            }

            yield return new WaitForSeconds(1f);
            currentTime--;
        }

        countdownText.text = goText;

        // GO! 효과음 재생
        if (goSound != null)
        {
            audioSource.PlayOneShot(goSound);
        }

        yield return new WaitForSeconds(1f);

        countdownText.gameObject.SetActive(false);
        //bat.SetActive(true);


        // 여기에 게임 시작 로직을 추가할 수 있습니다.
    }
}