using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoPadraoInimigo : MonoBehaviour 
{
	public float Caminhada;
	public int num_de_colisões;
	public List<GameObject> linhas;
	public GameObject espaços;

	//void start ()
	//{
	//	linhas = new List<GameObject> ();
	//	espaços = gameObject.transform.GetChild (1).gameObject;
	//	linhas.Add(espaços);
	//}

	void Update ()
	{
		transform.Translate (Vector3.left * Caminhada * Time.deltaTime);

	
	}
	void OnTriggerStay2D(Collider2D campo)
	{
	
		if (campo.gameObject.tag == "Box7") {
			num_de_colisões= num_de_colisões+1;
		}
	
	}

}
