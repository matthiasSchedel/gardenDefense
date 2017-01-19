using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {
	public static Button toogledButton;
	private static Button[] buttons;
	public GameObject defender;
	public int id;
	void Start () {
		buttons = FindObjectsOfType<Button> ();
		ResetButtons ();


	}


	private static void ResetButtons() {
		foreach (Button b in buttons) {
			b.GetComponent<SpriteRenderer> ().color = new Color (0F, 0F, 0F, 1F);
		}			}
	
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown() {
		ResetButtons ();
		toogledButton = this;
		GetComponent<SpriteRenderer> ().color = new Color (1F, 1F, 1F, 1F);

	}

	void OnMouseUp() {
	}
		
}
