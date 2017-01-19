using UnityEngine;
using System.Collections;



/*
 * Author: Matthias Schedel
 * Creation date: 8.12.16
 * -----------------------
 * Manage SoundSources for different Levels
 * */
public class MusicPlayer : MonoBehaviour {
	
	private AudioSource splashScreen;
	private AudioSource game;
	private AudioSource menu;
	private float volume;

	private static MusicPlayer instance;
	// Use this for initialization
	void Awake() {
		
		if (instance == null) {
			AudioSource[] audioSources = GetComponentsInChildren <AudioSource>();
			instance = new MusicPlayer (audioSources);
		}
		//DontDestroyOnLoad(transform.gameObject);
	}

	void Start () {
		


	}
	public MusicPlayer GetInstance() {
		if (instance == null) {
			AudioSource[] audioSources = GetComponentsInChildren <AudioSource>();
			instance = new MusicPlayer (audioSources);
		} 
		return instance;
	}

	private MusicPlayer(AudioSource[] audioSources) {
		splashScreen = audioSources [0];
		game = audioSources [1];
		menu = audioSources[2];
		volume = SettingsController.GetInstance ().GetMasterVolume ();
		splashScreen.volume = volume;
		game.volume = volume;
		menu.volume = volume;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PlaySplashScreen() {
		//optional volume herunterfahren 
		splashScreen.Play ();
	}
	public void PlayGameScreen() {
		game.Play ();
		menu.Stop ();

	}
	public void PlayMenuScreen() {
		menu.Play ();
		game.Stop ();
		splashScreen.Stop ();
	}

}
