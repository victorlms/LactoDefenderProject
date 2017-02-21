using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptField : MonoBehaviour {

	public bool onPath = false;
	public bool freeFloor = true;
	public bool walk = false;
	public bool walk2 = false;
	public bool preparaCampo = false;
	public bool cancelaCampo = false;
	public bool preparaCampoSapo = false;
	public List<GameObject> typeList;

	public GameObject walkObject;


	// Use this for initialization
	void Start () {
		typeList = new List <GameObject>();
	}

	// Update is called once per frame
	void Update () {

		if (typeList.Count > 0) {
			
			foreach (GameObject tipo in typeList) {
				if (tipo == null) {
					typeList.Remove (tipo);
				
				}
			}

		}


	

	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
			typeList.Add (other.gameObject);
		}


	void OnTriggerStay2D(Collider2D other){
		
		
		if (other.CompareTag ("Player") ) {
			

			if (other.gameObject.transform.GetComponent<movimentoMoohMooh> () != null) {
				if (other.gameObject.transform.GetComponent<movimentoMoohMooh> ().walking
					&& other.gameObject.transform.GetComponent<movimentoMoohMooh> ().field.gameObject == gameObject) {

					other.gameObject.transform.GetComponent<movimentoMoohMooh> ().walking = false;

					other.gameObject.transform.position = transform.position;
					other.gameObject.transform.GetComponent<spawnPlayerMoohMooh> ().onField = true;
					other.gameObject.transform.GetComponent<movimentoMoohMooh> ().field = null;
					preparaCampo = false;
					cancelaCampo = false;
					other.gameObject.transform.GetComponent<movimentoMoohMooh> ().prepara = false;

				}
			}

			if (other.gameObject.transform.GetComponent<movimentoRaMooh> () != null) {
				if (other.gameObject.transform.GetComponent<movimentoRaMooh> ().walking
				   && other.gameObject.transform.GetComponent<movimentoRaMooh> ().field.gameObject == gameObject) {

					other.gameObject.transform.GetComponent<movimentoRaMooh> ().walking = false;

					other.gameObject.transform.position = transform.position;
					other.gameObject.transform.GetComponent<spawnPlayerRaMooh> ().onField = true;
					other.gameObject.transform.GetComponent<movimentoRaMooh> ().field = null;
					preparaCampo = false;
					cancelaCampo = false;
					other.gameObject.transform.GetComponent<movimentoRaMooh> ().prepara = false;

				}
			}

			if (other.gameObject.transform.GetComponent<movimentoSapo> () != null) {
				if (other.gameObject.transform.GetComponent<movimentoSapo> ().walking
					&& other.gameObject.transform.GetComponent<movimentoSapo> ().field.gameObject == gameObject) {

					other.gameObject.transform.GetComponent<movimentoSapo> ().walking = false;

					other.gameObject.transform.position = transform.position;
					other.gameObject.transform.GetComponent<spawnPlayerSapo> ().onField = true;
					other.gameObject.transform.GetComponent<movimentoSapo> ().field = null;
					preparaCampo = false;
					cancelaCampo = false;
					other.gameObject.transform.GetComponent<movimentoSapo> ().prepara = false;

				}
			}



		}




	}

	void OnTriggerExit2D(Collider2D other){


		if (other.tag == "Player" || other.tag == "Enemy") {

			foreach(GameObject tipo in typeList)
				if (typeList != null && tipo == other.gameObject) 
				freeFloor = true;

		}

		typeList.Remove (other.gameObject);
		if (typeList.Count == 0)
			typeList.Clear ();

		preparaCampo = false;
		cancelaCampo = false;

	}
		




	void OnMouseDown(){

		if (freeFloor && walkObject != null && onPath) {

			preparaCampo = true;

		} else {
			cancelaCampo = true;
		}
	}

}
