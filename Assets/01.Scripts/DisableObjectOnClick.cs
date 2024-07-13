using UnityEngine;
using UnityEngine.Events;

public class DisableObjectOnClick : MonoBehaviour
{
    public GameObject targetObject;

    public UnityEvent onButtonClickEvents;

    private bool isInitialized = false;

    private void Awake()
    {
        LoadState();
        if (isInitialized && targetObject != null)
        {
            targetObject.SetActive(false);
        }
    }

    public void OnButtonClickOK()
    {
        if (!isInitialized)
        {
            isInitialized = true;

            if (targetObject != null)
            {
                targetObject.SetActive(false);
            }

            onButtonClickEvents.Invoke();
            SaveState();
        }
    }

    public void SaveState()
    {
        PlayerPrefs.SetInt("IsInitialized", isInitialized ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void LoadState()
    {
        isInitialized = PlayerPrefs.GetInt("IsInitialized", 0) == 1;
    }

    public void ResetObjectState()
    {
        isInitialized = false;
        if (targetObject != null)
        {
            targetObject.SetActive(true);
        }
        SaveState();
    }
}
