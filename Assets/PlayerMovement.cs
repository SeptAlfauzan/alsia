using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;	// How much to smooth out the movement
    private Vector3 m_Velocity = Vector3.zero;
    public Animator Animator;
    public Vector2 movementSpeed;

    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidbody2D;
    bool isJumping = false;
    public float jumpHeight;
    public Vector2 input;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxis("Horizontal");
        ChangeDirectionSprite(input.x);


        int speedValue = AnimateRun(input.x);
        Animator.SetFloat("Speed", speedValue);

        if (Input.GetKeyDown (KeyCode.Space) && !isJumping) // both conditions can be in the same branch
        { 
            Debug.Log("Jump");
            isJumping = true;
            Animator.SetBool("IsJumping", true);
            rigidbody2D.AddForce(new Vector2(0, jumpHeight), ForceMode2D.Impulse); // you need a reference to the RigidBody2D component
        }
    }

    private void OnCollisionEnter2D (Collision2D col)
    {
        Debug.Log(col);
        if (col.gameObject.tag == "Ground") // GameObject is a type, gameObject is the property
        {
            Debug.Log("colide with ground");
            isJumping = false;
            Animator.SetBool("IsJumping", false);
        }else{
            isJumping = true;
        }
    }

    int AnimateRun(float x){
        if(x != 0){
            return 1;
        }return -1;
    }

    void ChangeDirectionSprite(float x){
        if(x < 0){
            spriteRenderer.flipX = true;
        }
        
        if(x > 0){
            spriteRenderer.flipX = false;
        }
    }
    void FixedUpdate() {
        // Vector2 movement = new Vector2(movementSpeed.x * input.x, 0);
        // movement *= Time.fixedDeltaTime;
        // movement.y = rigidbody2D.velocity.y;
        // if(Input.GetKeyDown(KeyCode.Space)){
        //     rigidbody2D.AddForce(new Vector2(0f, 400f), ForceMode2D.Impulse);
        //     Debug.Log("spacebar is pressed");
        // }
        var move = movementSpeed.x * input.x;
        Vector3 targetVelocity = new Vector2(move, rigidbody2D.velocity.y);
        // And then smoothing it out and applying it to the character
        rigidbody2D.velocity = Vector3.SmoothDamp(rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);


    }
}
