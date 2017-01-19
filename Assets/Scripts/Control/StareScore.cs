using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StareScore : MonoBehaviour {
	public const int startScore  = 100;
	public const int totalLifes = 20;
	private LevelManager lm;

	private int stareScore;
	private Text text;
	private Text[] cost;
	private int lifesLeft;

	// Use this for initialization
	void Start () {
		lifesLeft = totalLifes;
		stareScore = startScore;
		cost = GetComponentsInChildren<Text> ();
		cost [0].text = ":" + stareScore.ToString ();
		text = cost [0];

		lm = FindObjectOfType<LevelManager> ();
		cost [cost.Length - 2].text = "Lifes left: " + lifesLeft.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}



	public void AddStars(int stars) {
		stareScore += stars;
		text.text = stareScore.ToString ();
	}

	public void SpendStars(int stars) {
		stareScore -= stars;
		text.text = ":" + stareScore.ToString ();
	}

	public void Escaped(int i) {
		if(lifesLeft - i <= 0) {
			lm.LoadLevel("Game Over 03");
		} 

		lifesLeft -= i;
		cost [cost.Length - 2].text = "Lifes left: " + lifesLeft.ToString ();
	}

	public int GetStarScore() {
		return stareScore;
	}


}
