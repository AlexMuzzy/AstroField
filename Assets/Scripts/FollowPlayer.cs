using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;
    public Vector3 offsetPosition;
    public Vector3 offsetRotation;
    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offsetPosition;
    }
}
