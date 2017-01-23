using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CartaVaca : MonoBehaviour {

	public float speed;

	public bool boxEmpty;
	public bool disponibilidade3;
	scriptCampo reconhece;
	//Vector2 vetorOriginal = transform.position;

	public GameObject clone;

	void Update () 
	{

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
		if (Input.GetTouch (0).phase == TouchPhase.Ended && boxEmpty == true) {
			disponibilidade3 = true;
			Destroy (gameObject);//carta explode, surge vaca
		} else {
			disponibilidade3 = false;
			Destroy (gameObject);//carta volta para a "mao"
		}
	}//FECHA_OnTriggerStay

	void OnTriggerExit2D(Collider2D other)
	{
		if(disponibilidade3 == true)
		{
			Instantiate (clone, other.gameObject.GetComponent<Transform> ().position, other.gameObject.GetComponent<Transform> ().rotation);
			boxEmpty = false;
			disponibilidade3 = false;
			Debug.Log ("Valor passou de TRUE para FALSE");
			//transform.Translate(vetorOriginal.x * speed, vetorOriginal.y * speed, 0);
		} else {
			Debug.Log ("Indisponível");
		}
	}//Fecha_OnTriggerExit

}//Fecha_CartaVaca
