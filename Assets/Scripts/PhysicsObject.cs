using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    public float MinGroundNormalY = 0.65f;
    public float gravityModifier = 1f;
    protected Vector2 targetedVelocity;
    protected Rigidbody2D rb2d;
    protected Vector2 velocity;
    protected Vector2 groundNormal;
    protected bool grounded;
    protected const float minMoveDist = 0.001f;
    protected const float shellRadius = 0.01f;
    protected ContactFilter2D contactFilter;
    protected RaycastHit2D[] hitbuffer = new RaycastHit2D[16];
    protected List<RaycastHit2D>hitbufferlist = new List<RaycastHit2D>(16);
    
    void OnEnable(){
        rb2d = GetComponent<Rigidbody2D> ();
    }
    // Start is called before the first frame update
    void Start()
    {
        contactFilter.useTriggers = false;
        contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
        contactFilter.useLayerMask = true;
    }

    // Update is called once per frame
    void Update()
    {
        targetedVelocity = Vector2.zero;
        ComputeVelocity();

    }
    protected virtual void ComputeVelocity(){

    }
    void FixedUpdate(){
        velocity += gravityModifier * Physics2D.gravity * Time.deltaTime;
        velocity.x = targetedVelocity.x;
        grounded = false;
        Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);
        Vector2 changedPos = velocity * Time.deltaTime;
        Vector2 movement = moveAlongGround * changedPos.x;
        Movement(movement, false); 
        movement = Vector2.up * changedPos.y;
        Movement(movement, true);
    }

    void Movement(Vector2 movement, bool yMovement){
        float distance = movement.magnitude;
        if (distance > minMoveDist){
            int count = rb2d.Cast(movement, contactFilter, hitbuffer, distance + shellRadius);
            hitbufferlist.Clear();
            for (int i = 0; i < count; i++){
                hitbufferlist.Add(hitbuffer[i]);
            }
            for (int i = 0; i < hitbufferlist.Count; i++)
            {
                Vector2 currentNormal = hitbufferlist[i].normal;
                if (currentNormal.y > MinGroundNormalY){
                    grounded = true;
                    if (yMovement){
                        groundNormal = currentNormal; 
                        currentNormal.x = 0;
                    }
                }
                float projection = Vector2.Dot(velocity, currentNormal);
                if (projection < 0){
                    velocity = velocity - projection * currentNormal;
                }
                float modifiedDist = hitbufferlist[i].distance - shellRadius;
                distance = modifiedDist < distance ? modifiedDist : distance; //distance = modifiedDist if distance < modifiedDist otherwise use distance
            } 
        }
        rb2d.position = rb2d.position + movement.normalized * distance;
    }
}
