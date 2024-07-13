using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGame_Bucket : MonoBehaviour
{
    public float moveSpeed = 5f; // ��Ŷ�� �̵� �ӵ��� �����ϴ� ����

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 bucketPosition = transform.position;

        // ��ǥ ��ġ�� ���콺�� x ��ġ�� ������ ��Ŷ�� ���� ��ġ
        Vector3 targetPosition = new Vector3(mousePosition.x, bucketPosition.y, bucketPosition.z);

        // ���� ��ġ���� ��ǥ ��ġ�� �̵�
        transform.position = Vector3.MoveTowards(bucketPosition, targetPosition, moveSpeed * Time.deltaTime);
    }
}
