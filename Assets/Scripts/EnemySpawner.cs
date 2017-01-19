using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	private GameObject attackerParent;
	public GameObject[] enemyPrefabs;
	public float startSpawningAfterXSeconds;
	private bool spawning = false;
	// Use this for initialization
	void Start () {
		attackerParent = GameObject.Find ("AttackerParent");
		if (!attackerParent) {
			attackerParent = new GameObject("AttackerParent");

		}
		Invoke ("StartSpawning", startSpawningAfterXSeconds);

	}
	
	// Update is called once per frame
	void Update () {
		if (spawning) {
			foreach (GameObject enemy in enemyPrefabs) {
				if (IsTimeToSpawn (enemy)) {
					Spawn (enemy);
				}
			}
		}

	}
	void StartSpawning() {
		spawning = true;
	}
	void Spawn(GameObject myGameObject) {
		GameObject attacker = Instantiate (myGameObject);
		Vector3 v = new Vector3(transform.position.x,0.5f* Mathf.Round(transform.position.y * 2),0.0f);
		attacker.transform.position = v;
		attacker.transform.parent = attackerParent.transform;
	}


	bool IsTimeToSpawn(GameObject attackerGameObject) {
		Attacker attacker = attackerGameObject.GetComponentInChildren<Attacker> ();
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerForSeconds = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay) {
			Debug.Log ("spawn rate capped by frameRate");
		}
		float threshold = spawnsPerForSeconds * Time.deltaTime / 5;

		if (Random.value < threshold) {
			return true;
		} else {
			return false;
		}


	}
}
