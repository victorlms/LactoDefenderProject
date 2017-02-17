using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFisicalAtk : MonoBehaviour {
	public GameObject Blow;
	// Use this for initialization
	void Start () {
		if (gameObject.GetComponent<MoveEnemy> ().enemyStatus == status.atk) {
			GameObject clone = Instantiate (Blow, transform.position, Quaternion.identity);	

			clone.transform.SetParent (gameObject.transform);
		}
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
