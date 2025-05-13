using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMover : MonoBehaviour
{
    public static float speed = 5f;
    public float destroyX = -25f;

    void Start()
    {    
        speed = 5f;
    }

    void Update()
    {
        float currentSpeed = speed * ObstacleMover.globalSpeedMultiplier;
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }


    public static void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
