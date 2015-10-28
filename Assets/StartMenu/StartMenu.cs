using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

	public string menuName = null;
	public AudioClip mouseOverSound;
	bool over;

	void OnMouseEnter()
	{
		over = true;
		GetComponent<AudioSource>().PlayOneShot (mouseOverSound);
		GetComponent<AudioSource>().Play();
		GetComponent<TextMesh> ().color = Color.white;
		menuName = GetComponent<TextMesh> ().text;
	}

	void OnMouseExit()
	{
		over = false;
		GetComponent<TextMesh> ().color = Color.black;
		menuName = null;
	}

	void Update()
	{
		if (over) 
		{
			GetComponent<AudioSource>().PlayOneShot(mouseOverSound);
		}
		if (Input.GetMouseButtonDown (0)) 
		{
			switch(menuName)
			{
				case "play":
					Application.LoadLevel(1);
					break;
				case "quit":
					Application.Quit();
					break;	
				default:
					break;
			}
		}
	}
}
