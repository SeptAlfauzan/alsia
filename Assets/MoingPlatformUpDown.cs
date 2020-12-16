using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoingPlatformUpDown : MonoBehaviour
{
    // Start is called before the first frame update

    int moveVariable = 1;
    float speedmove = 0.01f; 

    float calculateMovement;
    [Header("Max and min Y movement of platform")]
    public float maxheight;
    public float minHeight;
    // Update is called once per frame
    void Update()
    {   calculateMovement = moveVariable * speedmove;

        if ( transform.position.y >= maxheight)//if reach max height, change moveVariable to negative
        {
            moveVariable = -1;
        }else if(transform.position.y <= minHeight){//if reach min height, change moveVariable to positive
            moveVariable = 1;
        }

        transform.position = transform.position + new Vector3(0, calculateMovement, 0);
    }
}
