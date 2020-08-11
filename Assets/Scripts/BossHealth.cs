using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

	public int health = 100;
    public float thrust = 3;
    Rigidbody2D rb2d;

    public void Start(){
        rb2d = this.GetComponent<Rigidbody2D>();
    }

	public void TakeDamage(int damage)
	{

		health -= damage;
		GetComponent<Animator>().Play("KinguSlimu_Hurt");
        
        rb2d.AddForce(transform.right * -thrust);

		if (health <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		GetComponent<Animator>().Play("KinguSlimu_Die");
		Destroy(gameObject);
	}

}
