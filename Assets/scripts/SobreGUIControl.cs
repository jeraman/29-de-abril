using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SobreGUIControl : MonoBehaviour {
	
	public Text t1;
	//public Text t1a;
	//public Text t1b;
	//public Text t1c;
	public Text t2;
	public Text t3;
	public Text t4;
	public Text t5;
	//public Text t6;
	//public Text t7;
	//public Text t7a;
	public int transition = 1;
	
	private int language;
	
	//private bool isSeventhText = false;

	// Use this for initialization
	void Start () {
		Debug.Log("starting sobre gui control");
		
		//back to normal time
		Time.timeScale = 1.0f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
		
		//show and unlock cursor
		Cursor.visible = true;
		Screen.lockCursor = false;
		
		//updates player scores
		//UpdatePlayerScores();
		
		BlackScreen();
		LoadFirstText();		
		Invoke("UnloadFirstText", 8-transition);
		Invoke("LoadSecondText", 8);
		Invoke("UnloadSecondText", 24-transition);
		Invoke("LoadThirdText", 24);
		Invoke("UnloadThirdText", 34-transition);
		Invoke("LoadFourthText", 34);
		Invoke("UnloadFourthText", 50-transition);
		Invoke("LoadFifthText", 50);	
		Invoke("UnloadFifthText", 60-transition);
		/*
		Invoke("LoadSixthText", 65);	
		Invoke("UnloadSixthText", 80-transition);
		Invoke("LoadSeventhText", 80);	
		Invoke("UnloadSeventhText", 90-transition);
		
		*/
		Invoke("LoadNextScenario", 60);	
		
		language  =	PlayerPrefs.GetInt("language");
	}
	
	
	void Update() {
		 if (Input.GetMouseButtonDown (0)) {
			//Debug.Log("mouse down!");
	 		UnloadFirstText();
	 		UnloadSecondText();
	 		UnloadThirdText();
	 		UnloadFourthText();
	 		UnloadFifthText();
	 		//UnloadSixthText();
	 		//UnloadSeventhText();
	        LoadNextScenario();
		 }
		 
 		if (Input.GetKey ("escape")) {
 			Application.Quit();
 		}
	}
	
	/*
	void UpdatePlayerScores() {
		//getting the right values
		var deadNPCs  =	PlayerPrefs.GetInt("dead npcs");
		var savedNPCs = PlayerPrefs.GetInt("saved npcs");
		//displaying right results
		t1a.text = deadNPCs + " professores feridos";
		t1b.text = savedNPCs + " professores conseguiram entrar na Alep";
	}
	*/
	
	void BlackScreen() {
		t1.CrossFadeAlpha (0, 0, false);
		//t1a.CrossFadeAlpha(0, 0, false);
		//t1b.CrossFadeAlpha(0, 0, false);
		//t1c.CrossFadeAlpha(0, 0, false);
		t2.CrossFadeAlpha (0, 0, false);
		t3.CrossFadeAlpha (0, 0, false);
		t4.CrossFadeAlpha (0, 0, false);	
		t5.CrossFadeAlpha (0, 0, false);
		//t6.CrossFadeAlpha (0, 0, false);
		//t7.CrossFadeAlpha (0, 0, false);
		//t7a.CrossFadeAlpha (0, 0, false);
		//t7a.enabled = false;
	}
	
	void LoadFirstText() {
		Debug.Log("Loading first text");
		t1.CrossFadeAlpha (1, transition, false);
		//t1a.CrossFadeAlpha(1, transition, false);
		//t1b.CrossFadeAlpha(1, transition, false);
		//t1c.CrossFadeAlpha(1, transition, false);
	}
	
	void LoadSecondText() {
		Debug.Log("Loading second text");
		t2.CrossFadeAlpha(1, transition, false);
	}
	
	void LoadThirdText() {
		Debug.Log("Loading third text");
		t3.CrossFadeAlpha(1, transition, false);
	}
	
	void LoadFourthText() {
		Debug.Log("Loading forth text");
		t4.CrossFadeAlpha(1, transition, false);
	}
	
	
	void LoadFifthText() {
		Debug.Log("Loading fifth text");
		t5.CrossFadeAlpha(1, transition, false);
	}
	/*
	void LoadSixthText() {
		Debug.Log("Loading sixth text");
		t6.CrossFadeAlpha(1, transition, false);
	}
	
	void LoadSeventhText() {
		Debug.Log("Loading seventh text");
		isSeventhText = true;
		t7a.enabled = true;
		t7.CrossFadeAlpha(1, transition, false);
		t7a.CrossFadeAlpha(1, transition, false);
	}
	*/
	
	void UnloadFirstText() {
		Debug.Log("Unloading first text");
		t1.CrossFadeAlpha (0, transition, false);
		//t1a.CrossFadeAlpha(0, transition, false);
		//t1b.CrossFadeAlpha(0, transition, false);
		//t1c.CrossFadeAlpha(0, transition, false);
	}
	
	void UnloadSecondText() {
		Debug.Log("Unloading second text");
		t2.CrossFadeAlpha(0, transition, false);
	}
	
	void UnloadThirdText() {
		Debug.Log("Unloading third text");
		t3.CrossFadeAlpha(0, transition, false);
	}
	
	void UnloadFourthText() {
		Debug.Log("Unloading fourth text");
		t4.CrossFadeAlpha(0, transition, false);
	}
	
	
	void UnloadFifthText() {
		Debug.Log("Unloading fifth text");
		t5.CrossFadeAlpha(0, transition, false);
	}
	/*
	void UnloadSixthText() {
		Debug.Log("Unloading sixth text");
		t6.CrossFadeAlpha(0, transition, false);
	}
	
	void UnloadSeventhText() {
		Debug.Log("Unloading seventh text");
		t7.CrossFadeAlpha(0, transition, false);
		//t7a.CrossFadeAlpha(0, transition, false);
	}
	
	public void LoadDocumentary() {
		 Application.OpenURL("https://www.youtube.com/watch?v=9s-wZCUAvL4");
	}
	*/
	
	void LoadNextScenario() {
		Debug.Log("loading next scenario");
		if (language == 0) //if is portuguese
			Application.LoadLevel(1);
		else //if it is english
			Application.LoadLevel(7);
	}
	
}
