using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 680.0f;
    public int maxJumps = 2;

    private Rigidbody2D rbody;
    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private int jumpsRemaining;
    private bool isGrounded = true;

    // 애니메이션 파라미터 이름
    private const string IS_RUNNING = "isRunning";
    private const string IS_JUMPING = "isJumping";

    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        jumpsRemaining = maxJumps;
    }

    void Update()
    {
        // 이동 처리
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        Vector2 movement = new Vector2(moveHorizontal * moveSpeed, rbody.velocity.y);
        rbody.velocity = movement;

        // 방향 전환
        if (moveHorizontal != 0)
        {
            spriteRenderer.flipX = (moveHorizontal < 0);
        }

        // 달리기 애니메이션
        animator.SetBool(IS_RUNNING, moveHorizontal != 0);

        // 점프 처리
        if (Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            Jump();
        }

        // 점프 애니메이션
        animator.SetBool(IS_JUMPING, !isGrounded);
    }

    void Jump()
    {
        rbody.velocity = new Vector2(rbody.velocity.x, 0); // 수직 속도 리셋
        rbody.AddForce(Vector2.up * jumpForce);
        jumpsRemaining--;
        isGrounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            isGrounded = true;
            jumpsRemaining = maxJumps;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Tile"))
        {
            isGrounded = false;
        }
    }
}