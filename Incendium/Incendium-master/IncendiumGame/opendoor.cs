using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opendoor : MonoBehaviour {

	private gamemaster gm;
	public GameObject text;
	public GameObject text2;
	private GameObject ply;
	void Start(){
		gm = GameObject.FindGameObjectWithTag ("points").GetComponentInParent<gamemaster>();
		text.SetActive (false);
		ply = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnTriggerEnter2D(Collider2D col){
		if(gm.coins>=13){
			Time.timeScale = 0;
			ply.transform.position = new Vector3 (-53.24f,-23.84f,0);
			text.SetActive (true);
			text2.SetActive (true);


	}
}
}
