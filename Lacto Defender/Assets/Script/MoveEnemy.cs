using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//QUESTÃO A SER RESOLVIDA: fazer caixa de colisão piscar?
public class MoveEnemy : MonoBehaviour 
{
	public status enemyStatus = status.move;	
	GameObject checkType;
	float backup_speed;
	public int x;
	//FAZER CONTA DO DANO RECEBIDO
	void Start()
	{
		backup_speed = gameObject.GetComponent<StatusEnemy> ().speed;
	}


	void Update ()
	{

		switch (enemyStatus) {

		case status.move:
			
			transform.Translate (Vector3.left * gameObject.GetComponent<StatusEnemy> ().speed * Time.deltaTime);
			break;

		case status.atk:

			/* Escrever o codigo da animação quando tiver */

			transform.Translate (Vector3.left * gameObject.GetComponent<StatusEnemy> ().speed * Time.deltaTime);
			break;

		case status.hit:
			
			transform.Translate (Vector3.left * -gameObject.GetComponent<StatusEnemy> ().speed *0.2f * Time.deltaTime);

			break;

		case status.death:
			gameObject.GetComponent<StatusEnemy> ().speed = 0;
			//ESCREVER NESSA LINHA A ANIMAÇÃO DO ALIEN MORRENDO;
			Destroy(gameObject);
			break;
		}//FECHA SWITCH

		if (gameObject.GetComponent<StatusEnemy> ().life <= 0)
			enemyStatus = status.death;
		
	
	}//FECHA UPDATE PORRA

	/*
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player")
			gameObject.GetComponent<StatusEnemy> ().speed = 0;
		if (other.gameObject.tag == "AtkPlayer")
			enemyStatus = status.hit;
	}
*/


	void OnTriggerEnter2D(Collider2D other){
		
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Player") {
			gameObject.GetComponent<StatusEnemy> ().speed = 0;

		}
		else
			gameObject.GetComponent<StatusEnemy> ().speed = backup_speed;
		
		if (other.gameObject.tag == "AtkPlayer")
			enemyStatus = status.hit;	
	}

	void OnTriggerExit2D(Collider2D other){

		if (other.tag == "Player")
			gameObject.GetComponent<StatusEnemy> ().speed = backup_speed;
		if (other.tag == "AtkPlayer")
			enemyStatus = status.move;
		
		
	}//FECHA EXIT

}
