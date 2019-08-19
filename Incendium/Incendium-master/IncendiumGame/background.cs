using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour {
	public Transform[] backgrounds;
	private float[] scales;
	public float smoothing = 1f;
	private Transform cam;
	private Vector3 previouscampos;
	void Awake(){
		cam = Camera.main.transform;
	}
	// Use this for initialization
	void Start () {
		previouscampos = cam.position;
		scales = new float[backgrounds.Length];
		for (int i = 0; i < backgrounds.Length; i++) {
			scales [i] = backgrounds [i].position.z * -1;

		}
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < backgrounds.Length; i++) {
			float para = (previouscampos.x - cam.position.x) * scales [i];
			float backgroundtargetx = backgrounds [i].position.x + para;
			Vector3 backgroundtargetpos = new Vector3 (backgroundtargetx,backgrounds[i].position.y,backgrounds[i].position.z);
			backgrounds [i].position = Vector3.Lerp (backgrounds [i].position, backgroundtargetpos, smoothing * Time.deltaTime);
		}
		previouscampos = cam.position;
	}
}
