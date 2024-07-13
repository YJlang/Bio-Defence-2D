using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float speed = 10f;
    public float changeDirectionInterval = 0.5f;
    public int scoreValue = 1;

    private Vector3 targetPosition;
    private Camera mainCamera;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isDying = false;

    private void Start()
    {
        mainCamera = Camera.main;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        SetNewTargetPosition();
        InvokeRepeating("SetNewTargetPosition", changeDirectionInterval, changeDirectionInterval);
    }

    private void Update()
    {
        if (!isDying)
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // 새의 이동 방향에 따라 스프라이트 뒤집기
            if (direction.x < 0)
            {
                spriteRenderer.flipX = true;  // 왼쪽으로 이동할 때 뒤집기
            }
            else if (direction.x > 0)
            {
                spriteRenderer.flipX = false; // 오른쪽으로 이동할 때 원래대로
            }

            if (!IsVisibleFromCamera())
            {
                SetNewTargetPosition();
            }

            if (Input.GetMouseButtonDown(0))
            {
                HandleClick();
            }
        }
    }

    private void HandleClick()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

        if (hit.collider != null && hit.collider.gameObject == gameObject && !isDying)
        {
            StartDeathSequence();
        }
    }

    private void StartDeathSequence()
    {
        isDying = true;
        animator.SetBool("Death", true);
        GameManager.Instance.AddScore(scoreValue);

        // 애니메이션 길이만큼 기다린 후 오브젝트 파괴
        float deathAnimationLength = GetDeathAnimationLength();
        Destroy(gameObject, deathAnimationLength);
    }

    private float GetDeathAnimationLength()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.length;
    }

    private void SetNewTargetPosition()
    {
        targetPosition = GetRandomPositionOnScreen();
    }

    private Vector3 GetRandomPositionOnScreen()
    {
        Vector3 randomPositionOnScreen = mainCamera.ViewportToWorldPoint(new Vector3(Random.value, Random.value, mainCamera.nearClipPlane));
        randomPositionOnScreen.z = 0;
        return randomPositionOnScreen;
    }

    private bool IsVisibleFromCamera()
    {
        Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
        return viewportPosition.x >= 0 && viewportPosition.x <= 1 &&
               viewportPosition.y >= 0 && viewportPosition.y <= 1 &&
               viewportPosition.z > 0;
    }
}