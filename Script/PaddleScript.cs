using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleScript : MonoBehaviour {

	// public float speed;
	public float leftScreenEdge;
	public float rightScreenEdge;
	public GameManager gm;
	public Rigidbody2D rb2;

	// Use this for initialization
	void Start () {
		rb2 = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {

		// Cek game over
		if(gm.gameOver){
			return;
		}
		
		// Masukan input touch pada android
		if(Input.touchCount > 0){

			Vector2 touchPos = Input.touches[0].position;
			Vector2 touchPosinWorldSpace = Camera.main.ScreenToWorldPoint(new Vector2(touchPos.x, 2.85f));
			if(Input.touches[0].phase == TouchPhase.Began){
				transform.position = new Vector2(touchPosinWorldSpace.x, transform.position.y);
				Debug.Log(Input.GetTouch(0).position.x);
			}
			
			if(Input.touches[0].phase == TouchPhase.Moved){
				// float horizontal = Input.GetTouch(0).deltaPosition.x;
				// transform.Translate (Vector2.right * horizontal * Time.deltaTime * speed);
				transform.position = new Vector2(touchPosinWorldSpace.x, transform.position.y);
				Debug.Log(Input.GetTouch(0).position.x);
			}

		}

		// Setting agar gerakan paddle tak lebihi layar kiri dan kanan
		if(transform.position.x < leftScreenEdge){
			transform.position = new Vector2(leftScreenEdge, transform.position.y);
		}
		if(transform.position.x > rightScreenEdge){
			transform.position = new Vector2(rightScreenEdge, transform.position.y);
		}
		
	}

	// Kena power up
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Speed")){
			
			gm.SpeedUp();
			Destroy(other.gameObject);
		}
	}
}
