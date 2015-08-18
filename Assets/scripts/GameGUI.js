#pragma strict

import UnityEngine.UI;

var professores_feridos:Text;
var professores_salvos:Text;
var tempo_restante:Text;
var pergunta:GameObject;

//var desistencia = 1;

//var music:AudioSource;
//var slowDownFactor = 0.25f;
var tempDeltaTime = 0.0f;

var playerMovements:FPSControlPlayer;

var language;


function Start () {
	Debug.Log("starting game gui control");		
	
	LoadPlayerMovementsAndMusic();
	SlowMo();
	
	Invoke("MakeQuestion", 10);
	
	LoadFadeIn();
	
	language = PlayerPrefs.GetInt("language");
}

function Update () {	
	UpdatesTimer();
	
	if (language==0) {//if it's in portuguese
		professores_feridos.text = Variables.deadNPCs + " professores feridos";
		professores_salvos.text = Variables.npcCounter + " professores entraram na Alep";
		tempo_restante.text = Variables.timer.ToString("F2") + "s restantes para a aprovação das reformas";
		//tempo_restante.text = realTime.ToString("F2") + "s restantes para a aprovação das reformas";
	} else { //if it's in english
		professores_feridos.text = Variables.deadNPCs + " teachers hurt";
		professores_salvos.text = Variables.npcCounter + " teachers accessed the Alep";
		tempo_restante.text = Variables.timer.ToString("F2") + "s left for the reforms' approval";
		//tempo_restante.text = realTime.ToString("F2") + "s restantes para a aprovação das reformas";
	}
	
	
	//in case the player pressed esc
	if (Input.GetKey ("escape")) {
		Application.Quit();
	}
	
	//if the player entered Alep
	if (Variables.endOption==2) {
		NextScene();
	}
}

private function LoadPlayerMovementsAndMusic() {
	var player = GameObject.Find("Player");
	playerMovements = player.GetComponent(FPSControlPlayer);
	//var audios = player.GetComponentsInChildren(AudioSource);
	//music = audios[0];
	//Debug.Log("there are this number of audio files in player: " + audios.Length);
}

//make time goes by slowly
private function SlowMo() {
	Time.timeScale = 0.25;
	Time.fixedDeltaTime = 0.02 * Time.timeScale;
	
	UnlockCamera();
}

//stops the timer
private function Freeze() {
	//pausing the time
	Time.timeScale = 0;
	Time.fixedDeltaTime = 0.02 * Time.timeScale;
	
	LockCamera();
}

//locks the camera so that player doesnt move when paused
private function LockCamera() {
	playerMovements.enabled = false;
}

//gets back to normal
private function UnlockCamera() {
	playerMovements.enabled = true;
}

//unlocks the mouse
private function UnlockMouse() {
	//show and unlock cursor
	Cursor.visible = true;
	Screen.lockCursor = false;
}

//locks the mouse
private function LockMouse() {
	//hidde and lock mouse
	Cursor.visible = false;
	Screen.lockCursor = true;
}

private function MakeQuestion() {
	//se ainda nao matou ninguem 
	if (Variables.deadNPCs==0) { 
		//congela
		Freeze();
		//trava mouse
		UnlockMouse();
		//faz a pergunta
		pergunta.SetActive(true);
		//music.Pause();
	}
}


//in case player says i give up
public function IGiveUp() {
	//i go arrested
	Variables.endOption = 1;
	//disable manu
	pergunta.SetActive(false);
	//slowmo back
	SlowMo();
	//call next scene
	NextScene();
}

//returns to the game and lock the cursor
public function ReturnToGame() {
	pergunta.SetActive(false);
	SlowMo();
	LockMouse();
	//music.Play();
}


//applies fadeout and changes the scene in 1 sec
public function NextScene() {
	LoadFadeOut();
	Invoke("ChangeScene", 1);
	Debug.Log("loading fade out and changing scene...");
}

//uploads essencial info and loads next lovel
private function ChangeScene () {
	PlayerPrefs.SetInt("dead npcs", Variables.deadNPCs);
	PlayerPrefs.SetInt("saved npcs", Variables.npcCounter);
	PlayerPrefs.SetInt("end option", Variables.endOption);
	
	if (language==0) //if it's in portuguese
		Application.LoadLevel(4);
	else //if it's in english
		Application.LoadLevel(10);
}

//calls the fade int
private function LoadFadeIn() {
	//diz que o fadeout comecou
	Variables.fadeInStarted = true;
}

//calls the fade out
private function LoadFadeOut() {
	//diz que o fadeout comecou
	Variables.fadeOutStarted = true;
}

private function HaveNotKilledAnyone() {
	if (Variables.deadNPCs == 0)
		return true;
	else
		return false;
}

//counts how much time is left
private function UpdatesTimer() {
	//if the game is not paused...
	if (Time.deltaTime != 0)
		//updates the deltaTime that will be used in the timer
		tempDeltaTime = Time.deltaTime;
	
	///updates time
	Variables.timer -= tempDeltaTime;	
	
	//Variables.timer -= Time.deltaTime; 
	//Variables.timer -= Time.fixedDeltaTime; 
	//Variables.timer -= (Time.unscaledDeltaTime); 
	
	//if 3s are remaining, call fadeout
	if (Variables.timer < 1 & !Variables.fadeOutStarted) {
		//if i did not kill anyone
		if (HaveNotKilledAnyone())
			//i go arrested
			Variables.endOption = 1;
		//change to next scene
		NextScene();
	}
	
	//if timer is over
	//if (Variables.timer < 0)
	//	NextScene();
}
