using UnityEngine;
using System.Collections;

public class GameGUI : MonoBehaviour {

	public Texture hpTexture;
	public Texture scoreTexture;
	public GUISkin guiSkin;
	public GUIStyle guiStyle = new GUIStyle();

	private GameObject playerObj;

	void Start () 
	{
		playerObj = GameObject.FindGameObjectWithTag ("Player");
	}
	
	void Update () 
	{
	}

	void OnGUI()
	{
		// Obtain Info
		int curHP = playerObj.GetComponent<PlayerHealth> ().curHP;
		int curWave = Spawner.currentWaveNum;

		// Edit GUI Elements
		GUI.skin = guiSkin;
		guiStyle.normal.textColor = Color.white;
		guiStyle.fontSize = 50;

		// Draw HP
		GUI.DrawTexture (new Rect (20, Screen.height - 300, 300, 300), hpTexture);
		GUI.Label (new Rect (114, Screen.height - 165, 0, 0), curHP.ToString ("000"), guiStyle);

		// Draw Score
		GUI.DrawTexture (new Rect (Screen.width - 400, Screen.height/4 - 250, 350, 350), scoreTexture);
		GUI.Label (new Rect (Screen.width - 225, Screen.height/4 - 90, 0, 0), Score.score.ToString("0000"), guiStyle);
		GUI.Label (new Rect (Screen.width - 135, Screen.height/4 - 7, 0, 0), curWave.ToString ("00"), guiStyle);
	}
}
