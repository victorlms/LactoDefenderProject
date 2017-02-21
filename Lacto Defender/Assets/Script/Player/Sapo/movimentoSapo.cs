using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoSapo : MonoBehaviour {

	public GameObject grid;
	public GameObject field;
	public bool prepara = false;
	public bool clica = false;
	public bool full = false;
	public bool fill = false;
	public bool walking = false;

	public List<GameObject> path;

	void Start () {
		path = new List<GameObject> ();
	}

	void Update () {

		if (fill) {

			foreach (GameObject linha in grid.transform.GetComponent<LineIndentificator>().path) {

				foreach (GameObject campo in linha.transform.GetComponent<LineIndentificator>().path) {

					path.Add (campo);

				}

			}
			full = true;
		}

		if (prepara) {
			foreach (GameObject campo in path) {
				if (campo.transform.GetComponent<ScriptField> ().preparaCampo == true 
					&& prepara == true
					&& campo.transform.GetComponent<ScriptField> ().walkObject == gameObject ) {
					field = campo.gameObject;
					walking = true;
				}
			}
		}

		if (walking) {
			transform.position = Vector2.Lerp (transform.position, field.transform.position, Time.deltaTime * 4);
			prepara = false;
		}




	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Box") {

			grid = other.gameObject.transform.parent.parent.gameObject;
			if (full == false)
				fill = true;
		}

	}

	void OnMouseDown(){

		if (clica) {

			foreach(GameObject campo in path){

				campo.gameObject.transform.GetComponent<ScriptField> ().walkObject = gameObject;
				campo.gameObject.transform.GetComponent<ScriptField> ().onPath = true;

			}

			prepara = true;
			clica = false;

		}

		clica = true;

	}
}
