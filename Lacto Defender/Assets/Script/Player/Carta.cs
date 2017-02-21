using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour {

	public float speed;
	public float tempo;

	public bool boxEmpty;
	public bool permission;

	Vector2 offset;

	ScriptField reconhece;

	public GameObject player;

	Vector2 vetorOriginal;
	Vector2 rotaOriginal;
	Vector2 _mousePosition;
	void start ()
	{
		tempo = 0;
		vetorOriginal = new Vector2(transform.position.x, transform.position.y);
	
	}

	void Update () 
	{
		if (tempo <= 0) {
			
			Vector2 objPosition = Camera.main.ScreenToWorldPoint (vetorOriginal);

			if (Input.touchCount > 0) {

				if (Input.GetTouch (0).phase == TouchPhase.Began && Input.GetTouch (0).position == objPosition) {

					Vector2 _deltaPosition = Input.GetTouch (0).deltaPosition;


					player = Instantiate (player, _deltaPosition, transform.rotation);

					if (Input.GetTouch (0).phase == TouchPhase.Moved) {

						player.transform.position = Vector2.Lerp (player.transform.position, Input.GetTouch (0).deltaPosition, speed * Time.deltaTime);

					}

				}
			}

			_mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			
		} else {
			tempo -= Time.deltaTime;
		}

		if (tempo > 0)
			gameObject.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (1, 1, 1, 0.5f);
		else
			gameObject.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (1, 1, 1, 1);

	}//FECHA_UPDATE	

	void OnMouseDown(){

		if (tempo <= 0) {
			Instantiate (player, _mousePosition, Quaternion.identity);
		}

		tempo = speed;

	}
		

}//Fecha_CartaVaca
