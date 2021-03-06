﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atkPlayerRaMooh : MonoBehaviour {

	public bool repete = false;
	public bool activate = false;
	public bool search = false;
	public GameObject line;
	public List<GameObject> linePath;
	public GameObject box;

	public GameObject projetil;
	public float speed;
	public float damage;
	int auxInt;

	// Use this for initialization
	void Start () {
		linePath = new List<GameObject> ();
		gameObject.transform.GetComponent<StatusPlayer> ().damage = damage;
	}

	// Update is called once per frame
	void Update () {

		if(gameObject.transform.GetComponent<novoMovimentoRaMooh> ().line != null){
		line = gameObject.transform.GetComponent<novoMovimentoRaMooh> ().line;
		linePath = line.gameObject.transform.GetComponent<LineIndentificator> ().path;
		}
		if (gameObject.transform.GetComponent<movimentoRaMooh> ().walking == false 
			&& gameObject.transform.GetComponent<spawnPlayerRaMooh>().onField == true 
			&& gameObject.transform.GetComponent<spawnPlayerRaMooh>().spawn == false) {

			/*foreach (GameObject campo in linePath) {
				if (campo.gameObject.transform.GetComponent<ScriptField> ().typeList.Count > 0)
					foreach (GameObject tipo in campo.gameObject.transform.GetComponent<ScriptField> ().typeList) {
						if (tipo != null && tipo.gameObject.tag == "Enemy") {
							search = true;
						}
					}
			}*/


			if (linePath.Count > 0) {
				for (int i = 0; i < linePath.Count; i++) {

					if (linePath [i].gameObject == box.gameObject)
						auxInt = i;

					if (linePath [i].gameObject.transform.GetComponent<ScriptField> ().typeList.Count > 0) {

						for (int j = 0; j < linePath [i].gameObject.transform.GetComponent<ScriptField> ().typeList.Count; j++) {

							if (linePath [i].gameObject.transform.GetComponent<ScriptField> ().typeList [j].gameObject.tag == "Enemy" && i >= auxInt)
								search = true;

						}

					}

				}
			}

			if (search == true) {
				activate = true;
			}

			if (search == false)
				activate = false;
		}

		if (activate == true) {
			atira ();
		}

		if (activate == false) {
			CancelInvoke("launch");
			repete = false;
		}

		foreach (GameObject campo in linePath) {
			if (campo.gameObject.transform.GetComponent<ScriptField> ().typeList == null
			    || campo.gameObject.transform.GetComponent<ScriptField> ().typeList.Count == 0)
				search = false;

			if (linePath.Count > 0) {
				
				for (int i = 0; i < linePath.Count; i++) {

					if (linePath [i].gameObject == box.gameObject)
						auxInt = i;

					if (linePath [i].gameObject.transform.GetComponent<ScriptField> ().typeList.Count > 0) {

						for (int j = 0; j < linePath [i].gameObject.transform.GetComponent<ScriptField> ().typeList.Count; j++) {

							if (linePath [i].gameObject.transform.GetComponent<ScriptField> ().typeList [j].gameObject.tag == "Enemy" && i >= auxInt)
								search = true;

						}

					}

				}
			}

		}
			/*
			if (campo.gameObject.transform.GetComponent<ScriptField> ().typeList.Count > 0) {
				foreach (GameObject tipo in campo.gameObject.transform.GetComponent<ScriptField> ().typeList) {
					if (tipo != null && tipo.gameObject.tag == "Enemy") {
						search = true;
					}
				}
			}
		}*/

	}

	void OnTriggerEnter2D(Collider2D other){
		/*
		if (other.gameObject.tag == "Box") {
			line = null;
			if (linePath != null)
				linePath.Clear ();
			line = other.transform.parent.gameObject;
			LineIndentificator lineList = line.transform.GetComponent<LineIndentificator> ();
			foreach (GameObject campo in lineList.path) {
				linePath.Add (campo);
			}
		}*/
	}

	void OnTriggerStay2D(Collider2D other){

		if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "atkEnemy"){
			activate = true;
		}

		if (other.gameObject.tag == "Box") {
			box = other.gameObject;
		}

	}

	void atira(){
		if (repete == false) {
			InvokeRepeating ("launch", 0.3f, speed);
		}
		repete = true;
	}

	void launch(){
		GameObject clone = Instantiate (projetil, transform.position, Quaternion.identity);
		//clone.gameObject.transform.SetParent (gameObject.transform);
	}
}
