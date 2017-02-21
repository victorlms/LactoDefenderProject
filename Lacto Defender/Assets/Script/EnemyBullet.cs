using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour {
	public float speedBullet;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * speedBullet * Time.deltaTime);	
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player") {

			Destroy (gameObject);
		}
	}
	void OnTriggerExit2D(Collider2D other){
		if (other.tag == "grid")
			Destroy (gameObject);
	}
}
