using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerCamera : MonoBehaviour
{
    public Transform player;
    public Vector3 offsetPosition;
    void FixedUpdate()
    {
        transform.position = player.position + offsetPosition;
    }
}
