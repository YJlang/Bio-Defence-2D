using UnityEngine;
using UnityEngine.SceneManagement; // �� ���� �߰��Ͽ� SceneManager�� �����մϴ�

public class ButtonManager : MonoBehaviour
{
    public int Item1;
    public int Item2;
    public int Item3;
    public int Item5;
    public int Item4;

    public DisableObjectOnClick disableObjectOnClick;

    public RandomImageColor RandomImageColor;
    public bool potionRoomOpen = false;
    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
        
    }

    // 메인 맵 으로 이동
    public void OnButtonClick()
    {
        SceneManager.LoadScene("Map");
    }
    public void GoMain()
    {
        // ResetManager.ResetGame();
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

        SceneManager.LoadScene("Main");
    } //인벤토리 
    public void potion()
    {
        potionCheck();

        if(potionRoomOpen) {
            Debug.Log("정확한 제조법이기 때문에 제조실이 열립니다.");
            SceneManager.LoadScene("Potion");

        }
        else {
            Debug.Log($"제조법이 틀려 제조실이 열리지 않습니다.현재 조합법:{Item1 + Item2 + Item3 + Item4}");
        }
    }
    
    void potionCheck() {
        InvDataManager.Instance.LoadData();
        Item1 = InvDataManager.Instance.playerInventorySave1;
        Item2 = InvDataManager.Instance.playerInventorySave2;
        Item3 = InvDataManager.Instance.playerInventorySave3;
        Item4 = InvDataManager.Instance.playerInventorySave4;
        Item5 = InvDataManager.Instance.playerInventorySave5;
        if(Item1 + Item2 + Item3 + Item4 == 10 || Item1 + Item2 + Item3 + Item5 == 10 || Item1 + Item2 + Item4 + Item5 == 10 || Item1 + Item3 + Item4 + Item5 == 10|| Item2 + Item3 + Item4 + Item5 == 10 ) {
            
            if(Item1 == Item2 || Item1 == Item3 || Item1 == Item4 || Item1 == Item5 || Item2 == Item3 || Item2 == Item4 || Item2 == Item5 || Item3 == Item4 || Item3 == Item5 || Item4 == Item5) {

            }else {
                potionRoomOpen = true;
            }
        } 
    }
    public void gamewater()
    {
        // 물 획득 게임
        SceneManager.LoadScene("WaterGame");
    }
    public void gamevitamin()
    {
        // 비타민 획득 게임
        SceneManager.LoadScene("VitaminGame");
    }
    public void gamesugar()
    {
        // 설탕 획득 게임
        SceneManager.LoadScene("SugarGame");
    }
    public void gameoil()
    {
        // 기름 획득 게임
        SceneManager.LoadScene("OilGame");
    }
    public void gameFish()
    {
        SceneManager.LoadScene("SaltGame");
    } // 물고기 획득 게임

    public void GoTreat()
    {
        SceneManager.LoadScene("New Scene");
    } //치료 맵
    public void potionMapToMap() {
        InvDataManager.Instance.LoadData();
        InvDataManager.Instance.indexCount--;
        InvDataManager.Instance.SaveData();
        SceneManager.LoadScene("Map");
    }
    public void GoMainEnd()
    {
        SceneManager.LoadScene("Main");
    }
}
