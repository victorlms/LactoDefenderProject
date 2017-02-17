using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atkPlayerRaMooh : MonoBehaviour {

	public bool repete = false;
	public bool activate = false;
	public bool search = false;
	public GameObject line;
	public List<GameObject> linePath;

	public GameObject projetil;
	public float speed;

	// Use this for initialization
	void Start () {
		linePath = new List<GameObject> ();

	}

	// Update is called once per frame
	void Update () {

		if (gameObject.transform.GetComponent<movimentoRaMooh> ().walking == false 
			&& gameObject.transform.GetComponent<spawnPlayerRaMooh>().onField == true 
			&& gameObject.transform.GetComponent<spawnPlayerRaMooh>().spawn == false) {

			foreach (GameObject campo in linePath) {
				if(campo.gameObject.transform.GetComponent<ScriptField> ().type != null)
				if (campo.gameObject.transform.GetComponent<ScriptField> ().type.gameObject.tag == "Enemy") {
					search = true;
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
			if (campo.gameObject.transform.GetComponent<ScriptField> ().type == null)
				search = false;

			if(campo.gameObject.transform.GetComponent<ScriptField> ().type != null)
			if (campo.gameObject.transform.GetComponent<ScriptField> ().type.gameObject.tag == "Enemy") {
				search = true;
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.tag == "Box") {
			line = null;
			if (linePath != null)
				linePath.Clear ();
			line = other.transform.parent.gameObject;
			LineIndentificator lineList = line.transform.GetComponent<LineIndentificator> ();
			foreach (GameObject campo in lineList.path) {
				linePath.Add (campo);
			}
		}
	}

	void OnTriggerStay2D(Collider2D other){

		if(other.gameObject.tag == "Enemy" || other.gameObject.tag == "atkEnemy"){
			activate = true;
		}

	}

	void atira(){
		if (repete == false) {
			InvokeRepeating ("launch", 0.3f, 0.2f);
		}
		repete = true;
	}

	void launch(){
		Instantiate (projetil, transform.position, Quaternion.identity);
	}
}
