using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptField : MonoBehaviour {

	public bool freeFloor = true;
	public bool walk = false;
	public bool walk2 = false;
	public bool preparaCampo = false;
	public bool cancelaCampo = false;
	public GameObject type;

	// Use this for initialization
	void Start () {

		type = null;
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other){



		}


	void OnTriggerStay2D(Collider2D other){
		
		
		if (other.CompareTag ("Player") ) {
			
			type = other.gameObject;

			if (other.gameObject.transform.GetComponent<Card> ().walking && other.gameObject.transform.GetComponent<Card> ().field.gameObject == gameObject) {

				other.gameObject.transform.GetComponent<Card> ().walking = false;
				other.gameObject.transform.position = transform.position;
				other.gameObject.transform.GetComponent<spawnPlayer>().onField = true;
				other.gameObject.transform.GetComponent<Card> ().field = null;
				preparaCampo = false;
				cancelaCampo = false;

			}

		}
		else if(other.CompareTag ("Enemy")){
			if(type == null)
				type = other.gameObject;
			}



	}

	void OnTriggerExit2D(Collider2D other){

			
		if (other.tag == "Player" || other.tag == "Enemy") 
			type = null;

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
