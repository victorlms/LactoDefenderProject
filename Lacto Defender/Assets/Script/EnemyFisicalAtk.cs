using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFisicalAtk : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}


	void OnTriggerStay2D(Collider2D other)
	{

		if (other.gameObject.tag == "Player") {
			gameObject.GetComponent<MoveEnemy> ().enemyStatus = status.atk;
		}




	}
	void OnTriggerExit2D(Collider2D other){

		if (other.gameObject.tag == "Player")
			gameObject.GetComponent<MoveEnemy> ().enemyStatus = status.move;
	}
}
