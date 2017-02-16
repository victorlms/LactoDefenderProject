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

}
