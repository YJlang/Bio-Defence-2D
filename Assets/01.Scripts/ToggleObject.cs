using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleObject : MonoBehaviour
{
    // Ȱ��ȭ/��Ȱ��ȭ�� ������Ʈ�� public���� �����Ͽ� �ν����Ϳ��� �巡�� �� ����� �� �ְ� �մϴ�.
    public GameObject targetObject;

    // �� �Լ��� ��ư Ŭ�� �̺�Ʈ�� ����� ���Դϴ�.
    public void OnButtonClickRecipe()
    {
        if (targetObject != null)
        {
            // ������Ʈ�� Ȱ��ȭ ���¸� ����մϴ�.
            targetObject.SetActive(!targetObject.activeSelf);
        }
    }
}
