using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    // 활성화/비활성화할 오브젝트를 public으로 선언하여 인스펙터에서 드래그 앤 드롭할 수 있게 합니다.
    public GameObject targetObject;

    // 이 함수는 버튼 클릭 이벤트에 연결될 것입니다.
    public void OnButtonClickRecipe()
    {
        if (targetObject != null)
        {
            // 오브젝트의 활성화 상태를 토글합니다.
            targetObject.SetActive(!targetObject.activeSelf);
        }
    }
}
