using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPlayerMiniMooh : MonoBehaviour {


	Vector2 _mousePosition;

	public bool spawn;
	public bool onMouse;

	public GameObject path;
	public GameObject fieldSpawn;

	public List<GameObject> objeto;


	void Start () {

		objeto = new List<GameObject>();
		spawn = true;
		onMouse = true;
	}
	
	void Update () {

		if (spawn == true) {

			if (onMouse == true) {
				_mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
				//transform.position = Vector2.Lerp (gameObject.transform.position, _mousePosition, speed * Time.deltaTime);
				transform.position = _mousePosition;
				//gameObject.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (1, 0, 0, 0.5f);
			}
		}

	}

	void OnTriggerEnter2D(Collider2D other){

		if (spawn) {

			if (other.gameObject.tag == "Box") {

				objeto.Add (other.gameObject);

			}

		}


	}//ON TRIGGER ENTER

	void OnTriggerStay2D(Collider2D other){

		if (spawn == true && other.gameObject.tag == "Box") {

			if (other.gameObject == objeto [0]) {

				if (Input.GetMouseButtonDown (0) && other.gameObject == objeto [0]) {

					path = other.gameObject.transform.parent.gameObject;
					fieldSpawn = path.transform.GetComponent<LineIndentificator> ().path [0];

					transform.position = new Vector2 (fieldSpawn.transform.position.x - 2, fieldSpawn.transform.position.y);

					spawn = false;
				}

			}

		}

	}

	void OnTriggerExit2D(Collider2D other){

		if (spawn == true) {

			if(objeto.Count >0)
			if (other.gameObject == objeto [0] && other.gameObject.tag == "Box") {

				objeto.Remove (other.gameObject);

			}
		}


	}
}
