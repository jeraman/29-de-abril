#pragma strict

import RAIN.Core;


static var _woman1R : GameObject;
static var _woman2R : GameObject;
static var _woman3R : GameObject;
static var _woman4R : GameObject;
static var _man1R : GameObject;
static var _man2R : GameObject;
static var _man3R : GameObject;
static var _man4R : GameObject;
static var _woman1S : GameObject;
static var _woman2S : GameObject;
static var _woman3S : GameObject;
static var _woman4S : GameObject;
static var _man1S : GameObject;
static var _man2S : GameObject;
static var _man3S : GameObject;
static var _man4S : GameObject;


var nRunningClones = 0;
var nStoppedClones = 0;
//var lastNumberOfNPCs = 0;

function Start () {
	Debug.Log("loading character clonner script");
	//total number of running clones
	nRunningClones = 40;
	//total number of stopped clones
	nStoppedClones = 40;
	//aux var to handle update of saved NPCs
	//lastNumberOfNPCs = 0;
	
	//loading the woman prefab (remember to put this inside a resources folder)
	
	//_woman1R = Resources.Load("Mulher_1_Crowd_Unity_Running");
	
	_woman1R = Resources.Load("Mulher1_C");
	_woman2R = Resources.Load("Mulher2_C");
	_woman3R = Resources.Load("Mulher3_C");
	_woman4R = Resources.Load("Mulher4_C");
	_man1R = Resources.Load("Homem1_C");
	_man2R = Resources.Load("Homem2_C");
	_man3R = Resources.Load("Homem3_C");
	_man4R = Resources.Load("Homem4_C");
	
	//_woman1S = Resources.Load("Mulher_1_Crowd_Unity_Stopped");
	
	_woman1S = Resources.Load("Mulher1_P");
	_woman2S = Resources.Load("Mulher2_P");
	_woman3S = Resources.Load("Mulher3_P");
	_woman4S = Resources.Load("Mulher4_P");
	_man1S = Resources.Load("Homem1_P");
	_man2S = Resources.Load("Homem2_P");
	_man3S = Resources.Load("Homem3_P");
	_man4S = Resources.Load("Homem4_P");
	
	//populating the world
	populatingWorld();
	
	//when the music finishes, finishes the game
	//Invoke("NextScene", 155);
}

/*
function Update() {
	//number of new NPCs
	var nNewNpcs = verifyNumberofSavedNPCs();
	
	//if there is no NPCs to be created, return...
	if (nNewNpcs==0) 
		return;
	
	//otherwise...
	var i = 0;
	//creating new NPCs
	for (i = 0;  i < nNewNpcs; i++)
		createRandomRunningChar();
}


function verifyNumberofSavedNPCs() {
	
	//get how many NPCs were saved since last frame
	var temp = Global.npcCounter - lastNumberOfNPCs;
	//updates old number of NPCs
	lastNumberOfNPCs = Global.npcCounter;
	
	return temp;
}
*/

//verifies if there no other NPC around the area
static function verifyIfPositionIsFree(center: Vector3) {
	var collided = Physics.OverlapSphere(center, 0.2);
	return (collided.Length != 0);
}

//generate a position where there is no other NPC
//ATTENTION: this function might generate a infinite loop
static function generateRandomPosition() {
	var newPos:Vector3;
	
	var collided = true;
	while(collided) {
		newPos = new Vector3(Random.Range(200, 220), 0.5, Random.Range(220, 300));
		collided = verifyIfPositionIsFree(newPos);
	}
	
	return newPos;
}

//creates a random running character
static function createRandomRunningChar () {
	var type = 0;
	
	var newPos = generateRandomPosition();
	
	var newChar : GameObject;
	
	type = Random.Range(1, 9);
	//type = 1;
	
	
	if (type == 1) { // se e mulher 1
		newChar = GameObject.Instantiate(_woman1R, newPos, Quaternion.identity);
		newChar.name =  _woman1R.name+" (clone) " + Variables.counter;
	}
	
	if (type == 2) { // se e mulher 2
		newChar = GameObject.Instantiate(_woman2R, newPos, Quaternion.identity);
		newChar.name =  _woman2R.name+" (clone) "+Variables.counter;
	}
	
	if (type == 3) { // se e mulher 3
		newChar = GameObject.Instantiate(_woman3R, newPos, Quaternion.identity);
		newChar.name =  _woman3R.name+" (clone) "+Variables.counter;
	}
	
	if (type == 4) { // se e mulher 4
		newChar = GameObject.Instantiate(_woman4R, newPos, Quaternion.identity);
		newChar.name =  _woman4R.name+" (clone) "+Variables.counter;
	}
	
	if (type == 5) { // se e homem 1
		newChar = GameObject.Instantiate(_man1R, newPos, Quaternion.identity);
		newChar.name =  _man1R.name+" (clone) " + Variables.counter;
	}
	
	if (type == 6) { // se e homem 2
		newChar = GameObject.Instantiate(_man2R, newPos, Quaternion.identity);
		newChar.name =  _man2R.name+" (clone) "+Variables.counter;
	}
	
	if (type == 7) { // se e homem 3
		newChar = GameObject.Instantiate(_man3R, newPos, Quaternion.identity);
		newChar.name =  _man3R.name+" (clone) "+Variables.counter;
	}
	
	if (type == 8) { // se e homem 4
		newChar = GameObject.Instantiate(_man4R, newPos, Quaternion.identity);
		newChar.name =  _man4R.name+" (clone) "+Variables.counter;
	}
	
	Variables.counter = Variables.counter+1;
	Debug.Log("temos" + Variables.counter + " professores");
}


//creates a stoped character
static function createRandomStoppedChar () {
	var type = 0;
	var newPos = generateRandomPosition();
	
	var newChar : GameObject;
	
	type = Random.Range(1, 9);
	//type = 1;
	
	if (type == 1) { // se e mulher 1
		newChar = GameObject.Instantiate(_woman1S, newPos, Quaternion.identity);
		newChar.name =  _woman1S.name+" (clone) " + Variables.counter;
	}
	
	if (type == 2) { // se e mulher 2
		newChar = GameObject.Instantiate(_woman2S, newPos, Quaternion.identity);
		newChar.name =  _woman2S.name+" (clone) "+Variables.counter;
	}
	
	if (type == 3) { // se e mulher 3
		newChar = GameObject.Instantiate(_woman3S, newPos, Quaternion.identity);
		newChar.name =  _woman3S.name+" (clone) "+Variables.counter;
	}
	
	if (type == 4) { // se e mulher 4
		newChar = GameObject.Instantiate(_woman4S, newPos, Quaternion.identity);
		newChar.name =  _woman4S.name+" (clone) "+Variables.counter;
	}
	
	if (type == 5) { // se e homem 1
		newChar = GameObject.Instantiate(_man1S, newPos, Quaternion.identity);
		newChar.name =  _man1S.name+" (clone) " + Variables.counter;
	}
	
	if (type == 6) { // se e homem 2
		newChar = GameObject.Instantiate(_man2S, newPos, Quaternion.identity);
		newChar.name =  _man2S.name+" (clone) "+Variables.counter;
	}
	
	if (type == 7) { // se e homem 3
		newChar = GameObject.Instantiate(_man3S, newPos, Quaternion.identity);
		newChar.name =  _man3S.name+" (clone) "+Variables.counter;
	}
	
	if (type == 8) { // se e homem 4
		newChar = GameObject.Instantiate(_man4S, newPos, Quaternion.identity);
		newChar.name =  _man4S.name+" (clone) "+Variables.counter;
	}
	
	Variables.counter = Variables.counter+1;
	Debug.Log("temos" + Variables.counter + " professores");
}


function populatingWorld () {
	var i  = 0;

	for (i = 0; i < nRunningClones; i++) 
		createRandomRunningChar();
	
	for (i = 0; i < nStoppedClones; i++) 
		createRandomStoppedChar();
}

