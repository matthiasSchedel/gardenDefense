using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*
 * Author: Matthias Schedel
 * Creation date: 8.12.16
 * -----------------------
 * LevelManager
 * LoadLevels and play sound according to level
 * */
public class LevelManager : MonoBehaviour {
	public int loadDuration = 3;
	private MusicPlayer player;
	public Image image;
	private float timer;

	// Use this for initialization
	void Start () {
		player = GameObject.FindObjectOfType<MusicPlayer> ();
		//find object musicplayer
		//set musicplayer
		//Debug.Log("scene:" + SceneManager.GetActiveScene ().name.Remove(6));
		if (SceneManager.GetActiveScene ().name == "Splash 00") {
			player.GetInstance ().PlaySplashScreen ();
			Invoke ("LoadNextLevel", loadDuration);
		} else if (SceneManager.GetActiveScene ().name.Remove(7) == "Menu 01") {
			player.GetInstance ().PlayMenuScreen ();
		} else if (SceneManager.GetActiveScene ().name.Remove(7) == "Game 02") {
			player.GetInstance ().PlayGameScreen ();
		}
	}

	// Update is called once per frame
	void Update () {
		if (SceneManager.GetActiveScene ().name == "Menu 01" && timer <= 255) {
			FadeIn ();
		}
	}

	void FadeIn() {
		timer += Time.deltaTime * 0.4f;
		Color color = image.color;
		color.a = timer;
		image.color = color;
	}


	public void LoadNextLevel() {
	SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
	}

	public void LoadLevel(string level) {
		SceneManager.LoadScene(level);
	}


}
