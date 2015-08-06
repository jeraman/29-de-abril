#pragma strict

//var that store how many NPCs reached the target
static var npcCounter = 0;
//var that stores how many NPCs are dead;
static var deadNPCs = 0;
//how many characters there are in the world
static var counter = 0;
//passes the final result of the game
static var endOption = 0;
//stores if you still can join the teachers. if you shot someone this is set to false
static var canEnterAlep = true;
//keeps track of how much time is left
static var timer = 37.0;

//variables that handles fade in/out
static var fadeOutStarted = false;
static var fadeInStarted  = true;

function Start() {
	npcCounter = 0;
	deadNPCs   = 0;
	counter    = 0;
	timer      = 38.0;
	fadeOutStarted = false;
	fadeInStarted  = true;
}

function Update () {
    if(Input.GetKeyDown("escape")) {//When a key is pressed down it see if it was the escape key if it was it will execute the code
        Application.Quit(); // Quits the game
    }
}