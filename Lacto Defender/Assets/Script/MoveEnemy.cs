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
			/*TESTE*///Destroy (gameObject);
			
			transform.Translate (Vector3.left * gameObject.GetComponent<StatusEnemy> ().speed * Time.deltaTime);
			break;

		case status.hit:
			


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
		if (other.gameObject.tag == "AtkPlayer")
			enemyStatus = status.hit;
	}//fecha ENTER



	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Box") 
		{
			checkType = other.gameObject.GetComponent <ScriptField> ().type;

			if(checkType == null)
				enemyStatus = status.move;
			else if (checkType.tag == "Player")
				enemyStatus = status.atk;
		}
	}

	void OnTriggerStay2D(Collider2D other){
	}

	void OnTriggerExit2D(Collider2D other){

		if (other.tag == "Player")
			gameObject.GetComponent<StatusEnemy> ().speed = backup_speed;
		if (other.tag == "AtkPlayer")
			enemyStatus = status.move;
		
		
	}//FECHA EXIT

}
