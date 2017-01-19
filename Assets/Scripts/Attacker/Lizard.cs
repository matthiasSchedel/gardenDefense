using UnityEngine;
using System.Collections;

public class Lizard : MonoBehaviour {
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
		GameObject obj = coll.gameObject;
		if (!obj.GetComponent<Defender> ()) {
			return;
		}
		//Debug.Log ("Attack");
		myAnimator.SetBool ("attacking", true);
		attacker.Attack (coll.gameObject);

	}
}
