using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float EnemyHP = 10.0f;
    public float speed = 0.2f;
    Transform playerTr;
    Player player;
    private Animator animator;
    private bool isDead = false;

    CameraShake camera;

    void Start()
    {
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindWithTag("Player").GetComponent<Player>();
        animator = GetComponent<Animator>();
        camera = GameObject.FindWithTag("MainCamera").GetComponent<CameraShake>();
    }

    void Update()
    {
        if (!isDead)
        {
            transform.position = Vector3.Lerp(transform.position, playerTr.position, Time.deltaTime * speed);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (isDead) return;

        if (other.gameObject.CompareTag("Bullet"))
        {
            EnemyHP -= 1f;
            Debug.Log("EnemyHP : " + EnemyHP);

            if (EnemyHP <= 0f)
            {
                camera.VibrateForTime(0.05f);
                player.ScoreUP();
                Die();
            }
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            camera.VibrateForTime(0.05f);
            player.PlayerHPMinus();
            Debug.Log("플레이어와 충돌");
            Die();
        }
    }

    private void Die()
    {
        if (isDead) return;

        isDead = true;
        Debug.Log("사망");

        // 충돌 비활성화
        GetComponent<Collider2D>().enabled = false;

        // Enemy Death 애니메이션 재생
        animator.Play("Enemy Death");

        // 애니메이션이 끝나고 오브젝트를 파괴하는 코루틴 시작
        StartCoroutine(DestroyAfterAnimation());
    }

    private IEnumerator DestroyAfterAnimation()
    {
        // Enemy Death 애니메이션의 길이를 가져옵니다.
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        float deathAnimationLength = stateInfo.length;

        // 애니메이션 길이만큼 대기
        yield return new WaitForSeconds(deathAnimationLength);

        // 오브젝트 파괴
        Destroy(gameObject);
    }
}