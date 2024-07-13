using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGame_Rain : MonoBehaviour
{
    public float fallspeed = 3f;
    public GameObject bucket;
    public WaterGame_GoalController goalController;
    private WaterGame_GameManager gameManager; // ���� �Ŵ��� ����

    // Start is called before the first frame update
    void Start()
    {
        if (goalController == null)
        {
            goalController = GameObject.Find("GoalController").GetComponent<WaterGame_GoalController>();
        }
        // ���� �Ŵ��� ã��
        gameManager = FindObjectOfType<WaterGame_GameManager>();
    }

    void Update()
    {
        Vector3 bucketPosition = bucket.transform.position;
        transform.Translate(Vector2.down * fallspeed * Time.deltaTime);

        if (transform.position.y < bucketPosition.y - 2)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bucket")
        {
            goalController.IncreaseGoal(0.1f); // goalSlider�� 10% ������Ű�� �޼ҵ� ȣ��
            if (gameManager != null)
            {
                gameManager.CollectRain();
            }
            Destroy(gameObject);
        }
    }
}
