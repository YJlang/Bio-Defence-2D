using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGame_Bucket : MonoBehaviour
{
    public float moveSpeed = 5f; // 버킷의 이동 속도를 설정하는 변수

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 bucketPosition = transform.position;

        // 목표 위치는 마우스의 x 위치를 적용한 버킷의 현재 위치
        Vector3 targetPosition = new Vector3(mousePosition.x, bucketPosition.y, bucketPosition.z);

        // 현재 위치에서 목표 위치로 이동
        transform.position = Vector3.MoveTowards(bucketPosition, targetPosition, moveSpeed * Time.deltaTime);
    }
}
