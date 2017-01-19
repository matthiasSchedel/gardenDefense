using UnityEngine;
using System.Collections;

public class DefenderProjectile : MonoBehaviour {

	public float speed, damage, rotationspeed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * Time.deltaTime * speed;
		//transform.Translate (Vector3.down * speed * Time.deltaTime);
		transform.Rotate (0,0,-Time.deltaTime * rotationspeed);

		if (transform.position.x > 5.5f) {
			//Vector3 pos = new Vector3 (-0.3f, transform.position.y, transform.position.z);
				//transform.position = pos;
			Destroy(transform.gameObject);
		}
	}
}
