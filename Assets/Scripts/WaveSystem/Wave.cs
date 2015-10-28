using UnityEngine;
using System.Collections;

public class Wave{

	public GameObject[] wave;
	public int numWaves;

	public Wave(GameObject[] wave)
	{
		this.wave = wave;
		numWaves = wave.Length;
	}

	public GameObject getEnemy(int num)
	{
		if(num < wave.Length)
		{
			return wave[num];
		}

		return null;
	}
}
