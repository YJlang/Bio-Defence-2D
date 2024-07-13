using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltGame : MonoBehaviour
{
    private float stage01Time = 0.0f;
    public GameObject enemy1;

    void Update()
    {
        stage01Time += Time.deltaTime;
        if (stage01Time > 1.5f)
        {
            Instantiate(enemy1,
                new Vector3(Random.Range(-10, 10),
                Random.Range(-10, 10),
                0),
                Quaternion.identity);
            stage01Time = 0.0f;
        }
    }
}
