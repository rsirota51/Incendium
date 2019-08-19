using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollows : MonoBehaviour {
	private Vector2 velocity;
	public float smoothy;
	public float smoothx;
	public bool bounds;
	public GameObject player;
	public Vector3 mincamera;
	public Vector3 maxcamera;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");

	}
	

	void FixedUpdate () {
		float posx = Mathf.SmoothDamp (transform.position.x,player.transform.position.x,ref velocity.x,smoothx);
		float posy = Mathf.SmoothDamp (transform.position.y,player.transform.position.y,ref velocity.y,smoothy);
		transform.position =  new Vector3 (posx,posy,transform.position.z);

		if (bounds) {
			transform.position = new Vector3 (Mathf.Clamp(transform.position.x,mincamera.x,maxcamera.x),Mathf.Clamp(transform.position.y,mincamera.y,maxcamera.y),Mathf.Clamp(transform.position.z,mincamera.z,maxcamera.z));
		}
	}
}
