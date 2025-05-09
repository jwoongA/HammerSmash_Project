using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvisiblePlatform : MonoBehaviour
{
    public Transform player;
    public float yOffset = -3.9f;

    private void LateUpdate()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, yOffset, transform.position.z);
        }
    }
}
