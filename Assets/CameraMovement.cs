using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector3 offset;
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        Vector2 playerAxis = GameObject.Find("Player").GetComponent<PlayerMovement>().input;
        if(playerAxis.x != offset.x)
            offset = new Vector3(playerAxis.x, playerAxis.y, -1);
        transform.position = (player.position + offset);     
    }


}
