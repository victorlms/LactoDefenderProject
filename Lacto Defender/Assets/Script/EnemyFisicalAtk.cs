using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFisicalAtk : MonoBehaviour {
	public GameObject Blow;
	public int x;
	// Use this for initialization

	void OnCollisionEnter2D (Collision2D other){

		if (gameObject.GetComponent<MoveEnemy> ().enemyStatus == status.atk && other.gameObject.tag == "Player") {
			x++;
			GameObject clone = Instantiate (Blow, transform.position , Quaternion.identity);	

			clone.transform.SetParent (gameObject.transform);

		}
	}

}
