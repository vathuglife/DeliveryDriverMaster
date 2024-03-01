using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{

    public Transform player; // Reference to the player GameObject
    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            // Set the position of the camera to follow the player
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
    }
}
