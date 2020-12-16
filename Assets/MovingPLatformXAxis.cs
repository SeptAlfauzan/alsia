using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPLatformXAxis : MonoBehaviour
{
    int moveVariable = 1;
    float speedmove = 0.01f; 

    float calculateMovement;
    [Header("Max and min X movement of platform")]
    public float left;
    public float right;
    bool isPlayerTouched = false;
    int moveVariablePlayer = 0;
    // Update is called once per frame
    void Update()
    {   
        var player = GameObject.Find("Player").GetComponent<Transform>();
        calculateMovement = moveVariable * speedmove;

        if ( transform.position.x >= right)//if reach max height, change moveVariable to negative
        {
            moveVariable = -1;
        }else if(transform.position.x <= left){//if reach min height, change moveVariable to positive
            moveVariable = 1;
        }

        transform.position = transform.position + new Vector3(calculateMovement, 0, 0);
        player.position = player.position + new Vector3(calculateMovement * moveVariablePlayer, 0, 0);
        
    }

    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            Debug.Log("Player move away from platform");
            moveVariablePlayer = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player"){
            moveVariablePlayer = 1;
        }
    }
}
