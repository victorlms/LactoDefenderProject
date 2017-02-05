using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class atkPlayer : MonoBehaviour {

	public bool activate = false;
	public GameObject projetil;
	public float speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		while(activate){
			Invoke ("launch", speed);
		}

	}

	void launch(){
		Instantiate (projetil);
	}
}
