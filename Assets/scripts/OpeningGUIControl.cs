using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OpeningGUIControl : MonoBehaviour {

	public Button play;
	public Button about;
	public Button credits;
	
	private int language;

	// Use this for initialization
	void Start () {
		Debug.Log("starting opening gui control");
		play = play.GetComponent<Button>();
		about = play.GetComponent<Button>();
		credits = play.GetComponent<Button>();
		
		language  =	PlayerPrefs.GetInt("language");
	}
	
	// Quits the player when the user hits escape
	void Update () {
		if (Input.GetKey ("escape")) {
			Application.Quit();
		}
	}
	
	//loads the main stage
	public void LoadGame () {
		if (language == 0) //if is portuguese
			Application.LoadLevel(2);
		else //if is english
			Application.LoadLevel(8);
	}
	
	//loads the about
	public void LoadAbout () {
		if (language == 0) //if is portuguese
			Application.LoadLevel(5);
		else //if is english
			Application.LoadLevel(11);
	}
	
	//loads the aknowledgments
	public void LoadAknowledgements () {
		if (language == 0) //if is portuguese
			Application.LoadLevel(6);
		else //if is english
			Application.LoadLevel(12);
	}
	
	//loads the project website
	public void LoadSite () {
		Application.OpenURL("http://29deabril.net");
	}
}
