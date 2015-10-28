	using UnityEngine;
using System.Collections;

public class EnemyAttack : MonoBehaviour 
{
	public GameObject target;
	public float attackSpeed = 0;
	public float cooldown = 2.0f;
	public int damage;

	public EnemyHealth _enemyHealth;
	private Animation _animation;
	public BoxCollider armCollider;

	void Awake()
	{
		target = GameObject.FindGameObjectWithTag ("Player");
		_enemyHealth = GetComponent <EnemyHealth> ();
		_animation = GetComponent<Animation> ();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("Player"))
		{
			armCollider.isTrigger = false;
			other.GetComponent<PlayerHealth>().ModifyHP(damage);
		}
	}
	void Update () 
	{
		if(!_animation.IsPlaying("attack01"))
		{
			armCollider.isTrigger = false;
		}
		if(attackSpeed > 0)
		{
			attackSpeed -= Time.deltaTime;
		}
		
		if(attackSpeed < 0)
		{
			attackSpeed = 0;
		}

		if(attackSpeed == 0)
		{
			Attack();
			attackSpeed = cooldown;
		}
	}
	
	void Attack()
	{
		float distance = Vector3.Distance (target.transform.position, transform.position);
		
		Vector3 dir = (target.transform.position - transform.position).normalized;
		float direction = Vector3.Dot (dir, transform.forward);

		if (_enemyHealth.curHP > 0) 
		{
			if (distance <= 2) 
			{
				if (direction > 0) 
				{
					armCollider.isTrigger = true;
					_animation.Play ("attack01");
				}	
			}
		}
	}
}
