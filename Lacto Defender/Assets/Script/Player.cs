using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed = 0.1f;

	public Collision2D outro;

	public GameObject card;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved) 
		{
			// Get movement of the finger since last frame
			Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;


			//Testa se o colisor está vazia
			if(outro)
			{
				Instantiate(card,/**VETOR**/,Quaternion.identity);

				transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);

				Destroy(this);

				//INSTANCIAR PERSONAGEM RESPECTIVO



			}

			// Move object across XY plane

		
		}

	}//FECHA_UPDATE

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.collider == true) 
		{
			outro = other;
			outro.collider.enabled = false;
			//other.collider.enabled = outro;
		}


	}//FECHA-COLISSION-ENTER
}
