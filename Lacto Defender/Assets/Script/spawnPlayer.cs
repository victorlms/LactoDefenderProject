using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlayer : MonoBehaviour {

	public float speed = 100;

	public bool boxEmpty = false;
	public bool permission = false;
	public bool onField = false;
	bool gatEnt = false;
	bool gatSta = false;
	public ScriptField campo;

	Vector2 _mousePosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		_mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

		if (onField == false) {
			//transform.position = Vector2.Lerp (gameObject.transform.position, _mousePosition, speed * Time.deltaTime);
			transform.position = _mousePosition;
			gameObject.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (1, 0, 0, 0.5f);
		}

	
	}

	void OnTriggerEnter2D(Collider2D other){



		if (other.tag == "Box") {
			boxEmpty = other.gameObject.GetComponent<ScriptField> ().freeFloor;
			if (boxEmpty)
				permission = true;
		} else {
			permission = false;
		}//ELSE
			


	}

	void OnTriggerStay2D(Collider2D other){
		

			/*	if (Input.GetTouch (0).phase == TouchPhase.Ended) {

			if (permission) {

				transform.position = Vector2.Lerp (transform.position, other.gameObject.GetComponent<Transform> ().position, speed * Time.deltaTime);
				campo = other.gameObject.GetComponent<ScriptField> ();
				campo.freeFloor = false;
				onField = true;
			} else {

				Debug.Log ("Sem Permissão para criar");
				Destroy (gameObject);

			}

		}*/



		if (other.tag == "Box") {
			if (Input.GetMouseButtonDown (0)) {

				if (permission == true) {

					Transform fieldTransform = other.transform.gameObject.GetComponent<Transform> ();
					Vector2 fieldPosition = new Vector2 (fieldTransform.position.x, fieldTransform.position.y);

					other.gameObject.GetComponent<ScriptField> ().freeFloor = false;

					onField = true;
					boxEmpty = false;
					permission = false;
					gameObject.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (1, 0, 0, 1);

				} else if (onField == false && permission == false) {

					Debug.Log ("Sem Permissão para criar");
					Destroy (gameObject);

				}

			}
				
		}

		if (onField == true) 
			gameObject.transform.position = Vector2.Lerp (transform.position, other.transform.position, speed * Time.deltaTime);
		



	}//ONTRIGGERSTAY


	void OnTriggerExit2D(Collider2D other){

		gatEnt = false;
		gatSta = false;

	}

}
