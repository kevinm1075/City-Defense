using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
	public float attackSpeed = 0;
	public float cooldown = 0.5f;
	
	public BoxCollider swordCollider;
	private EnemyHealth enemyHealth;

	void Awake()
	{
		swordCollider = GetComponent<BoxCollider> ();
		swordCollider.isTrigger = false;
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Enemy"))
		  {
			enemyHealth = other.GetComponent<EnemyHealth>();
			enemyHealth.ModifyHP(-35);
			GetComponent<AudioSource>().Play();
			swordCollider.isTrigger = false;
		}
	}

	void Update () 
	{		
		AttackListener ();
	}
	
	private void AttackListener()
	{
		if (attackSpeed == 0) 
			swordCollider.isTrigger = false;
		
		if (attackSpeed > 0) 
		{
			attackSpeed -= Time.deltaTime;
		}
		
		if(attackSpeed < 0)
			attackSpeed = 0;
		
		if(Input.GetButton("Fire1") || Input.GetKey (KeyCode.T))
		{
			if(attackSpeed == 0)
			{
				swordCollider.isTrigger = true;
				attackSpeed = cooldown;
			}
		}
	}
}
