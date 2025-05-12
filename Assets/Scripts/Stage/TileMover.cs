using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMover : MonoBehaviour
{
    public static float speed = 5f;
    public float destroyX = -25f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < destroyX)
            Destroy(gameObject);
    }

    public static void SetSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
}
