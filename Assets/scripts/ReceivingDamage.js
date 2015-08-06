#pragma strict

import RAIN.Core;


var _ai : AIRig;
var _dataController : DataController;
var _anim : Animator;

var _speed : float;
var _scapeVector : Vector3;
var _myAliveCollider : CapsuleCollider;
var _myDeadCollider : BoxCollider;
var _myBlood:GameObject;
var _isDead  = false;




function Start () {
	//Time.timeScale = 0.25;
	//Time.fixedDeltaTime = 0.02 * Time.timeScale;

	_anim   = gameObject.GetComponent.<Animator>();
	_speed  = Random.Range(0.03, 0.1);
	_isDead = false;
	_dataController = gameObject.GetComponent.<DataController>();
	_myAliveCollider = gameObject.GetComponent.<CapsuleCollider>();
	_myDeadCollider = gameObject.GetComponent.<BoxCollider>();
	
	//_ai.AI.WorkingMemory.SetItem.<boolean>("dead", false);
	//_ai.AI.WorkingMemory.SetItem.<float>("hungry", 15f);
	//_ai.AI.WorkingMemory.SetItem.<boolean>("foundfood", false);
	//_ai.AI.WorkingMemory.SetItem.<boolean>("gothit", false);
	
	//trying to get the AI instance
	_ai    = gameObject.GetComponentInChildren.<AIRig>();
	
	//se esse personagem tem AI
	//if (_ai!=null)
	updateAI();
}



function updateAI() {
	_ai.AI.WorkingMemory.SetItem.<boolean>("dead", _isDead);
	_ai.AI.WorkingMemory.SetItem.<float>("speed", _speed);
}


function Update () {
	
	//código com objetivo de lidar com a situação de player meelee
	if (Input.GetMouseButtonDown(0)) {
		var hit: RaycastHit;
		var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			
		//se acertei em algo	
		if (Physics.Raycast(ray, hit)) {
			
			if (hit.rigidbody != null && //se esse algo tiver um corpo
				hit.transform.name  == _dataController.name) { //e se esse algo for o mesmo do meu objetvo
					
				//print("acertei em: " + hit.transform.name + " no ponto: " + hit.point +" com uma distancia de: " + hit.distance);
				//print ("my data controller é... " + _dataController.name);

				//crie uma mensagem de dano
				var damageSource = new FPSControl.DamageSource();
				damageSource.sourceType = DamageSource.DamageSourceType.GunFire;
				damageSource.appliedToPosition = hit.point;
				//e aplique esse dano
				SendMessage("ApplyDamage", damageSource);
			}
		}
	}

}



function ApplyDamage(damageSource : DamageSource)
{
	if ((damageSource.sourceType == DamageSource.DamageSourceType.GunFire) &&
	    (damageSource.sourceObjectType != DamageSource.DamageSourceObjectType.Obstacle) && !_isDead)
    {
		
		//make him die
		Death(); 
		
		//make him blood
		var _bloodAnimation = GameObject.Instantiate(_myBlood, damageSource.appliedToPosition, Quaternion.identity);
		
	
		//destroy the particle system
		Destroy(_bloodAnimation, 1.5);
	}

}	


function Death() {
	_isDead = true;
	_speed  = 0;

	Variables.deadNPCs++;
	Variables.canEnterAlep = false;
	
	CharacterClonner.createRandomRunningChar();
	//Debug.Log(Variables.deadNPCs + " professores inutilizados!");
	_myDeadCollider.GetComponent.<BoxCollider>().isTrigger = false;
	_myAliveCollider.GetComponent.<CapsuleCollider>().isTrigger = true;

	
	//destroy the animator
	Destroy(_anim, 10);
	
	//destroy the AI
	Destroy(_ai, 1.5);
	
	//destroy the datacontroller
	//Destroy(_myBlood, 1.0);
	
	//destroy the datacontroller
	Destroy(_dataController, 10);
	
	
	
	//se esse personagem tem AI
	//if (_ai!=null)
	updateAI();
	//se nao tem...
	//else {
	//	Debug.Log("eu morri e não tenho IA!!!");
	//	_anim.SetBool("isRunning", false);
	//	_anim.SetBool("isDead", true);
	//}
	
	//print("I'm hurt!");
	//_anim.SetBool("isDead", true);
	//_anim.SetBool("isRunning", false);	

	//trying to get current speed
	//_ai.AI.Motor.Speed = 0;
	//var curSpeed = _ai.AI.WorkingMemory.GetItem<float>("Speed");
	//Debug.Log("_lookit Speed is now(before):  " + curSpeed);
}


