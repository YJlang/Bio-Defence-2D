using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OilGame_Character : MonoBehaviour
{
    public float speed = 2;
    private float vx = 0;
    private float vy = 0;
    private bool leftflag = false;
    private bool isHave = false;
    Rigidbody2D  rbody;

    private void Start()
    {
    }


    void Update()
    {
        #region �÷��̾� �̵�
        vx = 0;
        vy = 0 ;
        if (Input.GetKey("right"))
        {
            vx = speed;
            leftflag = false;
        }
        if (Input.GetKey("left"))
        {
            vx = -speed;
            leftflag = true;
        }
        if (Input.GetKey("up"))
        {
            vy = speed;
        }
        if (Input.GetKey("down"))
        {
            vy = -speed;
        }
        #endregion
    }
    private void FixedUpdate()
    {
        this.transform.Translate(vx / 50, vy / 50, 0);
        this.GetComponent<SpriteRenderer>().flipX = leftflag;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Oil"))
        {
            isHave = true;
            Destroy(collision.gameObject); // ���� �������� �ı��մϴ�.
        }
        else if (collision.gameObject.CompareTag("Wizard") && isHave)
        {
            collision.gameObject.GetComponent<OilGame_Wizard>().ReceiveOil();
            isHave = false;
        }
    }
}
