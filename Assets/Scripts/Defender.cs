using UnityEngine;
using System.Collections;

public class Defender : MonoBehaviour {
	/*
	public int hitPoints;
	public int damagePoints;
	public float fireRate;
	private GameObject projectile;
	public bool hasProjectile;
	*/
	public int cost;
	public int damagePoints;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		/*
		if (gameObject.GetComponent<DefenderProjectile> ()) {
			if (((Time.deltaTime * fireRate) % 30) == 0) {
				Debug.Log (name + "fire");
				DefenderProjectile projectile = Instantiate (gameObject.GetComponent<DefenderProjectile> ());
			}
		}
		*/

	}
	public int GetCosts() {
		return cost;
	}
	public int GetDamagePoints() {
		return damagePoints;
	}

}
