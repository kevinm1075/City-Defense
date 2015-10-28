using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public int maxHP = 100;
	public int curHP;

	protected Animator avatar;

	void Awake()
	{
		avatar = GetComponent<Animator> ();
		curHP = maxHP;
	}

	public void ModifyHP(int value)
	{
		curHP += value;

		if (curHP >= maxHP)
			curHP = maxHP;
		if (curHP <= 0)
		{
			curHP = 0;
			avatar.Play ("BG_Death", 0);
			GetComponent<MineBot>().enabled = false;
		}
	}
}
