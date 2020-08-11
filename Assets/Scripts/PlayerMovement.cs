using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask floorLayerMask;
    [SerializeField] CharController2D controller;
    private Rigidbody2D rb2d;
    private BoxCollider2D boxcollider2d;

    private void Awake(){
        rb2d = transform.GetComponent<Rigidbody2D>();
        boxcollider2d = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded()){
            float jumpVelocity = 17f;
            rb2d.velocity = Vector2.up*jumpVelocity;
        }
    }
    private void FixedUpdate(){
        //Movement
        float movespeed = 5.0f;
        rb2d.constraints = RigidbodyConstraints2D.FreezeRotation;
        if (Input.GetKey(KeyCode.LeftArrow)){
            rb2d.velocity = new Vector2(-movespeed, rb2d.velocity.y);
        } else{
            if (Input.GetKey(KeyCode.RightArrow)){
            rb2d.velocity = new Vector2(+movespeed, rb2d.velocity.y);
            }else {
                rb2d.velocity = new Vector2(0, rb2d.velocity.y);
                rb2d.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }

    private bool isGrounded(){
        float extraHeightText = 1f;
        RaycastHit2D raycasthit = Physics2D.BoxCast(boxcollider2d.bounds.center, boxcollider2d.bounds.size- new Vector3(0.1f, 0f, 0f), 0f, Vector2.down, extraHeightText, floorLayerMask);
        Debug.Log("Collided with: " + raycasthit.collider);
        return raycasthit.collider != null;
    }
}
