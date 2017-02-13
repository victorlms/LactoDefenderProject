using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carta : MonoBehaviour {

	public float speed = 5.0f;

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
		
		vetorOriginal = new Vector2(transform.position.x, transform.position.y);
	
	}

	void Update () 
	{
		Vector2 objPosition = Camera.main.ScreenToWorldPoint(vetorOriginal);

		if (Input.touchCount > 0) {

			if (Input.GetTouch (0).phase == TouchPhase.Began && Input.GetTouch (0).position == objPosition)
			{

				Vector2 _deltaPosition = Input.GetTouch (0).deltaPosition;


				player = Instantiate (player, _deltaPosition, transform.rotation);

				if (Input.GetTouch (0).phase == TouchPhase.Moved) {

					player.transform.position = Vector2.Lerp (player.transform.position, Input.GetTouch (0).deltaPosition, speed * Time.deltaTime);

				}

			}
		}
			
		_mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);

	}//FECHA_UPDATE	

	void OnMouseDown(){

		Instantiate (player, _mousePosition, Quaternion.identity);

	}
		

}//Fecha_CartaVaca
