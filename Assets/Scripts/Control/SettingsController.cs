using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class SettingsController : MonoBehaviour {
	public Slider volumeSlider;
	public Text volumeText;
	private static SettingsController instance;
	private float masterVolume;
	private float difficulty;
	// Use this for initialization
	void Start () {
		//Slider[] sliders = GetComponents<Slider> ();
		//Text[] texts = GetComponents<Text> ();
		//volumeSlider = sliders [0];
		//volumeText = texts [0];
		if (instance == null) {
			instance = new SettingsController ();
		}
		if (!PlayerPrefs.HasKey ("MasterVolume")) {
			PlayerPrefs.SetFloat ("MasterVolume", 1);
			volumeSlider.value = 1f;
			volumeText.text = "Volume: 100%";
		} else {
			volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume");
			volumeText.text = "Volume: " + (int) (volumeSlider.value * 100) + " %";
		}
	}
	public static SettingsController GetInstance() {
		if (instance == null) {
			instance = new SettingsController ();
		}
		return instance;
	}
	private SettingsController() {
	}
	public void SetMasterVolume(float volume) {
		PlayerPrefs.SetFloat ("MasterVolume",volume);
		volumeSlider.value = volume;
		volumeText.text = "Volume: " +  (int) (volume * 100) + "%";
	}

	public float GetMasterVolume() {
		return PlayerPrefs.GetFloat ("MasterVolume");
	}

	public void SetDifficulty(float volume) {

	}

	public float GetDifficulty() {
		return 0;
	}
	public void VolumeUpdated() {
		SetMasterVolume (volumeSlider.value);
		volumeText.text = "Volume: " + (int) (volumeSlider.value * 100) + " %";
	}
	// Update is called once per frame
	void Update () {
	
	}

}
