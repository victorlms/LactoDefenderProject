using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoPadraoPlayer : MonoBehaviour {

	List<GameObject> line;
	List<GameObject> lineUp;
	List<GameObject> lineDown;

	int qtd;

	bool teste = false;

	GameObject verifica;

	void Start () {
		line = new List<GameObject>;
	}//FECHA_START


	void Update () {

	}//FECHA_UPDATE

	void OnTriggerEnter2D(Collider2D other)
	{


		if (gameObject.tag = ("Linha1")) {

			line = gameObject.GetComponentInParent<LineIndentificator> ().path;

		}
			

	}//FECHA_OnTriggerEnter2D

	void OnTriggerStay2D(Collider2D other)
	{


		for (int i = 0; i < qtd; i++) {

			verifica = line.transform.GetChild (i).gameObject;

			switch (verifica.gameObject.GetComponent<scriptCampo> ().tipo) {
			case  gameObject.tag("Inimigo"):
				//ataca
				break;
			default :
				//parado
				break;
			}

		}

		if (Input.GetTouch (0).phase == TouchPhase.Began) {

		}
	}//FECHA_OnTriggerStay2D
}
