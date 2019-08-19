using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deadcollider : MonoBehaviour {
	public GameObject ply;

	void Start () {
		ply = GameObject.FindGameObjectWithTag ("Player");
	}


	void OnTriggerEnter2D(Collider2D col){
		player play = ply.GetComponentInParent<player> ();
		play.dead = true;
		ply.GetComponent<Renderer> ().enabled = false;
}
}
