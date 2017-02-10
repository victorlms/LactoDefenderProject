using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptEnemyProjectile : MonoBehaviour {
	public float SpeedBullet;
	float speedEnemy;
	// Use this for initialization
	void Start () {
		speedEnemy = gameObject.GetComponent<StatusEnemy> ().speed;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.left * (speedEnemy + SpeedBullet) * Time.deltaTime);
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player")
			Destroy (gameObject);
	}
}
//CONFERIR COM O ABREU O PQ DO ALIEN ESTAR IIGNORANDO A TAG