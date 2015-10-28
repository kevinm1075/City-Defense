using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public Transform[] spawnPoints;
	public static int currentWaveNum = 0;

	void Start () {
	}

	void Spawn(Wave wave)
	{
		for(int i = 0; i < wave.numWaves; i++)
		{
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			Instantiate (wave.getEnemy(i), spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		}
	}

	void Update () 
	{
		if(GameObject.FindGameObjectWithTag("Enemy") == null)
		{
			if(currentWaveNum != WaveList.numWaveList)
			{
				currentWaveNum++;
			}
			if(currentWaveNum < WaveList.numWaveList)
			{
				StartCoroutine(spawnCoroutine(WaveList.waveList[currentWaveNum]));
				//Spawn (WaveList.waveList[currentWaveNum]);
			}
		}
	}

	IEnumerator spawnCoroutine(Wave wave)
	{
		for(int i = 0; i < wave.numWaves; i++)
		{
			int spawnPointIndex = Random.Range (0, spawnPoints.Length);
			Instantiate (wave.getEnemy(i), spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
			yield return new WaitForSeconds(1);
		}
			

	}
}