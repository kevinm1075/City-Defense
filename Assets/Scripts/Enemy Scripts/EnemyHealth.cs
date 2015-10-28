using UnityEngine;
using System.Collections;

public class EnemyHealth : MonoBehaviour 
{
	public int curHP;
	public int startHP = 100;
	public int scoreValue = 100;
	
	private EnemyAttack enemyAttack;

	void Awake()
	{
		curHP = startHP;
		enemyAttack = GetComponent<EnemyAttack> ();
	}
	
	public void ModifyHP(int value)
	{
		GetComponent<Animation>().Play("damage02");
		enemyAttack.attackSpeed += 2;

		curHP += value;

		if (curHP <= 0)
		{
			Destroy(GetComponent<BoxCollider> ());
			Destroy(GetComponent<Rigidbody>());
			Score.score += scoreValue;

			GetComponent<Animation>().Play("death");
			StartCoroutine(deathCoroutine());
		}
	}

	private void Death()
	{
		Destroy (gameObject);
	}
	
	IEnumerator deathCoroutine()
	{
		yield return new WaitForSeconds(5);
		Death ();
	}
}