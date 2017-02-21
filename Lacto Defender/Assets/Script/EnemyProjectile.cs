using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyProjectile : MonoBehaviour {
	public GameObject projectile;
	public float DelayBullet;
	float speedEnemy;
	List<GameObject> line , type;



	// Use this for initialization
	void Start () {
		InvokeRepeating ( "Shoots", 0 ,DelayBullet);

	}
	
	// Update is called once per frame
	void Update () {

		foreach (GameObject obj in line) {
			type = obj.gameObject.GetComponent<ScriptField> ().typeList;

			foreach (GameObject obj2 in type) {
				if (obj2.gameObject.tag == "Player")
					gameObject.GetComponent<MoveEnemy> ().enemyStatus = status.atk;
			}
		}

	}

	void Shoots(){
		if (gameObject.GetComponent<MoveEnemy> ().enemyStatus == status.atk) {
			
				
			GameObject clone = Instantiate (projectile, transform.position, Quaternion.identity);
			clone.transform.SetParent(gameObject.transform);

		}
	}

	void OnTriggerStay2D(Collider2D other){
		line = other.gameObject.GetComponentInParent<LineIndentificator> ().path;
		

	}



}
//CONFERIR COM O ABREU O PQ DO ALIEN ESTAR IIGNORANDO A TAG