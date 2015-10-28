using UnityEngine;
using System.Collections;

public class GameControl : MonoBehaviour {

	public GameObject zombieObject;
	public Wave[] theList;

	void Start () {
		theList = WaveList.waveList;

		int numWaves = 4;
		WaveList waveList = new WaveList (numWaves);

		GameObject[] waveOneInt = {null};
		GameObject[] waveTwoInt = {zombieObject};
		GameObject[] waveThreeInt = {zombieObject, zombieObject, zombieObject};
		GameObject[] waveFourInt = {zombieObject, zombieObject, zombieObject,zombieObject,zombieObject};

		Wave waveOne = new Wave (waveOneInt);
		Wave waveTwo = new Wave (waveTwoInt);
		Wave waveThree = new Wave (waveThreeInt);
		Wave waveFour = new Wave (waveFourInt);

		waveList.addWave (waveOne);
		waveList.addWave (waveTwo);
		waveList.addWave (waveThree);
		waveList.addWave (waveFour);
	}
	
	void Update () {
	
	}
}
