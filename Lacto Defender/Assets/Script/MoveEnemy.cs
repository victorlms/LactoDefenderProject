using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//QUESTÃO A SER RESOLVIDA: fazer caixa de colisão piscar?
public class MoveEnemy : MonoBehaviour 
{
	public status enemyStatus = status.move;	
	List<GameObject> line;
	GameObject checkType;
	float backup_speed;
	public int x;

	void start()
	{
		
	}


	void Update ()
	{
		backup_speed = gameObject.GetComponent<StatusEnemy> ().speed;

		if (gameObject.GetComponent<StatusEnemy> ().life <= 0)
			enemyStatus = status.death;
		
		switch (enemyStatus) {

		case status.move:
			
			transform.Translate (Vector3.left * gameObject.GetComponent<StatusEnemy> ().speed * Time.deltaTime);
			break;

		case status.atk:
			
			
			/* Escrever o codigo da animação quando tiver */

			transform.Translate (Vector3.left * gameObject.GetComponent<StatusEnemy> ().speed * Time.deltaTime);
			break;


		case status.death:
			gameObject.GetComponent<StatusEnemy> ().speed = 0;
			//ESCREVER NESSA LINHA A ANIMAÇÃO DO ALIEN MORRENDO;
			Destroy(gameObject);
			break;
		}//FECHA SWITCH


	
	}//FECHA UPDATE PORRA


	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player")
			gameObject.GetComponent<StatusEnemy> ().speed = 0;
		//if (other.tag == "AtkPlayer")
			//enemyStatus = status.onHit;
	}//fecha ENTER

	void OnTriggerStay2D(Collider2D other)
	{
		
		line = other.transform.GetComponentInParent <LineIndentificator> ().path;

		foreach (GameObject obj in line) {
			checkType = obj.transform.GetComponent <ScriptField> ().type;
		}
			if (checkType.gameObject.tag == "Player") {
				//ENTRA EM MODO DE ATAQUE
				enemyStatus = status.atk;
			}

		//}//fecha foreach
	}//fecha stay

	void OnTriggerExit2D(Collider2D other){

		if (other.tag == "Player")
			gameObject.GetComponent<StatusEnemy> ().speed = backup_speed;
		if (other.tag == "AtkPlayer")
			enemyStatus = status.move;
		
		
	}//FECHA EXIT

}
