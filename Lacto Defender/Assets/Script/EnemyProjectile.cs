using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyProjectile : MonoBehaviour {
	public GameObject projectile;
	public float DelayBullet;
	float speedEnemy;


	// Use this for initialization
	void Start () {
		InvokeRepeating ( "Shoots", 0 ,DelayBullet);

	}
	
	// Update is called once per frame
	void Update () {


		/*void OnTriggerStay2D(Collider2D other)
		{

			line = other.transform.GetComponentInParent <LineIndentificator> ().path;

			foreach (GameObject obj in line) {
				checkType = obj.GetComponent <ScriptField> ().type;
			}
			if (checkType.gameObject.tag == "Player") {
				//ENTRA EM MODO DE ATAQUE
				enemyStatus = status.atk;
			}

			//}//fecha foreach
		}//fecha stay*/

	}

	void Shoots(){
		if (gameObject.GetComponent<MoveEnemy> ().enemyStatus == status.atk) {
			
				
			Instantiate (projectile, transform.position, Quaternion.identity);

		}
	}



}
//CONFERIR COM O ABREU O PQ DO ALIEN ESTAR IIGNORANDO A TAG