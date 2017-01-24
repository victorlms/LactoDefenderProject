using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineIndentificator : MonoBehaviour {

	public GameObject boxPath;
	public List<GameObject> path;
	public int qtd;

	// Use this for initialization
	void Start ()
	{
		path = new List<GameObject>();

		qtd = transform.childCount;

		for (int i = 0; i < qtd ; i++) 
		{
			boxPath = gameObject.transform.GetChild (i).gameObject;
			path.Add (boxPath);
		}

	}
	// Update is called once per frame
	void Update () {

	}


}
