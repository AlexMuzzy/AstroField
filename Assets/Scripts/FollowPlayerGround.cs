using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerGround : MonoBehaviour
{
    public float offsetPosition;
    void FixedUpdate()
    {
        /**
         * Follows the player z coordinate position, whilst keeping its own 
         * x and y position.
         */
        Transform player = GameObject.Find("Player").transform;
        transform.position = new Vector3(transform.position.x, transform.position.y, player.position.z + offsetPosition);
    }
}