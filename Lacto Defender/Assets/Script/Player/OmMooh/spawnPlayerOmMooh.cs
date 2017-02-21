﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlayerOmMooh : MonoBehaviour {

	public float speed = 100;
	public bool posiciona = true;

	public bool boxEmpty = false;
	public bool permission = false;
	public bool onField = false;
	public bool onMouse = true;
	public bool spawn;
	public ScriptField campo;

	Vector2 _mousePosition;

	public List<GameObject> objeto;

	// Use this for initialization
	void Start () {
		objeto = new List<GameObject> ();
		spawn = true;
	}

	// Update is called once per frame
	void Update () {

		if (spawn == true) {

			if (onField == false && onMouse == true) {
				_mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				transform.position = _mousePosition;
			}

		}

	}

	void OnTriggerEnter2D(Collider2D other){


		if (spawn == true) {

			if (other.gameObject.tag == "Box") {

				bool testa = false;

				if(objeto != null)
					foreach (GameObject fieldTest in objeto) {
						if (fieldTest.gameObject == other.gameObject)
							testa = true;
					}

				if(testa == false)
					objeto.Add (other.gameObject);

				boxEmpty = other.gameObject.GetComponent<ScriptField> ().freeFloor;
				if (boxEmpty == true)
					permission = true;
			} else {
				permission = false;
				boxEmpty = false;
			}//ELSE

		}



	}//VOID_ON_TRIGGER_ENTER

	void OnTriggerStay2D(Collider2D other){

		if (other.tag == "Box" && spawn == true) {

			if (other.gameObject == objeto [0].gameObject) {


				if (Input.GetMouseButtonDown (0) && other.gameObject == objeto [0]) {

					if (permission == true && other.transform.GetComponent<ScriptField> ().freeFloor == true) {


						other.gameObject.GetComponent<ScriptField> ().freeFloor = false;

						onField = true;
						onMouse = false;
						boxEmpty = false;
						permission = false;
						spawn = false;
					
					}
					if (onField == false && permission == false) {

						Debug.Log ("Sem Permissão para criar");
						Destroy (gameObject);

					}

					if (onField == true && posiciona == true) {

						gameObject.transform.position = other.transform.position;
						posiciona = false;
					}

				}

			}

		


		}

	

	}//ONTRIGGERSTAY


	void OnTriggerExit2D(Collider2D other){

		if (spawn == true) {

			if (other.tag == "Box") {


				if (objeto.Count > 0)
					for (int i = 0; i<objeto.Count; i++) {

						if (objeto[i].gameObject == other.gameObject) {
							other.gameObject.transform.GetComponent<ScriptField> ().freeFloor = true;
							objeto.Remove (objeto[i].gameObject);

						}

					}

			}
		}
	}//TRIGGEREXTI

}
