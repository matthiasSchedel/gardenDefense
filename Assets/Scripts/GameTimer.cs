using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {
	public float levelSeconds = 100;

	private Slider slider;
	private AudioSource audioSource;
	private bool isEndOfLevel = false;
	public bool endConditionExists;
	private Text text;
	private LevelManager levelManager;
	// Use this for initialization
	void Start () {
		text = FindObjectOfType<WinText>().GetComponent<Text> ();
		text.enabled = false;
		slider = GetComponent<Slider> ();
		audioSource = GetComponent<AudioSource> ();
		levelManager = FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		slider.value = Time.timeSinceLevelLoad / levelSeconds;
		bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);
		if (timeIsUp && !isEndOfLevel) {
			audioSource.Play ();
			Invoke ("LoadNextLevel", audioSource.clip.length);
			isEndOfLevel = true;
			text.enabled = true;
		}
	}

	void LoadNextLevel() {
		levelManager.LoadNextLevel ();
	}
}
