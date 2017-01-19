using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour {
	private Animator myAnimator;
	private Attacker attacker;
	// Use this for initialization
	void Start () {
		myAnimator = GetComponent<Animator> ();
		attacker = GetComponent<Attacker> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D coll) {
		//Debug.Log ("Trigger");
		GameObject obj = coll.gameObject;
		if (!obj.GetComponent<Defender> ()) {
		//	Debug.Log ("no Defender");
			return;
		}
		if (obj.GetComponent<GraveStone> ()) {
		//	Debug.Log ("Jump");
			myAnimator.SetTrigger ("jumping");
			return;
		}
		//Debug.Log ("Attack");
		myAnimator.SetBool ("attacking", true);
		attacker.Attack (coll.gameObject);

	}
}
