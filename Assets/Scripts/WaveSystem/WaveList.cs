using UnityEngine;
using System.Collections;

public class WaveList
{
	public static Wave[] waveList;
	public static int numWaveList;

	public WaveList(int numWaves)
	{
		waveList = new Wave[numWaves];
		numWaveList = numWaves;
	}

	public void addWave(Wave wave)
	{
		for (int i = 0; i < waveList.Length; i++) 
		{
			if(waveList[i] == null)
			{
				waveList[i] = wave;
				break;
			}
		}
	}
}
