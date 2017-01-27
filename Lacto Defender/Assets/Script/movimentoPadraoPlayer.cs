using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoPadraoPlayer : MonoBehaviour 
{

	List<GameObject> line;
	GameObject lineUp;
	GameObject lineDown;

	GameObject present;
	int qtd;

	List<GameObject> walk;

	void Start () {
		
		line = new List<GameObject>();
		/**
		lineUp = new List<GameObject>();
		lineDown = new List<GameObject>();
		**/

		walk = new List<GameObject>();
	}//FECHA_START
		
	void Update () {

		if (Input.GetTouch (0).phase == TouchPhase.Began) {
			//acende_Lugares_Permitidos



			if(Input.GetTouch (0).phase == TouchPhase.Began){

			}



		}//Fecha_if_Input_n1


	}//FECHA_UPDATE

	void OnTriggerEnter2D(Collider2D other)
	{
		present = other.gameObject;
		if (line != other.transform.GetComponentInParent<LineIndentificator> ().path) {

			line = other.transform.GetComponentInParent<LineIndentificator> ().path;
			GameObject grid = other.transform.parent.parent.gameObject;
			qtd = line.Count;

			switch (other.transform.parent.tag) {

			case "Linha1":

				lineUp = null;
				lineDown = grid.gameObject.transform.GetChild (2).gameObject;
				break;

			case "Linha2":
				lineUp = grid.gameObject.transform.GetChild (1).gameObject;
				lineDown = grid.gameObject.transform.GetChild (3).gameObject;
				break;
	

			case "Linha3":
				lineUp = grid.gameObject.transform.GetChild (2).gameObject;
				lineDown = grid.gameObject.transform.GetChild (4).gameObject;
				break;


			case "Linha4":
				lineUp = grid.gameObject.transform.GetChild (3).gameObject;
				lineDown = grid.gameObject.transform.GetChild (5).gameObject;
				break;


			case "Linha5":
				lineUp = grid.gameObject.transform.GetChild (4).gameObject;
				lineDown = null;
				break;

			}//Fecha_Switch
		}//Fecha_IF

	}//FECHA_OnTriggerEnter2D

	void OnTriggerStay2D(Collider2D other)
	{

		foreach( GameObject objeto in line){

			if (objeto.CompareTag ("Inimigo")) {
			}
			//Ataque;
			}
		
	}//FECHA_OnTriggerStay2D
}
