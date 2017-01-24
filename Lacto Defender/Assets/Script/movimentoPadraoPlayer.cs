using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoPadraoPlayer : MonoBehaviour {

	List<GameObject> line;
	int qtd;
	bool teste = false;


	void Start () {



	}//FECHA_START
	

	void Update () {

	}//FECHA_UPDATE

	void OnTriggerEnter2D(Collider2D other)
	{
		List<GameObject> testaPath = other.gameObject.GetComponent<LineIndentificator> ().path;

		if (line != testaPath) {
			line = testaPath;
			qtd = line.Count;
			teste = true;
		}

	}//FECHA_OnTriggerEnter2D

	void OnTriggerStay2D(Collider2D other)
	{
		if (Input.GetTouch (0).phase == TouchPhase.Began) {
			
		}
	}//FECHA_OnTriggerStay2D
}
