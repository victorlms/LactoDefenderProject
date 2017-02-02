using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour {

	public float speed = 2.0f;

	public bool boxEmpty;
	public bool permission;

	ScriptField reconhece;

	public GameObject clone;

	static Vector3 vetorOriginal;


	void start ()
	{
		vetorOriginal = transform.position;
	}

	void Update () 
	{

	}//FECHA_UPDATE	

	void OnTriggerEnter2D(Collider2D other)
	{
		boxEmpty = other.gameObject.GetComponent<ScriptField> ().freeFloor;
	}//FECHA_OnTriggerEnter

	void OnTriggerStay2D(Collider2D other)
	{
		//if (Input.GetTouch (0).phase == TouchPhase.Ended && boxEmpty == true) {
		if(Input.GetMouseButton(0) && boxEmpty == true){
		permission = true;
			Destroy (gameObject);//carta explode, surge mooh
		} else {
			permission = false;
			boxEmpty = false;
			transform.position = Vector3.Lerp (transform.position, vetorOriginal, Time.deltaTime * speed);
	
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

}//Fecha_CartaVaca
