using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineIndentificator : MonoBehaviour {

	public GameObject boxPath;
	public List<GameObject> path;

	// Use this for initialization
	void Start ()
	{

		for (int i = 0; i < 7; i++) 
		{
			boxPath = gameObject.transform.GetChild (i).gameObject;
			path.Add (boxPath);
		}

	}
	// Update is called once per frame
	void Update () {
		
	}
}
