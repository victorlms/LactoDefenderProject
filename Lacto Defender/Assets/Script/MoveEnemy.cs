using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour 
{
	
	float walk;
	List<GameObject> line;
	GameObject checkType;

	void start()
	{
		
	}


	void Update ()
	{
		walk = gameObject.GetComponent<StatusEnemy> ().speed;
		transform.Translate (Vector3.left * walk * Time.deltaTime);


	
	}
	void OnTriggerStay2D(Collider2D other)
	{
		
		line = other.transform.GetComponentInParent <LineIndentificator> ().path;
	
		foreach( GameObject obj in line)
		{
			checkType = obj.transform.GetComponentInParent <ScriptField> ().type;
			
			if (checkType.CompareTag("Player") && other.transform.parent.tag == obj.transform.parent.tag)
				{
					//ENTRA EM MODO DE ATAQUE
				Debug.Log("tesrgjhgif");
					
				}
		}
	}

}
