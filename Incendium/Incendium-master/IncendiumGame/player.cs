using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {
	private float speed = 10f;
	private float maxspeed = 15f;
	private float jumppower = 200f;
	public bool duck;
	public bool grounded;
	public bool candoublejump;
	private Rigidbody2D rb2d;
	private Animator anim;
	private bool shooting;
	public bool dead;
	public int deaths;
	private float timer;
	private int waitingtime=2;
	private Vector3 startingpoint;
	private gamemaster gm;
	public AudioSource[] sounds;
	public AudioSource ds;
	// Use this for initialization
void Start () {
		rb2d = gameObject.GetComponent<Rigidbody2D> ();
		anim= gameObject.GetComponent<Animator> ();
		gm = GameObject.FindGameObjectWithTag ("points").GetComponentInParent<gamemaster>();
		startingpoint = new Vector3 (-87f,-15.33f,0);
		dead = false;
		deaths = 0;
		duck = false;
		sounds = GetComponents<AudioSource> ();
		ds = sounds [0];
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool ("grounded", grounded);
		anim.SetFloat ("speed", Mathf.Abs (rb2d.velocity.x));
		anim.SetBool ("duck", duck);
		anim.SetBool ("shooting", shooting);
		timer += Time.deltaTime;
		if (dead) {
			gameObject.SetActive (false);
			if (timer > waitingtime) {
				dead = false;
				timer = 0;
				transform.position = startingpoint;
				gameObject.SetActive (true);
				gameObject.GetComponent<Renderer> ().enabled = true;

			}
		}
		if (Input.GetAxis ("Horizontal") > 0.1f) {
			transform.localScale = new Vector3 (1, 1, 1);
		}
		if (Input.GetAxis ("Horizontal") < -0.1f) {
			transform.localScale = new Vector3 (-1, 1, 1);
		}
		if ((Input.GetButtonDown ("Up") ||Input.GetButtonDown ("Jump")) && !duck) {
			if (grounded) {
				rb2d.AddForce (Vector2.up * jumppower);
				rb2d.velocity = new Vector2 (rb2d.velocity.x,rb2d.velocity.y);
				candoublejump = true;

			} else {
				if (candoublejump) {
					rb2d.AddForce (Vector2.up * (jumppower/1.3f));
					rb2d.velocity = new Vector2 (rb2d.velocity.x,rb2d.velocity.y);
					candoublejump = false;
				}
			}
		}
		if(Input.GetButtonDown("Down") && grounded){
			duck = true;


		}
		if(Input.GetButtonUp("Down") && grounded){
			duck = false;

		}
		if(Input.GetButtonDown("Fire1")){
			shooting = true;


		}
		if(Input.GetButtonUp("Fire1") ){
			shooting = false;

		}
		if (shooting) {
		
		}
	}
	void FixedUpdate(){
		Vector3 easevelocity = rb2d.velocity;
		easevelocity.y = rb2d.velocity.y;
		easevelocity.z = 0.0f;
		easevelocity.x = rb2d.velocity.x * .97f;
		float h = Input.GetAxis ("Horizontal");
		if (grounded) {
				
				rb2d.AddForce ((Vector2.right * speed) * h);

		}
		else if(candoublejump){
			rb2d.AddForce ((Vector2.right * 3f) * h);
		}
		if (rb2d.velocity.x > maxspeed) {
			rb2d.velocity = new Vector2 (maxspeed,rb2d.velocity.y);
		}
		if (rb2d.velocity.x < -maxspeed) {
			rb2d.velocity = new Vector2 (-maxspeed,rb2d.velocity.y);
		}
		if (grounded) {
			rb2d.velocity = easevelocity;
		}
	}
	void OnTriggerEnter2D(Collider2D col){
		if(col.CompareTag("coins")){
			Destroy (col.gameObject);
			gm.coins ++;
	}
 		
}
}
