using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {
	GameObject defenderParent;
	private StareScore star;
	private DefenderCost dc;
	//private Vector2 mouse;
	// Use this for initialization
	void Start () {
		dc = FindObjectOfType<DefenderCost> ();
		star = FindObjectOfType<StareScore> ();
		defenderParent = GameObject.Find ("DefenderParent");
		if (!defenderParent) {
			defenderParent = new GameObject("DefenderParent");

		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		if (Button.toogledButton) {
			int defCost = dc.GetCosts(Button.toogledButton.id); 
			//print ("cost: " + defCost + "name: " + Button.toogledButton.defender.GetComponent<Defender> ().name);
			if (defCost <= star.GetStarScore ()) {
		
		
		Vector2 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		Vector2 gridPos = SnapGrid (mouse);
		PlaceDefender (gridPos);
				star.SpendStars (defCost);
		}
					}
		//print ("mouse: " + SnapGrid (mouse));

	}

	Vector2 SnapGrid(Vector2 pos) {
		
		float x = (pos.x * 8.593f) - 2.59f;
		//Mathf.Round (pos.x * 20f) * 0.5f - 3.5f;
		float y = (pos.y * 4.838f) - 1f;// * 1.66666666666667f;

		x += 0.4f;
		//y += 0.4f;
		//Mathf.Round (pos.y * 10f) * 0.5f - 1f;

		//print (pos.x + ", " + pos.y);
		//return new Vector2 (Mathf.Clamp(x,0,5), Mathf.Clamp(y,0,2.5f));
		x = (Mathf.Round(x*2)*0.5f);
		y = (Mathf.Round(y*2)*0.5f);
		return new Vector2(Mathf.Clamp(x,0,4.5f),Mathf.Clamp(y,0,2.5f));
		//return new Vector2(x,y);
	}

	void PlaceDefender(Vector2 pos) {
		
			GameObject defender = Instantiate (Button.toogledButton.defender);
			defender.transform.position = pos;
			defender.transform.parent = defenderParent.transform;
		
	}
}
