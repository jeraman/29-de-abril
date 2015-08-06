using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PresentationGUIControl : MonoBehaviour {
	
	public Text t1;
	public Text t2;
	public Text t3;
	public Text t3emeio;
	public Text t4;
	public Image instrucoes;
	public int transition = 1;

	// Use this for initialization
	void Start () {
		Debug.Log("presentation opening gui control");
		
		BlackScreen();
		LoadFirstText();		
		Invoke("UnloadFirstText", 8-transition);
		Invoke("LoadSecondText", 8);
		Invoke("UnloadSecondText", 20-transition);
		Invoke("LoadThirdText", 20);
		Invoke("UnloadThirdText", 30-transition);
		Invoke("LoadFourthText", 30);
		Invoke("UnloadFourthText", 40-transition);
		Invoke("ShowInstructions", 40);
		Invoke("LoadNextScenario", 43);	
	}
	
	void Update() {
		 if (Input.GetMouseButtonDown (0)) {
			Debug.Log("mouse down!");
	 		UnloadFirstText();
	 		UnloadSecondText();
	 		UnloadThirdText();
	 		UnloadFourthText();
	        LoadNextScenario();
		 }
		 
 		if (Input.GetKey ("escape")) {
 			Application.Quit();
 		}
	}
	
	void BlackScreen() {
		t1.CrossFadeAlpha(0, 0, false);
		t2.CrossFadeAlpha(0, 0, false);
		t3.CrossFadeAlpha(0, 0, false);
		t3emeio.CrossFadeAlpha(0, 0, false);
		t4.CrossFadeAlpha(0, 0, false);	
		instrucoes.enabled = false;
	}
	
	void LoadFirstText() {
		Debug.Log("Loading first text");
		t1.CrossFadeAlpha(1, transition, false);
	}
	
	void LoadSecondText() {
		Debug.Log("Loading first text");
		t2.CrossFadeAlpha(1, transition, false);
	}
	
	void LoadThirdText() {
		Debug.Log("Loading first text");
		t3.CrossFadeAlpha(1, transition, false);
		t3emeio.CrossFadeAlpha(1, transition, false);
	}
	
	void LoadFourthText() {
		Debug.Log("Loading first text");
		t4.CrossFadeAlpha(1, transition, false);
	}
	
	void UnloadFirstText() {
		Debug.Log("Unloading first text");
		t1.CrossFadeAlpha(0, transition, false);
	}
	
	void UnloadSecondText() {
		Debug.Log("Unloading first text");
		t2.CrossFadeAlpha(0, transition, false);
	}
	
	void UnloadThirdText() {
		Debug.Log("Unloading first text");
		t3.CrossFadeAlpha(0, transition, false);
		t3emeio.CrossFadeAlpha(0, transition, false);
	}
	
	void UnloadFourthText() {
		Debug.Log("Unloading first text");
		t4.CrossFadeAlpha(0, transition, false);
	}
	
	void LoadNextScenario() {
		Debug.Log("loading next scenario");
		Application.LoadLevel(2);
	}
	
	void ShowInstructions () {
		instrucoes.enabled = true;
	}

	/*
	void OnMouseDown () {
		Debug.Log("mouse down!");
		UnloadFirstText();
		UnloadSecondText();
		UnloadThirdText();
		UnloadFourthText();
        LoadNextScenario();
    }*/
	
}