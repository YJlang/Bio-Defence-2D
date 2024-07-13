using UnityEngine;

public class VerticalMovingFlippingObstacle : MonoBehaviour
{
    // 이동 속도
    public float moveSpeed = 2f;

    // y축 이동 범위
    public float moveRange = 3f;

    // 초기 y 위치를 저장
    private float initialY;

    // 방향 전환을 위한 변수
    private bool movingUp = true;

    void Start()
    {
        // 초기 y 위치 저장
        initialY = transform.position.y;
    }

    void Update()
    {
        // 현재 y 위치
        float currentY = transform.position.y;

        // y축 이동
        if (movingUp)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);

            if (currentY >= initialY + moveRange)
            {
                movingUp = false;
                Flip();
            }
        }
        else
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);

            if (currentY <= initialY - moveRange)
            {
                movingUp = true;
                Flip();
            }
        }
    }

    void Flip()
    {
        // 오브젝트의 로컬 스케일을 반전시킴
        Vector3 scale = transform.localScale;
        scale.y *= -1;
        transform.localScale = scale;
    }
}
