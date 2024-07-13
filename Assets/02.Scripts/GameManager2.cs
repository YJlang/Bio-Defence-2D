using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager2 : MonoBehaviour
{
    // 텔레포트할 위치
    private Vector3 teleportPosition = new Vector3(-7.8922f, -2.74f, 0f);
    private Camera mainCamera;
    public float borderThreshold = 0.1f;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (IsOutOfCameraBounds())
        {
            transform.position = teleportPosition;
        }
    }

    bool IsOutOfCameraBounds()
    {
        if (mainCamera == null) return false;

        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);

        return viewportPosition.x < -borderThreshold ||
               viewportPosition.x > 1 + borderThreshold ||
               viewportPosition.y < -borderThreshold ||
               viewportPosition.y > 1 + borderThreshold ||
               viewportPosition.z < 0;
    }

    // 충돌 감지 함수
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 충돌한 오브젝트가 "Jang" 태그를 가진 경우
        if (collision.gameObject.tag == "Jang")
        {
            // 플레이어의 위치를 텔레포트 위치로 변경
            transform.position = teleportPosition;
        }
    }
}
