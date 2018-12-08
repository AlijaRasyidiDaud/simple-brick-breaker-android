using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {

	public Rigidbody2D rb;
	public bool inPlay;
	public Transform paddle;
	public Transform explosion;
	public GameManager gm;
	public float speedball;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();

		rb.AddForce (Vector2.up * 300 * speedball);

	}
	
	// Update is called once per frame
	void Update () {

		// Cek jika game over
		if(gm.gameOver){
			return;
		}

		// // Efek power up speed
		// if(gm.speedUp && inPlay){
		// 	Debug.Log("INNNNN");
		// 	speedball = 2f;
		// 	rb.AddForce (Vector2.up * 300 * speedball);
		// }

		if(!inPlay){
			transform.position = paddle.position;
		}

		if(Input.touches[0].phase == TouchPhase.Began && !inPlay){
			inPlay = true;
			rb.AddForce (Vector2.up * 300);
		}


	}

	// Jatuh ke bawah
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Bottom")){
			rb.velocity = Vector2.zero;
			inPlay = false;
			gm.UpdateLives(-1);
		}
	}

	// kena brick
	void OnCollisionEnter2D(Collision2D other){
		if(other.transform.CompareTag("Brick")){
			Transform newExplosion = Instantiate(explosion, other.transform.position, other.transform.rotation);
			Destroy(newExplosion.gameObject, 2.5f);

			gm.UpdateNumberOfBricks();

			Destroy(other.gameObject);
		}
	}
}
