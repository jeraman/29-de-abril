using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpeningGUIControl : MonoBehaviour {

	public Button play;
	public Button about;
	public Button credits;

	// Use this for initialization
	void Start () {
		Debug.Log("starting opening gui control");
		play = play.GetComponent<Button>();
		about = play.GetComponent<Button>();
		credits = play.GetComponent<Button>();
	}
	
	// Quits the player when the user hits escape
	void Update () {
		if (Input.GetKey ("escape")) {
			Application.Quit();
		}
	}
	
	//loads the main stage
	public void LoadGame () {
		Application.LoadLevel(1);
	}
	
	//loads the about
	public void LoadAbout () {
		Application.LoadLevel(4);
	}
	
	//loads the aknowledgments
	public void LoadAknowledgements () {
		Application.LoadLevel(5);
	}
	
	//loads the project website
	public void LoadSite () {
		Application.OpenURL("http://29deabril.net");
	}
}
