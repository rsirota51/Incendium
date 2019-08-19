using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkground : MonoBehaviour {
	private player ply;
	void Start(){
		ply = gameObject.GetComponentInParent<player>();
	}
	void OnTriggerEnter2D(Collider2D col){
		ply.grounded = true;
	}
	void OnTriggerExit2D(Collider2D col){
		ply.grounded = false;
	}
	void OnTriggerStay2D(Collider2D col){
		ply.grounded = true;
	}
}
