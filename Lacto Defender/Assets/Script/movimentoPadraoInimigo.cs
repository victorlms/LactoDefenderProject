using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoPadraoInimigo : MonoBehaviour 
{
	
	public float Caminhada;
	public int num_de_colisões;
	List<GameObject> line;
	public GameObject confere_tipo;

	void start()
	{
		
	}


	void Update ()
	{
		transform.Translate (Vector3.left * Caminhada * Time.deltaTime);


	
	}
	void OnTriggerStay2D(Collider2D campo)
	{
		
		line = campo.transform.GetComponentInParent <LineIndentificator> ().path;
	
		foreach( GameObject objeto in line)
		{
			confere_tipo = objeto.transform.GetComponentInParent <scriptCampo> ().tipo;
			
			if (confere_tipo.CompareTag("Player") && campo.transform.parent.tag == objeto.transform.parent.tag)
				{
					//ENTRA EM MODO DE ATAQUE
					num_de_colisões++;
				}
		}
	}

}
