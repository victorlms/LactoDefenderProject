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
	//public GameObject type;
	public List<GameObject> typeList;

	// Use this for initialization
	void Start () {
		typeList = new List <GameObject>();
		//type = null;
	}

	// Update is called once per frame
	void Update () {

		if (typeList.Count > 0) {
			foreach (GameObject tipo in typeList) {

				if (tipo == null)
					typeList.Remove (tipo);

			}
		}

	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.gameObject.tag == "Player" || other.gameObject.tag == "Enemy")
			typeList.Add (other.gameObject);
		}


	void OnTriggerStay2D(Collider2D other){
		
		
		if (other.CompareTag ("Player") ) {
			
			//type = other.gameObject;

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



		}
	//	else if(other.CompareTag ("Enemy")){
			//if(type == null)
			//	type = other.gameObject;
		//	}



	}

	void OnTriggerExit2D(Collider2D other){


		if (other.tag == "Player" || other.tag == "Enemy") {

			foreach(GameObject tipo in typeList)
				if (typeList != null && tipo == other.gameObject) 
				freeFloor = true;

			//type = null;
		}

		typeList.Remove (other.gameObject);
		if (typeList.Count == 0)
			typeList.Clear ();

		preparaCampo = false;
		cancelaCampo = false;

	}
		




	void OnMouseDown(){

		if (freeFloor) {
			preparaCampo = true;
		} else {
			cancelaCampo = true;
		}
	}

}
