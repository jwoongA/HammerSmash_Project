using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMover : MonoBehaviour
{
    public float speed = 5f;
    public float destroyX = -25f;

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < destroyX)
            Destroy(gameObject);
    }
}
