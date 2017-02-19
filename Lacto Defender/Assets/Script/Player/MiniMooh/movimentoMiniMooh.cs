using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoMiniMooh : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (gameObject.transform.GetComponent<spawnPlayerMiniMooh> ().spawn == false) {

			transform.Translate (Vector2.right * Time.deltaTime * 5);

		}

	}
}
