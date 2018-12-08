using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpScript : MonoBehaviour {

	public float speed;
	//public Rigidbody2D rb2;

	// Use this for initialization
	void Start () {
		//rb2 = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector2(0f,-1f)*Time.deltaTime*speed);
		
	}
}
