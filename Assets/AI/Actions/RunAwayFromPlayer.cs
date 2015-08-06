using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using RAIN.Core;
using RAIN.Action;
using RAIN.Entities.Aspects;
using RAIN.Motion;

[RAINAction]
public class RunAwayFromPlayer : RAINAction
{
    public RunAwayFromPlayer()
    {
        actionName = "RunAwayFromPlayer";
    }

    public override void Start(AI ai)
    {
        base.Start(ai);
    }
	
	
	//remap function, taken form here
	//http://forum.unity3d.com/threads/re-map-a-number-from-one-range-to-another.119437/
	public float remap (this float value, float from1, float to1, float from2, float to2) {
	    return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
	}

    public override ActionResult Execute(AI ai)
    {
		//get player	
		GameObject player = ai.WorkingMemory.GetItem<GameObject>("posPlayer");
		
		var playerPosition = player.transform.position;		
		//Debug.Log("p: " + playerPosition);
		
		//get enemy position
		var enemyPosition = new Vector3(ai.Kinematic.Position.x, ai.Kinematic.Position.y, ai.Kinematic.Position.z);
		//Debug.Log("e: " + enemyPosition);
		
		//computes the different between both positions
		var difference = (enemyPosition - playerPosition);
		//normalizes the vector
		//difference.Normalize();
		//Debug.Log("dif: " + difference);
		
		//checks how close enemy and player are
		var dist = Vector3.Distance(playerPosition, enemyPosition);
		var mag = remap(dist, 0, 11, 11, 0);
		difference *= (mag/3);
		//Debug.Log("old mag: " + dist + "  new mag: " + mag);
		
		
		//computes the new escape point
		var result = (enemyPosition+difference);
		//Debug.Log("new scape point: " + result);
		result.y = playerPosition.y;

		
		//update the scapePoint		
		var newPosition = new MoveLookTarget();
		//result.VectorTarget = new Vector3(200,1,215);
		newPosition.VectorTarget = result;
		ai.WorkingMemory.SetItem<MoveLookTarget>("escapePoint", newPosition);
		//ai.Motor.MoveTo(result);
		
		
		return ActionResult.SUCCESS;
    }

    public override void Stop(AI ai)
    {
        base.Stop(ai);
    }
}