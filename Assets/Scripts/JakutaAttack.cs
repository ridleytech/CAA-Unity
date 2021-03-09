using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class JakutaAttack : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler {

	public float smoothing;
	private Vector2 origin;
	private Vector2 direction;
	private Vector2 smoothDirection;
	public bool touched;
	private int pointerID;
	public GameObject player;
	public Animator anim;
	public int attack;
	//PlayerState ps;

	void Awake () {

		direction = Vector2.zero;
		touched = false;
		//Debug.Log ("awake touchpad");
	}

	void Start () {

		//ps = player.GetComponent<PlayerState> ();

		//		player = GameObject.Find ("granny2");
		//
		//		print ("player: "+player);
		//
		//		anim = player.GetComponent<Animator> ();
		//
		//		print ("anim: "+anim);
	}

	public void OnPointerDown (PointerEventData data) {

		//print ("OnPointerDown");

		if (!touched) 
		{
			//print ("Jab");

			touched = true;
			pointerID = data.pointerId;
			origin = data.position;

			string a = "attack" + attack;

			anim.SetTrigger(a);

			// if(attack == 2)
			// {
			// 	anim.SetTrigger ("attack2");	
			// }
			// else
			// {
			// 	anim.SetTrigger ("attack3");
			// }

			//ps.attacking = true;

			//Debug.Log ("OnPointerDown weapon");
		}
	}

	void Update() {

//		float punchCurve = anim.GetFloat(Animator.StringToHash("punchCurve"));
//		float kickCurve = anim.GetFloat(Animator.StringToHash("kickCurve"));
//
////		if (kickCurve > .0075f) {
////
////			//print ("kickCurve: "+kickCurve);
////
////			//print ("knockdown");
////
////			//opponentanim.SetTrigger ("Knockdown");
////		} 
//
//		if (kickCurve > 0 || punchCurve > 0) 
//		{
//			ps.attacking = true;
//		} else {
//			ps.attacking = false;
//		}

		//print ("shot float: "+shot);

		//print ("shot: "+shot);

		// If the shot curve is peaking and the enemy is not currently shooting...

//		if (kickCurve > 0.5f && !shooting) 
//		{
//		}

	}

	public void OnDrag (PointerEventData data) {

		if (data.pointerId == pointerID) 
		{
			Vector2 currentPosition = data.position;
			Vector2 directionRaw = currentPosition - origin;
			direction = directionRaw.normalized;

			//Debug.Log ("direction: "+direction);
		}
	}

	public void OnPointerUp (PointerEventData data) {

		if (data.pointerId == pointerID) 
		{
			direction = Vector3.zero;

			//Debug.Log ("OnPointerUp weapon");

			string a = "attack" + attack;

			anim.ResetTrigger(a);

			// if(attack == 2)
			// {
			// 	anim.ResetTrigger ("attack2");	
			// }
			// else
			// {
			// 	anim.ResetTrigger ("attack3");
			// }

			touched = false;
		}
	}

	public Vector2 GetDirection () {

		smoothDirection = Vector2.MoveTowards (smoothDirection, direction, smoothing);
		return smoothDirection;
	}
}