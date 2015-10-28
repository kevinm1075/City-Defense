 using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour 
{
	public Transform player;
	public int moveSpeed = 1;
	public float minDistance;
	private EnemyHealth enemyHealth;
	private Animation _animation;

	void Awake() 
	{
		minDistance = 2.0f;
		enemyHealth = GetComponent <EnemyHealth> ();
		_animation = GetComponent<Animation> ();
		player = GameObject.FindGameObjectWithTag ("Player").transform;
	}

	void Update () 
	{
		if(!_animation.IsPlaying("attack01") && !_animation.IsPlaying("damage02"))
		{
			if (enemyHealth.curHP > 0) 
			{
				// Face Target
				transform.LookAt(player);

				// Advance to target.
				if (Vector3.Distance (transform.position, player.position) > minDistance)
				{
					GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.forward * moveSpeed * Time.deltaTime);
					_animation.Play("run");
				}
			}
		}
	}
}