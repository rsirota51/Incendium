using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausemenu : MonoBehaviour {
	public GameObject menu;
	private bool pause = false;

	// Use this for initialization
	void Start () {
		menu.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown ("pause")) {
			pause = !pause;
		}
		if (pause) {
			menu.SetActive (true);
			Time.timeScale = 0;
		} else {
			menu.SetActive (false);
			Time.timeScale = 1;
		}
	}
	public void restart(){
		Application.LoadLevel (Application.loadedLevel);
	}
	public void quit(){
		Application.Quit ();
	}
}
