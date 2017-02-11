using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//QUESTÃO A SER RESOLVIDA: fazer caixa de colisão piscar?
public class MoveEnemy : MonoBehaviour 
{
	public status enemyStatus = status.move;	
	List<GameObject> line;
	GameObject checkType;
	public GameObject obj;
	float backup_speed; 

	void start()
	{
		
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


		case status.death:
			gameObject.GetComponent<StatusEnemy> ().speed = 0;
			//ESCREVER NESSA LINHA A ANIMAÇÃO DO ALIEN MORRENDO;
			Destroy(gameObject);
			break;
		}


	
	}//FECHA UPDATE PORRA


	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "Player")
			gameObject.GetComponent<StatusEnemy> ().speed = 0;
	}

	void OnTriggerStay2D(Collider2D other)
	{
		
		line = other.transform.GetComponentInParent <LineIndentificator> ().path;
	
		foreach( GameObject obj in line)
		{
			checkType = obj.transform.GetComponentInParent <ScriptField> ().type;
			
			if (checkType.CompareTag ("Player") && (other.transform.parent.tag == obj.transform.parent.tag)) {
				//ENTRA EM MODO DE ATAQUE
				enemyStatus = status.atk;
			} else
				enemyStatus = status.move;// faz ele voltar a andar sem atacar

		}//fecha foreach
	}//fecha stay

	void OnTriggerExit2D(Collider2D other){

		if (other.tag == "Player")
			gameObject.GetComponent<StatusEnemy> ().speed = backup_speed;
		
	}

}
