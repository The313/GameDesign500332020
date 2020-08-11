using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCombat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public float attackrange = 0.5f;
    public Transform specialPoint;
    public float specialrange = 0.5f;
    public LayerMask Enemylayers;

    public float nextattack = 0f;
    public float Timestamp;
    public bool canHeal = true;
    
    
    protected Rigidbody2D rb2D;
    public GameObject respawnMenuUI;
    // Update is called once per frame

    void Start(){
        rb2D = GetComponent<Rigidbody2D> ();
    }
    void Update()
    {   
        GameObject go = GameObject.Find("PlayerData");
        if (go == null){
            Debug.LogError("failed to find playerdata");
            this.enabled = false;
            return;
        }
        PlayerData pd = go.GetComponent<PlayerData>();

        if (Time.time >= nextattack){
            if (Input.GetMouseButton(0)){
                Attack(pd.GetBaseDamage());
                nextattack = Time.time + 1f / pd.GetAttackSpeed();
                pd.EnemyHit();
            }
        }
        
        if(Input.GetMouseButtonDown(1)){
            Debug.Log("Right Click registered");
            Block();
        }
        if (Input.GetMouseButtonUp(1)){
            Debug.Log("Right click released");
            UnBlock();
        }
        if (Input.GetKey(KeyCode.R) && pd.GetSpecialMeter() > 100){
            Special(pd.GetSpecialDamage());
            pd.ResetSpecialMeter();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1) && canHeal){
            pd.heal();
            Timestamp = Time.time + 10;
            canHeal = false;
        }
        if (Time.time <= Timestamp){
            canHeal = true;
        }
    }

    void Attack(int basedamage){
        //Atk anim
        animator.Play("Player_Swing");
        //Detect enemies in range of attack
        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(attackPoint.position, attackrange, Enemylayers);
        //Deals damage
        foreach(Collider2D enemy in hitEnemies){
            Debug.Log("Enemy Hit: " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(basedamage);
        }
    }

    void Block(){
        //Block anim
        animator.SetBool("IsRMB",true);
        rb2D.velocity = new Vector2(0,0);
    }
    void UnBlock(){
        //Block anim
        animator.SetBool("IsRMB",false);
    }
    void Special(int specialDamage){
        animator.Play("Player_Special");
        Collider2D[] hitEnemies =  Physics2D.OverlapCircleAll(specialPoint.position, specialrange, Enemylayers);
        foreach(Collider2D enemy in hitEnemies){
            Debug.Log("Enemy Hit with special: " + enemy.name);
            enemy.GetComponent<Enemy>().TakeDamage(specialDamage);
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Enemy")){
            animator.Play("Player_Damaged");
            TakeDamage(other.GetComponent<Enemy>().getContactDamage());
        }
        else if(other.gameObject.CompareTag("King Slime")){
            animator.Play("Player_Damaged");
            TakeDamage(20);
        }

    }
    public void TakeDamage(int damage){
        int Health = PlayerData.GetInstance().GetcurrHP();
        Health -= damage;
        if (Health < 0){
            Die();
        }
        PlayerData.GetInstance().SetcurrHP(Health);
    }
    void Die(){
        animator.Play("Player_Death");
        this.gameObject.SetActive(false);
        respawnMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    void OnDrawGizmosSelected(){
        if(attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position,attackrange);
    }
    //
}
