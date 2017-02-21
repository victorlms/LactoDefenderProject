using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//QUESTÃO A SER RESOLVIDA: fazer caixa de colisão piscar?
public class MoveEnemy : MonoBehaviour 
{
	public status enemyStatus = status.move;	
	GameObject checkType;
	float backup_speed;
	public float reactionToHit = 0.2f;// Paradinha por apanhar
	float damagePlayer;
	//FAZER CONTA DO DANO RECEBIDO
	void Start()
	{
		backup_speed = gameObject.GetComponent<StatusEnemy> ().speed;
	}


	void Update ()
	{
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

		case status.hit:
			gameObject.GetComponent<StatusEnemy> ().life -= damagePlayer;
			transform.Translate (Vector3.left * -gameObject.GetComponent<StatusEnemy> ().speed * reactionToHit * Time.deltaTime);
			//ANIMAÇÃO//
			if (gameObject.GetComponent<StatusEnemy> ().life <= 0) {
				enemyStatus = status.death;
			} else
				enemyStatus = status.move;
			break;

		case status.death:
			gameObject.GetComponent<StatusEnemy> ().speed = 0;
			//ESCREVER NESSA LINHA A ANIMAÇÃO DO ALIEN MORRENDO;
			Destroy(gameObject);
			break;
		}//FECHA SWITCH

	
	}//FECHA UPDATE 

	/*
	void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "Player")
			gameObject.GetComponent<StatusEnemy> ().speed = 0;
		if (other.gameObject.tag == "AtkPlayer")
			enemyStatus = status.hit;
	}
*/


	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "AtkPlayer") {
			//Colcoar bala como filho da vaca
			//damagePlayer = other.gameObject.GetComponentInParent<StatusPlayer> ().damage;

			enemyStatus = status.hit;

		}
	}

	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.tag == "Player") {//Encostou no player!
			gameObject.GetComponent<StatusEnemy> ().speed = 0;

		}
	}

	void OnTriggerExit2D(Collider2D other){

		if (other.tag == "Player") {
			gameObject.GetComponent<StatusEnemy> ().speed = backup_speed;
			gameObject.GetComponent<MoveEnemy> ().enemyStatus = status.move;
		}//Player fugiu
		if (other.tag == "AtkPlayer")
			enemyStatus = status.move;
		
		
	}//FECHA EXIT

}
