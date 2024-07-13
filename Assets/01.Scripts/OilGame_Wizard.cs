using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OilGame_Wizard : MonoBehaviour
{
    private int oilCount = 0;
    public int maxCount = 3;
    public OilGame_TextManager textManager;
    public GameObject gameOverUI; 
    // 게임 종료 시 표시할 UI

    private void Start()
    {
        textManager = FindObjectOfType<OilGame_TextManager>();
        textManager.ShowText("start");

        InvDataManager.Instance.LoadData();

    }

    public void ReceiveOil()
    {
        Debug.Log("Wizard�� ������ �޾ҽ��ϴ�!");
        oilCount++;
        if (oilCount >= maxCount)
        {
            Debug.Log("���� ȹ��!");
            if (gameOverUI != null)
            {
                gameOverUI.SetActive(true);
                InvDataManager.Instance.playerInventory =   4;
                InvDataManager.Instance.SaveData();
            }
        }

        switch (oilCount)
        {
            case 1:
                textManager.ShowText("getOil1");
                break;
            case 2:
                textManager.ShowText("getOil2");
                break;
            case 3:
                textManager.ShowText("getOil3");
                break;
        }
    }
}
