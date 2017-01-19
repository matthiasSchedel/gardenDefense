using UnityEngine;
using System.Collections;

public class EnemyCounter : MonoBehaviour {
	private StareScore score;
	// Use this for initialization
	void Start () {
		score = FindObjectOfType<StareScore> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {
		print ("colision");
		if (coll.transform.tag == "Attacker") {
			score.Escaped (1);
			DestroyObject (coll.transform.parent.transform.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		print ("trigger");

		if (coll.transform.tag == "Attacker") {
			score.Escaped (1);
			DestroyObject (coll.transform.parent.transform.gameObject);
		}
	}
}
