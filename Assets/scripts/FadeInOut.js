#pragma strict


// FadeInOut

var fadeTexture : Texture2D;
var fadeSpeed = 10;
var drawDepth = -1000;

//private var alpha = 1.0; 
private var alpha = 0.0; 
private var fadeDir = 1;
private var isFirstFadeInFrame = true;
private var isFirstFadeOutFrame = true;


function OnGUI() {
	//if fade started
	
	if (Variables.fadeInStarted) {
		//if this is the fisrt fade in frame
		if (isFirstFadeInFrame) 
			//set up variables
			SetUpFadeIn();
		//perform fade in 
		Fade();
	}
	
	//if fade started
	if (Variables.fadeOutStarted) {
		//if this is the fisrt fade frame
		if (isFirstFadeOutFrame)
			//set up variables 
			SetUpFadeOut();
		//perform fade
		Fade();
	}
}

function SetUpFadeIn() {
	alpha = 1.0;
	fadeDir = -1;
	isFirstFadeInFrame = false;
}

function SetUpFadeOut() {
	alpha = 0.0;
	fadeDir = 1;
	isFirstFadeOutFrame = false;
}

function Fade(){
    alpha += fadeDir * fadeSpeed * Time.deltaTime;  
    alpha = Mathf.Clamp01(alpha);   
    GUI.color.a = alpha;
    GUI.depth = drawDepth;
	GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), fadeTexture);
}
