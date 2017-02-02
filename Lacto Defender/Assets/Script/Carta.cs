using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour {

	public float speed = 2.0f, _horizontalLimit = 2.5f, _verticalLimit = 2.5f;

	public bool boxEmpty;
	public bool permission;

	ScriptField reconhece;

	public GameObject clone;

	static Vector3 vetorOriginal;
	Transform cachedTransform;


	void start ()
	{
		cachedTransform = transform;
		vetorOriginal = cachedTransform.position;
	}

	void Update () 
	{
		Vector2 deltaPosition = Input.GetTouch (0).deltaPosition;

		switch (Input.GetTouch (0).phase) {
			
		case TouchPhase.Began:
			break;

		case TouchPhase.Moved:
			DragObject (deltaPosition);
			break;

		case TouchPhase.Ended:
			break;

		}

	}//FECHA_UPDATE	

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.CompareTag ("Box")) {
			boxEmpty = other.gameObject.GetComponent<ScriptField> ().freeFloor;
			permission = true;
		} else {
			permission = false;
		}//ELSE

		}//FECHA_OnTriggerEnter

	void OnTriggerStay2D(Collider2D other)
	{
		if (permission == true) {
			
			//if (Input.GetTouch (0).phase == TouchPhase.Ended && boxEmpty == true) {
			if (Input.GetMouseButtonUp (0) && boxEmpty == true) {
				permission = true;
				Destroy (gameObject);//carta explode, surge mooh
			} else if (boxEmpty == false) {
				permission = false;
				boxEmpty = false;
				transform.position = Vector3.Lerp (transform.position, vetorOriginal, Time.deltaTime * speed);
	
			}//ELSE_IF
		}
	}//FECHA_OnTriggerStay

	void OnTriggerExit2D(Collider2D other)
	{
		if(permission == true)
		{
			Instantiate (clone, other.gameObject.GetComponent<Transform> ().position, other.gameObject.GetComponent<Transform> ().rotation);
			boxEmpty = false;
			permission = false;
			other.gameObject.GetComponent<ScriptField> ().freeFloor = false;
			Debug.Log ("Valor passou de TRUE para FALSE");
		} else {
			Debug.Log ("Indisponível");
		}
	}//Fecha_OnTriggerExit

	void DragObject(Vector2 deltaPosition){

		cachedTransform.position = Vector2.Lerp (vetorOriginal, deltaPosition, Time.deltaTime * speed);
	}
		
}//Fecha_CartaVaca
