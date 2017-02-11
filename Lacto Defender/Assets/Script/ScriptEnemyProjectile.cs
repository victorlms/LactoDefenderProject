using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScriptEnemyProjectile : MonoBehaviour {
	public GameObject projectile;
	public float DelayBullet;
	public float SpeedBullet;
	float speedEnemy;


	// Use this for initialization
	void Start () {
		StartCoroutine ( Shoots() );

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator Shoots(){
		while (gameObject.GetComponent<MoveEnemy> ().enemyStatus == status.atk) {
			yield return new WaitForSeconds (DelayBullet);
				
			GameObject clone = (GameObject) Instantiate (projectile);
			clone.GetComponent<Rigidbody2D> ().velocity = -transform.right * SpeedBullet;
		}
	}


	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player")
			Destroy (projectile);
	}
}
//CONFERIR COM O ABREU O PQ DO ALIEN ESTAR IIGNORANDO A TAG