using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public int startNumber = 30;
    private int currentNumber;
    public Text displayText;
    private Coroutine countdownCoroutine;

    void Start()
    {
        LoadState();
        StartCountdown();
    }

    void OnDisable()
    {
        SaveState();
    }

    void StartCountdown()
    {
        StopCountdown();
        countdownCoroutine = StartCoroutine(Countdown());
    }

    void StopCountdown()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
            countdownCoroutine = null;
        }
    }

    IEnumerator Countdown()
    {
        while (currentNumber > 0)
        {
            UpdateDisplay();
            yield return new WaitForSeconds(10); // 10초마다 감소하도록 수정
            currentNumber--;
        }
        OnCountdownFinished();
    }

    void UpdateDisplay()
    {
        if (displayText != null)
        {
            displayText.text = currentNumber.ToString();
        }
    }

    void OnCountdownFinished()
    {
        Debug.Log("카운트다운 종료!");
        // 여기에 카운트다운이 끝났을 때의 추가 로직을 구현하세요.
    }

    public void SaveState()
    {
        PlayerPrefs.SetInt("CurrentNumber", currentNumber);
        PlayerPrefs.SetString("LastSaveTime", DateTime.Now.ToBinary().ToString());
        PlayerPrefs.Save();
    }

    void LoadState()
    {
        if (PlayerPrefs.HasKey("CurrentNumber"))
        {
            currentNumber = PlayerPrefs.GetInt("CurrentNumber", startNumber);
            long lastSaveBinary = Convert.ToInt64(PlayerPrefs.GetString("LastSaveTime", "0"));
            DateTime lastSaveTime = DateTime.FromBinary(lastSaveBinary);
            TimeSpan timePassed = DateTime.Now - lastSaveTime;
            int secondsPassed = (int)timePassed.TotalSeconds;
            int tenSecondsPassed = secondsPassed / 10;
            currentNumber -= tenSecondsPassed;
            if (currentNumber < 0) currentNumber = 0;
        }
        else
        {
            currentNumber = startNumber;
        }
    }

    public void ResetTimer()
    {
        StopCountdown();
        currentNumber = startNumber;
        SaveState();
        StartCountdown();
        UpdateDisplay();
        Debug.Log("타이머가 리셋되고 다시 시작되었습니다.");
    }
}
