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
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
