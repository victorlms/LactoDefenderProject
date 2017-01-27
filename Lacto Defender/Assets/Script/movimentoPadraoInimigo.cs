using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoPadraoInimigo : MonoBehaviour 
{
	//PRECISO DO SPAWN DEFINIDO PRA PODER SABER RELAÇÃO ALIEN /  VACA;
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
			
			if (confere_tipo.CompareTag("Player"));// && objeto.transform.parent.CompareTag(//conferir se é a mesma linha q o aien))
				{
					num_de_colisões++;
				}
		}
	}

}
