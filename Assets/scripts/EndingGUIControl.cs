using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EndingGUIControl : MonoBehaviour {
	
	public Text t1A;
	public Text t1Aa;
	public Text t1Ab;
	public Text t1Ac;
	public Text t1B;
	public Text t1Ba;
	public Text t1Bb;
	public Text t1Bc;
	public Text t1C;
	public Text t1Ca;
	public Text t1Cb;
	public Text t1Cc;
	public Text t1Cd;
	public Text t2;
	public Text t3;
	public Text t4;
	public Text t5;
	public Text t6;
	public Text t7;
	public Text t7a;
	public int transition = 1;
	
	private bool isSeventhText = false;
	private int endOption;
	
	private int language;

	// Use this for initialization
	void Start () {	
		Debug.Log("ending opening gui control");
		
		//language  =	PlayerPrefs.GetInt("language");
		language = 1;
		
		//back to normal time
		Time.timeScale = 1.0f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
		
		//show and unlock cursor
		Cursor.visible = true;
		Screen.lockCursor = false;
		
		//updates player scores
		UpdatePlayerScores();
		
		BlackScreen();
		LoadFirstText();		
		Invoke("UnloadFirstText", 8-transition);
		Invoke("LoadSecondText", 8);
		Invoke("UnloadSecondText", 22-transition);
		Invoke("LoadThirdText", 22);
		Invoke("UnloadThirdText", 37-transition);
		Invoke("LoadFourthText", 37);
		Invoke("UnloadFourthText", 47-transition);
		Invoke("LoadFifthText", 47);	
		Invoke("UnloadFifthText", 65-transition);
		Invoke("LoadSixthText", 65);	
		Invoke("UnloadSixthText", 80-transition);
		Invoke("LoadSeventhText", 80);	
		Invoke("UnloadSeventhText", 90-transition);
		Invoke("LoadNextScenario", 90);	
	}
	
	
	void Update() {
		 if (Input.GetMouseButtonDown (0) & !isSeventhText) {
			Debug.Log("mouse down!");
	 		UnloadFirstText();
	 		UnloadSecondText();
	 		UnloadThirdText();
	 		UnloadFourthText();
	 		UnloadFifthText();
	 		UnloadSixthText();
	 		UnloadSeventhText();
	        LoadNextScenario();
		 }
		 
 		if (Input.GetKey ("escape")) {
 			Application.Quit();
 		}
	}
	
	void UpdatePlayerScores() {
		//getting the right values
		var deadNPCs  =	PlayerPrefs.GetInt("dead npcs");
		var savedNPCs = PlayerPrefs.GetInt("saved npcs");
		endOption     = PlayerPrefs.GetInt("end option");

		Debug.Log("idioma: " + language);
		
		if (language == 0) { //if is portuguese			
			//displaying right results
			t1Aa.text = deadNPCs + " professores fsdseridos";
			t1Ab.text = savedNPCs + " professores conseguiram entrar na Alep";
		} else { //if it is in english
			t1Aa.text = deadNPCs + " teachers hurt";
			t1Ab.text = savedNPCs + " teachers accessed the Alep";
		}
		
	}
	
	void BlackScreen() {
		t1A.CrossFadeAlpha (0, 0, false);
		t1Aa.CrossFadeAlpha(0, 0, false);
		t1Ab.CrossFadeAlpha(0, 0, false);
		t1Ac.CrossFadeAlpha(0, 0, false);
		t1B.CrossFadeAlpha (0, 0, false);
		t1Ba.CrossFadeAlpha(0, 0, false);
		t1Bb.CrossFadeAlpha(0, 0, false);
		t1Bc.CrossFadeAlpha(0, 0, false);
		t1C.CrossFadeAlpha (0, 0, false);
		t1Ca.CrossFadeAlpha(0, 0, false);
		t1Cb.CrossFadeAlpha(0, 0, false);
		t1Cc.CrossFadeAlpha(0, 0, false);
		t1Cd.CrossFadeAlpha(0, 0, false);
		t2.CrossFadeAlpha (0, 0, false);
		t3.CrossFadeAlpha (0, 0, false);
		t4.CrossFadeAlpha (0, 0, false);	
		t5.CrossFadeAlpha (0, 0, false);
		t6.CrossFadeAlpha (0, 0, false);
		t7.CrossFadeAlpha (0, 0, false);
		t7a.CrossFadeAlpha (0, 0, false);
		t7a.enabled = false;
	}
	
	void LoadFirstText() {
		Debug.Log("Loading first text");
		
		if (endOption == 0) { //se o jogador cumpriu a missão...
			t1A.CrossFadeAlpha (1, transition, false);
			t1Aa.CrossFadeAlpha(1, transition, false);
			t1Ab.CrossFadeAlpha(1, transition, false);
			t1Ac.CrossFadeAlpha(1, transition, false);
		}
		if (endOption == 1) { //se o jogador se recusou a cumprir a missão...
			t1B.CrossFadeAlpha (1, transition, false);
			t1Ba.CrossFadeAlpha(1, transition, false);
			t1Bb.CrossFadeAlpha(1, transition, false);
			t1Bc.CrossFadeAlpha(1, transition, false);
		}
		if (endOption == 2) { //se o jogador se juntou aos manifestantes...
			t1C.CrossFadeAlpha (1, transition, false);
			t1Ca.CrossFadeAlpha(1, transition, false);
			t1Cb.CrossFadeAlpha(1, transition, false);
			t1Cc.CrossFadeAlpha(1, transition, false);
			t1Cd.CrossFadeAlpha(1, transition, false);
		}
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
	
	void UnloadFirstText() {
		Debug.Log("Unloading first text");
		t1A.CrossFadeAlpha (0, transition, false);
		t1Aa.CrossFadeAlpha(0, transition, false);
		t1Ab.CrossFadeAlpha(0, transition, false);
		t1Ac.CrossFadeAlpha(0, transition, false);
		t1B.CrossFadeAlpha (0, transition, false);
		t1Ba.CrossFadeAlpha(0, transition, false);
		t1Bb.CrossFadeAlpha(0, transition, false);
		t1Bc.CrossFadeAlpha(0, transition, false);
		t1C.CrossFadeAlpha (0, transition, false);
		t1Ca.CrossFadeAlpha(0, transition, false);
		t1Cb.CrossFadeAlpha(0, transition, false);
		t1Cc.CrossFadeAlpha(0, transition, false);
		t1Cd.CrossFadeAlpha(0, transition, false);
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
	
	void UnloadSixthText() {
		Debug.Log("Unloading sixth text");
		t6.CrossFadeAlpha(0, transition, false);
	}
	
	void UnloadSeventhText() {
		Debug.Log("Unloading seventh text");
		t7.CrossFadeAlpha(0, transition, false);
		//t7a.CrossFadeAlpha(0, transition, false);
	}
	
	void LoadNextScenario() {
		Debug.Log("loading next scenario");
		if (language == 0) //if is portuguese
			Application.LoadLevel(1);
		else //if it is english
			Application.LoadLevel(7);
	}
	
	public void LoadDocumentary() {
		 Application.OpenURL("https://www.youtube.com/watch?v=9s-wZCUAvL4");
	}
	
}