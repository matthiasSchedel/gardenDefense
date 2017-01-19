using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {
	public float health;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool DealDamage(float damage) {
		health -= damage;
		if (health <= 0) {

			return false;
		
		}
		return true;
	}
}
