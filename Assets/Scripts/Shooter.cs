using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {
	public GameObject projectile;
	private GameObject projectileParent;
	public int fireRate;
	private int fireCount;
	private Attacker[] attackers;
	private Animator myAnimator;
	// Use this for initialization
	void Start () {
		projectileParent = GameObject.Find ("projectileParent");
		if (!projectileParent) {
			projectileParent = new GameObject("projectileParent");
		}
		fireCount = 0;
		attackers = FindObjectsOfType<Attacker> ();
		myAnimator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		//print ("length: " + attackers.Length);
		attackers = FindObjectsOfType<Attacker> ();
		foreach (Attacker attacker in attackers) {
			//Debug.Log (attacker.transform.parent.transform.position.y + "==" + transform.parent.transform.parent.transform.position.y);
			if (attacker.transform.parent.transform.position.y == transform.parent.transform.position.y) {
				myAnimator.SetBool ("attacking", true);
				return;
			}


		}
		myAnimator.SetBool ("attacking", false);
		//myAnimator.SetBool ("attacking", true);
		//myAnimator.SetBool ("attacking", false);
	}

	private void fire() {
		if (++fireCount == fireRate) {
			GameObject newProjectile = Instantiate (projectile);
			newProjectile.transform.parent = projectileParent.transform;
			newProjectile.transform.position = transform.parent.position - new Vector3(0.5f,0.1f,0f); 
			fireCount = 0;
		}
	}

}
