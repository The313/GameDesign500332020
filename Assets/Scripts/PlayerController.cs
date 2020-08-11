using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour //PhysicsObject
{
    protected Rigidbody2D rb2d;
    /*
    
    public float jumpF = 7.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }
    /*
    void FixedUpdate(){
		float moveHorizontal = Input.GetAxis("Horizontal")*speed;
		//float moveVertical = Input.GetAxis("Vertical");
		Vector2 movement = new Vector2(moveHorizontal,rb2d.velocity.y);
        rb2d.velocity = movement;
		if(Input.GetKeyDown(KeyCode.Space)){
            rb2d.AddForce(Vector2.up*jumpF,ForceMode2D.Impulse);
        }
	}
    
    protected override void ComputeVelocity(){
        Vector2 movement = Vector2.zero;
        movement.x = Input.GetAxis("Horizontal");
        if(Input.GetKeyDown(KeyCode.Space) && grounded){
            velocity.y = jumpF;
        }
        else if(Input.GetKeyUp(KeyCode.Space)){
            if (velocity.y >0){
                velocity.y *= 0.5F;
            }
        }
        targetedVelocity = movement*speed;

    }
    */
    //[SerializeField] CharController2D controller;
    [SerializeField] private LayerMask floorLayerMask;
    private BoxCollider2D boxcollider2d;
    public Animator animator;
    public float speed = 0.01f;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatisground;
    public float jumpF = 0.5f;
    float xMove = 0f;

    private bool facingright = true;
    /*
    public float charax;
    public float charay;
    public void Awake(){
        charax = PlayerPrefs.GetFloat("playerx");
        charay = PlayerPrefs.GetFloat("playery");
    }
    */
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        boxcollider2d = transform.GetComponent<BoxCollider2D>();
        //transform.position = new Vector2(charax, charay);

    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded == true){
            rb2d.velocity = Vector2.up * jumpF;
            animator.SetBool("isJumping", true);   
        }

        PlayerPrefs.SetFloat("playerx", transform.position.x);
        PlayerPrefs.SetFloat("playery", transform.position.y);
    }
    void FixedUpdate(){
        xMove = Input.GetAxis("Horizontal")* speed;
        animator.SetFloat("speeed",Mathf.Abs(xMove));
        if (xMove > 0 && !facingright)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (xMove < 0 && facingright)
			{
				// ... flip the player.
				Flip();
			}
		
        //controller.Move(xMove * Time.fixedDeltaTime, false, false);
        Vector2 movement = new Vector2(xMove,rb2d.velocity.y);
        rb2d.velocity = movement;
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatisground);
		if(Input.GetKeyDown(KeyCode.Space) && isGrounded){
            rb2d.AddForce(Vector2.up*jumpF,ForceMode2D.Impulse);
        }
        if (rb2d.velocity.y == 0){
            animator.SetBool("isJumping",false);
        }
    }

    public void OnLand(){
        animator.SetBool("isJumping", false);
    }
    public bool GetGrounded(){
        return isGrounded;
    }
/*
    private bool isGrounded(){
        float extraHeightText = 1f;
        RaycastHit2D raycasthit = Physics2D.BoxCast(boxcollider2d.bounds.center, boxcollider2d.bounds.size- new Vector3(0.1f, 0f, 0f), 0f, Vector2.down, extraHeightText, floorLayerMask);
        Debug.Log("Collided with: " + raycasthit.collider.ToString());
        if (raycasthit.collider.ToString() == "Floorcollider"){
            return true;
        }
        return false;
    }
*/
    void OnTriggerEnter2D(Collider2D other){
        
    }
    //
    private void Flip()
	{
		// Switch the way the player is labelled as facing.
		facingright = !facingright;

		transform.Rotate(0f, 180f, 0f);
	} 
}
