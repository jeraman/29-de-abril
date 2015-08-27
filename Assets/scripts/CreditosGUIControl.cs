using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CreditosGUIControl : MonoBehaviour {

	public Text t1a;
	public Text t1b;
	public Text t2a;
	public Text t2b;
	public Text t3a;
	public Text t3b;
	public Text t4a;
	public Text t4b;
	public Text t5a;
	public Text t5b;
	public Text t6a;
	public Text t6b;
	public Text t7a;
	public Text t7b;
	public Text t8a;
	public Text t8b;
	public Text t9;

	public int transition = 1;
	
	private int language;

	// Use this for initialization
	void Start () {
		Debug.Log("starting creditos gui control");
		//back to normal time
		Time.timeScale = 1.0f;
		Time.fixedDeltaTime = 0.02f * Time.timeScale;
		
		//show and unlock cursor
		Cursor.visible = true;
		Screen.lockCursor = false;
		
		BlackScreen();
		LoadFirstText();		
		Invoke("UnloadFirstText", 5-transition);
		Invoke("LoadSecondText", 5);
		Invoke("UnloadSecondText", 15-transition);
		Invoke("LoadThirdText", 15);
		Invoke("UnloadThirdText", 20-transition);
		Invoke("LoadFourthText", 20);
		Invoke("UnloadFourthText", 30-transition);
		Invoke("LoadFifthText", 30);	
		Invoke("UnloadFifthText", 35-transition);
		Invoke("LoadSixthText", 35);	
		Invoke("UnloadSixthText", 45-transition);
		Invoke("LoadSeventhText", 45);	
		Invoke("UnloadSeventhText", 50-transition);
		Invoke("LoadEigthText", 50);	
		Invoke("UnloadEigthText", 55-transition);
		Invoke("LoadNinethText", 55);	
		Invoke("UnloadNinethText", 60-transition);
		Invoke("LoadNextScenario", 60);
		
		language  =	PlayerPrefs.GetInt("language");	
	}
	
	
	void Update() {
		 if (Input.GetMouseButtonDown (0)) {
			Debug.Log("mouse down!");
	 		UnloadFirstText();
	 		UnloadSecondText();
	 		UnloadThirdText();
	 		UnloadFourthText();
	 		UnloadFifthText();
	 		UnloadSixthText();
	 		UnloadSeventhText();
	 		UnloadEigthText();		
		 	UnloadNinethText();
	        LoadNextScenario();
		 }
		 
 		if (Input.GetKey ("escape")) {
 			Application.Quit();
 		}
	}
	
	void BlackScreen() {
		t1a.CrossFadeAlpha(0, 0, false);
		t1b.CrossFadeAlpha(0, 0, false);
		t2a.CrossFadeAlpha(0, 0, false);
		t2b.CrossFadeAlpha(0, 0, false);
		t3a.CrossFadeAlpha(0, 0, false);
		t3b.CrossFadeAlpha(0, 0, false);
		t4a.CrossFadeAlpha(0, 0, false);	
		t4b.CrossFadeAlpha(0, 0, false);
		t5a.CrossFadeAlpha(0, 0, false);
		t5b.CrossFadeAlpha(0, 0, false);
		t6a.CrossFadeAlpha(0, 0, false);
		t6b.CrossFadeAlpha(0, 0, false);
		t7a.CrossFadeAlpha(0, 0, false);
		t7b.CrossFadeAlpha(0, 0, false);
		t8a.CrossFadeAlpha(0, 0, false);
		t8b.CrossFadeAlpha(0, 0, false);
		t9.CrossFadeAlpha (0, 0, false);

	}
	
	void LoadFirstText() {
		Debug.Log("Loading first text");
		t1a.CrossFadeAlpha(1, transition, false);
		t1b.CrossFadeAlpha(1, transition, false);
	}
	
	void LoadSecondText() {
		Debug.Log("Loading second text");
		t2a.CrossFadeAlpha(1, transition, false);
		t2b.CrossFadeAlpha(1, transition, false);
	}
	
	void LoadThirdText() {
		Debug.Log("Loading third text");
		t3a.CrossFadeAlpha(1, transition, false);
		t3b.CrossFadeAlpha(1, transition, false);
	}
	
	void LoadFourthText() {
		Debug.Log("Loading forth text");
		t4a.CrossFadeAlpha(1, transition, false);
		t4b.CrossFadeAlpha(1, transition, false);
	}
	
	void LoadFifthText() {
		Debug.Log("Loading fifth text");
		t5a.CrossFadeAlpha(1, transition, false);
		t5b.CrossFadeAlpha(1, transition, false);
	}
	
	void LoadSixthText() {
		Debug.Log("Loading sixth text");
		t6a.CrossFadeAlpha(1, transition, false);
		t6b.CrossFadeAlpha(1, transition, false);
	}
	
	void LoadSeventhText() {
		Debug.Log("Loading seventh text");
		t7a.CrossFadeAlpha(1, transition, false);
		t7b.CrossFadeAlpha(1, transition, false);
	}
	
	void LoadEigthText() {
		Debug.Log("Loading eigth text");
		t8a.CrossFadeAlpha(1, transition, false);
		t8b.CrossFadeAlpha(1, transition, false);
	}
	
	void LoadNinethText() {
		Debug.Log("Loading nineth text");
		t9.CrossFadeAlpha(1, transition, false);
	}

	void UnloadFirstText() {
		Debug.Log("Unloading first text");
		t1a.CrossFadeAlpha(0, transition, false);
		t1b.CrossFadeAlpha(0, transition, false);
	}
	
	void UnloadSecondText() {
		Debug.Log("Unloading second text");
		t2a.CrossFadeAlpha(0, transition, false);
		t2b.CrossFadeAlpha(0, transition, false);
	}
	
	void UnloadThirdText() {
		Debug.Log("Unloading third text");
		t3a.CrossFadeAlpha(0, transition, false);
		t3b.CrossFadeAlpha(0, transition, false);
	}
	
	void UnloadFourthText() {
		Debug.Log("Unloading forth text");
		t4a.CrossFadeAlpha(0, transition, false);
		t4b.CrossFadeAlpha(0, transition, false);
	}
	
	void UnloadFifthText() {
		Debug.Log("Unloading fifth text");
		t5a.CrossFadeAlpha(0, transition, false);
		t5b.CrossFadeAlpha(0, transition, false);
	}
	
	void UnloadSixthText() {
		Debug.Log("Unloading sixth text");
		t6a.CrossFadeAlpha(0, transition, false);
		t6b.CrossFadeAlpha(0, transition, false);
	}
	
	void UnloadSeventhText() {
		Debug.Log("Unloading seventh text");
		t7a.CrossFadeAlpha(0, transition, false);
		t7b.CrossFadeAlpha(0, transition, false);
	}
	
	void UnloadEigthText() {
		Debug.Log("Unloading eigth text");
		t8a.CrossFadeAlpha(0, transition, false);
		t8b.CrossFadeAlpha(0, transition, false);
	}
	
	void UnloadNinethText() {
		Debug.Log("Unloading nineth text");
		t9.CrossFadeAlpha(0, transition, false);
	}

	void LoadNextScenario() {
		Debug.Log("loading next scenario");
		if (language == 0) //if is portuguese
			Application.LoadLevel(1);
		else //if it is english
			Application.LoadLevel(7);
	}
	
	//public void LoadDocumentary() {
	//	 Application.OpenURL("https://www.youtube.com/watch?v=9s-wZCUAvL4");
	//}
}
