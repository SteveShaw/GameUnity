using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public enum MOVETYPE {IDLE = 0, WALK=1, BOXPUSH=2, CHEER=3};

	public MOVETYPE PlayerState
	{
		get{ return State;}

		set
		{
			State = value;

			AnimComp.SetInteger("iState",(int)State);
		}
	}

	private MOVETYPE State = MOVETYPE.IDLE;

	public float MoveTime = 1.0f;

	public float MoveDistance = 2.0f;

	private Transform ThisTransform = null;

	private Animator AnimComp = null;
	// Use this for initialization
	void Start () {

		ThisTransform = GetComponent<Transform> ();
		
		AnimComp = GetComponent<Animator>();
		
		StartCoroutine(HandleInput());
	
	}
	
	public IEnumerator HandleInput()
	{
		while(true)
		{
			while(Mathf.CeilToInt(Input.GetAxis("Vertical"))>0)
			{
				PlayerState = MOVETYPE.WALK;
				
				yield return StartCoroutine(Move(MoveDistance));
			}
			
			PlayerState = MOVETYPE.IDLE;
			
			yield return null;
		}
	}
	
	public IEnumerator Move(float Increment=0)
	{
		//Start Position
		Vector3 StartPos = ThisTransform.position;
		
		//Dest Position
		
		Vector3 DestPos = ThisTransform.position + ThisTransform.forward * Increment;
		
		//Elapsed Time
		
		float ElapsedTime = 0.0f;
		
		while(ElapsedTime < MoveTime)
		{
			//Calculate interpolated angle
			Vector3 FinalPos = Vector3.Lerp(StartPos,DestPos,ElapsedTime/MoveTime);
			
			//update pos
			ThisTransform.position = FinalPos;
			
			//Wait until next frame
			yield return null;
			
			ElapsedTime += Time.deltaTime;
		}
		
		//Complete Move
		ThisTransform.position = DestPos;
		
		yield break;
		
	}
	
}
