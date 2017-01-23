using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineIndentificator : MonoBehaviour {

	public GameObject boxPath00;
	public GameObject boxPath01;
	public GameObject boxPath02;
	public GameObject boxPath03;
	public GameObject boxPath04;
	public GameObject boxPath05;
	public GameObject boxPath06;

	public List<GameObject> line;
	// Use this for initialization
	void Start ()
	{
		line = new List<GameObject> ();
		line.Add (boxPath00);
		line.Add (boxPath01);
		line.Add (boxPath02);
		line.Add (boxPath03);
		line.Add (boxPath04);
		line.Add (boxPath05);
		line.Add (boxPath06);


	}
	// Update is called once per frame
	void Update () {
		
	}
}
