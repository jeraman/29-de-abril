#pragma strict


//var that stores where is the enemy
var enemyLayer;
//var that stores the player layer
var playerLayer;

function Start() {
	//getting the enemy layer
	enemyLayer = LayerMask.NameToLayer("Enemy");
	//getting the player layer
	playerLayer = LayerMask.NameToLayer("Player");
}


function OnTriggerEnter(target:Collider) {
	
	var whoCollided = target.gameObject;
	
	//if the collision is an enemy...
	if (whoCollided.layer == enemyLayer) {
		//increments npcCoutner
		Variables.npcCounter = Variables.npcCounter + 1;
		//Debug.Log("agora temos " + Variables.npcCounter + " NPCs saved!");
	
		//spawns another NPC
		CharacterClonner.createRandomRunningChar();
	
		//takes the NPC out of the scene
		Destroy(whoCollided);
	}
	
	//if the collision is a player...
	if (whoCollided.layer == playerLayer && Variables.canEnterAlep) {
		//Debug.Log("player entrou na Alep");
		Variables.endOption=2;
	}
	
}