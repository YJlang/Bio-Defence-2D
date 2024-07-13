using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PotionRoomCheck : MonoBehaviour
{
    // Start is called before the first frame update

    public int Item1;
    public int Item2;
    public int Item3;
    public int Item5;
    public int Item4;

    public bool potionRoomOpen = false;

    void Start()
    {
        InvDataManager.Instance.LoadData();   

    }

    void Update() {
        Item1 = InvDataManager.Instance.playerInventorySave1;
        Item2 = InvDataManager.Instance.playerInventorySave2;
        Item3 = InvDataManager.Instance.playerInventorySave3;
        Item4 = InvDataManager.Instance.playerInventorySave4;
        Item5 = InvDataManager.Instance.playerInventorySave5;
        if(Item1 + Item2 + Item3 + Item4 == 10 || Item1 + Item2 + Item3 + Item5 == 10 || Item1 + Item2 + Item4 + Item5 == 10 || Item1 + Item3 + Item4 + Item5 == 10|| Item2 + Item3 + Item4 + Item5 == 10) {
            potionRoomOpen = true;
        }
        if (Input.GetMouseButtonDown(0)) {
            potionCheck();
        }
    }
    
    void potionCheck() {
        if(potionRoomOpen) {
            Debug.Log("정확한 제조법이기 때문에 제조실이 열립니다.");
            SceneManager.LoadScene("Potion");
        }
        else {
            Debug.Log($"제조법이 틀려 제조실이 열리지 않습니다.현재 조합법:{Item1 + Item2 + Item3 + Item4}");
        }
    }
    
    
}
