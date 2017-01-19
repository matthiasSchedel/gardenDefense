using UnityEngine;
using System.Collections;

public class Attacker : MonoBehaviour {
	[Range (-0.5f, 1.5f)] 
	public float walkSpeed;
	public float seenEverySeconds;
	public int hitPoints;
	private Animator myAnimator;
	private GameObject currentTarget;
	private Health targetHealth;
	private StareScore score;
	private Rigidbody2D myRigidbody;

	//private float damage;


	// Use this for initialization
		void Start () {
		score = FindObjectOfType<StareScore> ();

		hitPoints = 10;
		//myRigidbody = gameObject.AddComponent<Rigidbody2D> ();
		myAnimator = gameObject.GetComponent<Animator> ();
		//myRigidbody.gravityScale = 0;
		//myRigidbody.constraints = RigidbodyConstraints2D.FreezePositionY;

	}



	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * walkSpeed * Time.deltaTime);

		if (transform.position.x < -2) {
			score.Escaped (1);
			Destroy (transform.gameObject.transform.parent.gameObject);
		} 
	}

	public void DefenderDestroyed() {
		myAnimator.SetBool("attacking", false);
	}

	void OnTriggerEnter2D(Collider2D coll) { 
		if (coll.transform.tag == "Defender") {
			//Debug.Log ("HIT Defender trigger");
			//myAnimator.SetBool("attacking", true);

		} else if (coll.transform.tag == "Defender Projectile") {
			//Debug.Log ("HIT Defender Projectile trigger" + coll.transform.ToString());
			hitPoints -= 1;
			Destroy (coll.gameObject);
			if (hitPoints <= 0) {
				Destroy (transform.parent.transform.gameObject);
				//Debug.Log ("Destroyed");
			}

		}
	}
	

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.transform.tag == "Defender") {
			//Debug.Log ("HIT Defender collision");
			//myAnimator.SetBool("attacking", true);

		} else if (coll.transform.tag == "Defender Projectile") {
			//Debug.Log ("HIT Defender Projectile collision" + coll.transform.ToString());
			Destroy (coll.gameObject);

		} 
	}
	public void  Attack(GameObject target) {
		if (!target) {
			myAnimator.SetBool ("attacking", false);
			return;
		}
		currentTarget = target;
		currentTarget.GetComponent<Health> ();
		//Debug.Log ("attack called");


	}
	public void SetSpeed(float speed) {
		walkSpeed = speed;
	}

	public void StrikeCurrentTarget(float damage) {
		if (!currentTarget) {
			myAnimator.SetBool ("attacking", false);
			return;
		}
		targetHealth = currentTarget.GetComponent<Health> ();
		if (!targetHealth.DealDamage (damage)) {
			myAnimator.SetBool ("attacking", false);
			Destroy (currentTarget.transform.gameObject);
		}

	}
}
