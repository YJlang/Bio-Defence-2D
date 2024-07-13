using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    //총알 발사
    private Transform spPoint;
    public GameObject bulletPrefab;
    public float bulletCollTime = 0.23f;
    private float bulTime = 0.0f;

    public Text ScoreText;
    private int ScorePoint = 0;

    //HPBar
    public float PlayerHP = 100.0f;
    public Image HpBar;

    // End Game UI
    public GameObject endGameUI;

    private void Start()
    {
        // spPoint를 초기화합니다. 이는 Player의 자식 오브젝트여야 합니다.
        spPoint = transform.Find("spPoint");
        if (spPoint == null)
        {
            Debug.LogError("ShootingPoint not found. Please create a child object named 'ShootingPoint'.");
        }

        if (bulletPrefab == null)
        {
            Debug.LogError("Bullet prefab is not assigned. Please assign it in the inspector.");
        }

        if (endGameUI != null)
        {
            endGameUI.SetActive(false); // 시작 시 End Game UI 비활성화
        }

        InvDataManager.Instance.LoadData();
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
        HandleShooting();
    }

    public void ScoreUP()
    {
        ScorePoint += 100;
        ScoreText.text = ScorePoint.ToString();
        if (ScorePoint >= 1000) // 점수가 1000 이상일 때
        {
            EndGame();
        }
    }

    public void PlayerHPMinus()
    {
        PlayerHP -= 10.0f;
        if (PlayerHP < 1) // HP가 0 이하일 때
        {
            EndGame();
        }
        HpBar.fillAmount = PlayerHP / 100.0f;
    }

    private void EndGame()
    {
        Debug.Log("END");
        if (endGameUI != null)
        {
            endGameUI.SetActive(true); // End Game UI 활성화
            InvDataManager.Instance.playerInventory = 11;
            InvDataManager.Instance.SaveData();
        }
    }

    private void HandleMovement()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (Get_Pos().x > -8.6f)
            {
                Move_Pos(Vector3.left * moveSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (Get_Pos().x < 8.6f)
            {
                Move_Pos(Vector3.right * moveSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.W))
        {
            if (Get_Pos().y < 4.5f)
            {
                Move_Pos(Vector3.up * moveSpeed * Time.deltaTime);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (Get_Pos().y > -4.5f)
            {
                Move_Pos(Vector3.down * moveSpeed * Time.deltaTime);
            }
        }
    }

    private void HandleRotation()
    {
        Vector3 mPosition = Input.mousePosition;
        Vector3 oPosition = transform.position;
        Vector3 target = Camera.main.ScreenToWorldPoint(mPosition);
        float dy = target.y - oPosition.y;
        float dx = target.x - oPosition.x;
        float rotateDegree = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotateDegree);
    }

    private void HandleShooting()
    {
        bulTime += Time.deltaTime;
        if (bulTime > bulletCollTime)
        {
            if (Input.GetMouseButton(0))
            {
                if (spPoint != null && bulletPrefab != null)
                {
                    Instantiate(bulletPrefab, spPoint.position, spPoint.rotation);
                    bulTime = 0f;
                }
                else
                {
                    Debug.LogWarning("Cannot shoot: spPoint or bulletPrefab is null.");
                }
            }
        }
    }

    private void Move_Pos(Vector3 move) { this.transform.position += move; }
    private Vector3 Get_Pos() { return this.transform.position; }
}
