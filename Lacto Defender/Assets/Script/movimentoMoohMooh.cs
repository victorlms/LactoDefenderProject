﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoMoohMooh : MonoBehaviour 
{

	public statusPlayer statusAtual = statusPlayer.standby;

	public string funciona;
	public int conta = 0;

	GameObject lineUp;
	GameObject lineDown;
	GameObject present;

	List<GameObject> linePath;
	List<GameObject> lineUpPath;
	List<GameObject> lineDownPath;
	List<GameObject> walk;

	spawnPlayer lista;
	GameObject campo;

	float speed = 2.5f;

	bool touch = false;
	bool walkTouch = false;
	public SpriteRenderer rend, backRend;

	public atkPlayer estado;

	void Start () {

		estado = GetComponent<atkPlayer> ();

		linePath = new List<GameObject>();

		lineUpPath = new List<GameObject>();
		lineDownPath = new List<GameObject>();


		walk = new List<GameObject>();

		lista = GetComponent<spawnPlayer>();
		campo = lista.objeto [0].gameObject;


	}//FECHA_START
		
	void Update () {


		Vector2 objPosition = new Vector2 (gameObject.transform.position.x, gameObject.transform.position.y);

		if (Input.GetTouch (0).phase == TouchPhase.Began && (Input.GetTouch(0).position == objPosition)) {
	
			//delimita na tela os campos disponiveis

			foreach (GameObject objeto in walk) {
				switch (objeto.tag) {

				case "Enemy":
					estado.activate = true;
					break;

				default:
					estado.activate = false;
					break;

				}


			}

			touch = true;

			if ((touch == true) && (Input.GetTouch (1).phase == TouchPhase.Began)) {

				Vector2 touchDeltaPosition = Input.GetTouch (1).deltaPosition;

				foreach (GameObject campo in walk) {

					Vector2 campoPosition = new Vector2 (campo.transform.position.x, campo.transform.position.y);

					if (campoPosition == touchDeltaPosition) {

						if (campo.gameObject.GetComponent<ScriptField> ().freeFloor) {
							Vector2.Lerp (transform.position, touchDeltaPosition, speed * Time.deltaTime);
						}

					}

				}//foreach

			}

			touch = false;
		}//Fecha_if_Input_n1
			
	}//FECHA_UPDATE

	void OnTriggerEnter2D(Collider2D other)
	{
		//present = other.gameObject;

		if (linePath != other.transform.GetComponentInParent<LineIndentificator> ().path && linePath != null) {

			linePath.Clear ();
			lineUpPath.Clear ();
			lineDownPath.Clear ();


			linePath = other.transform.GetComponentInParent<LineIndentificator> ().path;
			GameObject grid = other.transform.parent.parent.gameObject;
			//qtd = linePath.Count;

			switch (other.transform.parent.tag) {

			case "Linha1":

				lineUp = null;
				lineUpPath = null;
				lineDown = grid.gameObject.transform.GetChild (2).gameObject;
				lineDownPath = lineDown.gameObject.GetComponent<LineIndentificator> ().path;
				break;

			case "Linha2":
				lineUp = grid.gameObject.transform.GetChild (1).gameObject;
				lineUpPath = lineUp.gameObject.GetComponent<LineIndentificator> ().path;
				lineDown = grid.gameObject.transform.GetChild (3).gameObject;
				lineDownPath = lineDown.gameObject.GetComponent<LineIndentificator> ().path;
				break;
	

			case "Linha3":
				lineUp = grid.gameObject.transform.GetChild (2).gameObject;
				lineUpPath = lineUp.gameObject.GetComponent<LineIndentificator> ().path;
				lineDown = grid.gameObject.transform.GetChild (4).gameObject;
				lineDownPath = lineDown.gameObject.GetComponent<LineIndentificator> ().path;
				break;


			case "Linha4":
				lineUp = grid.gameObject.transform.GetChild (3).gameObject;
				lineUpPath = lineUp.gameObject.GetComponent<LineIndentificator> ().path;
				lineDown = grid.gameObject.transform.GetChild (5).gameObject;
				lineDownPath = lineDown.gameObject.GetComponent<LineIndentificator> ().path;
				break;


			case "Linha5":
				lineUp = grid.gameObject.transform.GetChild (4).gameObject;
				lineUpPath = lineUp.gameObject.GetComponent<LineIndentificator> ().path;
				lineDown = null;
				lineDownPath = null;
				break;

			}//Fecha_Switch
		}//Fecha_IF

		//PERCORRE LISTAS PARA IDENTIFICAR POSSIBILIDADES DE MOVIMENTO
		for (int i = 0; i < linePath.Count; i++) {

			if (linePath [i] == gameObject && (lineUpPath != null || lineDownPath != null)) {

				if (i != 1 || i != linePath.Count-1) {
					walk.Add (linePath [i--]);
					walk.Add (linePath [i++]);
					walk.Add (lineUpPath [i]);
					walk.Add (lineDownPath [i]);
				}

				if (i == 1) {
					walk.Add (linePath [i++]);
					walk.Add (lineUpPath [i]);
					walk.Add (lineDownPath [i]);
				}

				if (i == linePath.Count-1) {
					walk.Add (linePath [i--]);
					walk.Add (lineUpPath [i]);
					walk.Add (lineDownPath [i]);

				}
			}//FECHA_IF_BLOCO1

			if (linePath [i] == gameObject && (lineUpPath == null || lineDownPath != null)) {

				if (i != 1 || i != linePath.Count-1) {
					walk.Add (linePath [i--]);
					walk.Add (linePath [i++]);
					walk.Add (lineDownPath [i]);
				}

				if (i == 1) {
					walk.Add (linePath [i++]);
					walk.Add (lineDownPath [i]);
				}

				if (i == linePath.Count-1) {
					walk.Add (linePath [i--]);
					walk.Add (lineDownPath [i]);

				}

			}//FECHA_IF_BLOCO2

			if (linePath [i] == gameObject && (lineUpPath != null || lineDownPath == null)) {

				if (i != 1 || i != linePath.Count-1) {
					walk.Add (linePath [i--]);
					walk.Add (linePath [i++]);
					walk.Add (lineUpPath [i]);
				}

				if (i == 1) {
					walk.Add (linePath [i++]);
					walk.Add (lineUpPath [i]);
				}

				if (i == linePath.Count-1) {
					walk.Add (linePath [i--]);
					walk.Add (lineUpPath [i]);
				}
			}//FECHA_IF_BLOCO3
		}//FECHA_FOR_PERCORRE_LISTAS

		if (other.CompareTag ("Enemy") == false) {
			other.gameObject.GetComponent<ScriptField> ().freeFloor = false;
		}

	}//FECHA_OnTriggerEnter2D

	void OnTriggerStay2D(Collider2D other)
	{

	}//FECHA_OnTriggerStay2D



	void OnTriggerExit2D(Collider2D other){
		
		walk.Clear ();
		if (other.CompareTag ("Enemy") == false) {
			other.gameObject.GetComponent<ScriptField> ().freeFloor = true;
		}
	}

	void OnMouseDown(){



		foreach (GameObject campo in walk) {

			conta++;

		}

	}


}//FECHA MONOBEHAVIOUR