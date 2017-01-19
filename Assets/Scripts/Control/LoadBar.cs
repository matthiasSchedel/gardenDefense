using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LoadBar : MonoBehaviour {
	private Slider slider;
	private LevelManager lm;
	public int LoadDuration;
	// Use this for initialization
	void Start () {
		lm = FindObjectOfType<LevelManager> ();
		slider = FindObjectOfType<Slider> ();
		slider.value = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (slider.value == 1) {
			print ("finished at: " + Time.realtimeSinceStartup);//lm.LoadNextLevel ();
			lm.LoadNextLevel();
		}
		slider.value += Time.deltaTime * 1 * 0.007f;
	}
}
