using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeScript : Enemy
{
    public int idlespeed = 5;
    float followr = 5;
    public int contactdmg = 5;
    public int hp = 10;
    private Rigidbody2D rb2d;
    [SerializeField] Transform playerTransform;
    public GameObject player;
    [SerializeField]Animator slimeAnim;
    SpriteRenderer enemySR;
    void Start(){
        playerTransform = player.GetComponent<Transform>();
        slimeAnim = gameObject.GetComponent<Animator>();
        setSpeed(idlespeed);
        setContactDamage(contactdmg);
        setHP(hp);
        setFollowRadius(followr);
    }

    void Awake ()
    {
        rb2d = GetComponent<Rigidbody2D> ();
        setSpeed(idlespeed);

    }

    // Update is called once per frame
    void Update()
    {
        if (checkFollowRadius(playerTransform.position.x,transform.position.x))
        {
            if (playerTransform.position.x < transform.position.x)
            {
                this.transform.position += new Vector3(-getSpeed() * Time.deltaTime, 0f, 0f);
                slimeAnim.SetBool("Walking", true);
                enemySR.flipX = true;
            }
            else if(playerTransform.position.x > transform.position.x)
            {
                this.transform.position += new Vector3(getSpeed() * Time.deltaTime, 0f, 0f);
                slimeAnim.SetBool("Walking", true);
                enemySR.flipX = false;
            }
        }
    }
}
