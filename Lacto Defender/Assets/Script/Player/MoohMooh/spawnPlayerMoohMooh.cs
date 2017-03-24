using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlayerMoohMooh : MonoBehaviour {


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
				//transform.position = Vector2.Lerp (gameObject.transform.position, _mousePosition, speed * Time.deltaTime);
				transform.position = _mousePosition;
				//gameObject.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (1, 0, 0, 0.5f);
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

		
		if (spawn == false && gameObject.GetComponent<movimentoMoohMooh> ().walking == true) {

			if (gameObject.GetComponent<movimentoMoohMooh> ().field.gameObject == other.gameObject) {
				posiciona = true;
			}

		}

	}//VOID_ON_TRIGGER_ENTER

	void OnTriggerStay2D(Collider2D other){

		if (other.tag == "Box" && spawn == true) {

			if (other.gameObject == objeto [0].gameObject) {




				/*
				if (Input.GetTouch (0).phase == TouchPhase.Ended) {

					if (permission == true && objeto [0].GetComponent<ScriptField> ().freeFloor == true) {

						transform.position = Vector2.Lerp (transform.position, other.gameObject.GetComponent<Transform> ().position, speed * Time.deltaTime);
						other.gameObject.GetComponent<ScriptField> ().freeFloor = false;
						onField = true;
						boxEmpty = false;
						permission = false;
						gameObject.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (1, 0, 0, 1);
					}
					if (onField == false && permission == false) {

						Debug.Log ("Sem Permissão para criar");
						Destroy (gameObject);

					}
				}
			


*/
				if (Input.GetMouseButtonDown (0) && other.gameObject == objeto [0]) {

					if (permission == true && other.transform.GetComponent<ScriptField> ().freeFloor == true) {

						//Transform fieldTransform = other.transform.gameObject.GetComponent<Transform> ();
						//Vector2 fieldPosition = new Vector2 (fieldTransform.position.x, fieldTransform.position.y);

						other.gameObject.GetComponent<ScriptField> ().freeFloor = false;

						onField = true;
						onMouse = false;
						boxEmpty = false;
						permission = false;
						spawn = false;
						gameObject.transform.GetComponent<novoMovimentoMoohMooh> ().criaLista = true;

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

			/*if (gameObject.transform.GetComponent<movimentoMoohMooh> ().walking) {
				if (onField == false && posiciona == true && other.gameObject == objeto[1].gameObject) {

					gameObject.transform.position = other.gameObject.transform.position;
					gameObject.transform.GetComponent<movimentoMoohMooh> ().walking = false;

				}
			}*/
				

		}

		if (spawn == false && other.tag == "Box") {

			if (gameObject.transform.GetComponent<movimentoMoohMooh> ().walking) {
				if (onField == false && posiciona == true && other.gameObject == gameObject.transform.GetComponent<movimentoMoohMooh>().objeto[1].gameObject) {

					gameObject.transform.position = other.gameObject.transform.position;
					gameObject.transform.GetComponent<movimentoMoohMooh> ().walking = false;

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
							//	field.transform.GetComponent<ScriptField> ().freeFloor = true;
							other.gameObject.transform.GetComponent<ScriptField> ().freeFloor = true;
							objeto.Remove (objeto[i].gameObject);

						}

					}

			}
		}
	}//TRIGGEREXTI

}
