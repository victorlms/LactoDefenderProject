using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaVaca : MonoBehaviour {

	public float speed;

	public bool disponibilidade2;
	bool disponibilidade3;
	ScriptCampo reconhece;
	//Vector2 vetorOriginal = transform.position;

	public GameObject clone;

	void Update () {

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) {
			Vector2 touchDeltaPosition = Input.GetTouch (0).deltaPosition;
			transform.Translate (-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
		}


	}//FECHA_UPDATE	

	void OnTriggerEnter2D(Collider2D other)
	{

	}//FECHA_OnTriggerEnter

	void OnTriggerStay2D(Collider2D other)
	{
		if (Input.GetTouch (0).phase == TouchPhase.Ended && disponibilidade2 == true) {
			disponibilidade3 = true;
			Destroy (gameObject);
		} else {
			disponibilidade3 = false;
			Destroy (gameObject);
		}
	}//FECHA_OnTriggerStay

	void OnTriggerExit2D(Collider2D other)
	{
		if(disponibilidade3 == true)
		{
			Instantiate (clone, other.gameObject.GetComponent<Transform> ().position, other.gameObject.GetComponent<Transform> ().rotation);
			disponibilidade2 = false;
			disponibilidade3 = false;
			Debug.Log ("Valor passou de TRUE para FALSE");
			//transform.Translate(vetorOriginal.x * speed, vetorOriginal.y * speed, 0);
		} else {
			Debug.Log ("Indisponível");
		}
	}//Fecha_OnTriggerExit

}//Fecha_CartaVaca
