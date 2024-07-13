using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    private SugarGame gameManager;

    void Start()
    {
        gameManager = FindObjectOfType<SugarGame>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            gameManager.GameClear();
        }
    }
}