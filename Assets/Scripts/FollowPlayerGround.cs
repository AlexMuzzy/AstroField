using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerGround : MonoBehaviour
{
    public float offsetPositionX;
    public float offsetPositionZ;
    void FixedUpdate()
    {
        /**
         * Follows the player x and z coordinate position, whilst keeping its own 
         * y position.
         */
        Transform player = GameObject.Find("Player").transform;
        transform.position = new Vector3(player.position.x + offsetPositionX, transform.position.y, player.position.z + offsetPositionZ);
    }
}