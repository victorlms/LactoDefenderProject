using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour {
	

	public GameObject line;
	public GameObject lineUp;
	public GameObject lineUp2;
	public GameObject lineDown;
	public GameObject lineDown2;

	public List<GameObject> linePath;
	public List<GameObject> lineUpPath;
	public List<GameObject> lineUpPath2;
	public List<GameObject> lineDownPath;
	public List<GameObject> lineDownPath2;
	public List<GameObject> walk;


	public List<GameObject> objeto;

	GameObject grid;

	public int contta;
	public float speed;

	Transform destino;

	void Start () {
		linePath = new List <GameObject> ();
		lineUpPath = new List<GameObject>();
		lineUpPath2 = new List<GameObject>();
		lineDownPath = new List<GameObject>();
		lineDownPath2 = new List<GameObject>();
		walk = new List<GameObject> ();

		objeto = new List<GameObject> ();


	}

	void Update () {

	}

	void OnTriggerEnter2D(Collider2D other){
		
		if (other.tag == "Box"){
		objeto.Add (other.gameObject);

			line = null;
			lineDown = null;
			lineDown2 = null;
			lineUp = null;
			lineUp = null;

			if (linePath != null)
				linePath.Clear ();
			if (lineDownPath != null)
				lineDownPath.Clear ();
			if (lineDownPath2 != null)
				lineDownPath2.Clear ();
			if (lineUpPath != null)
				lineUpPath.Clear ();
			if (lineUpPath2 != null)
				lineUpPath2.Clear ();
			if (walk != null)
				walk.Clear ();



			line = other.transform.parent.gameObject;
			LineIndentificator lineList = line.transform.GetComponent<LineIndentificator>();

			contta = lineList.path.Count;
			grid = line.gameObject.transform.parent.gameObject;


			/*
			for (int i = 0; i < contta; i++) {

				linePath.Add (lineList.path [i]);
				Debug.Log ("Percorre");

			}*/

			foreach (GameObject campo in lineList.path) {
				linePath.Add (campo);
			}

			switch (line.gameObject.transform.tag) {

			case "Linha1":
				lineDown = null;
				lineDown2 = null;
				lineUp = grid.transform.GetChild (1).gameObject;
				lineList = lineUp.transform.GetComponent<LineIndentificator> ();
				foreach (GameObject campo in lineList.path) {
					lineUpPath.Add (campo);				
				}
				lineUp2 = grid.transform.GetChild (2).gameObject;
				lineList = lineUp2.transform.GetComponent<LineIndentificator> ();
				foreach (GameObject campo in lineList.path) {
					lineUpPath2.Add (campo);				
				}
				break;



			case "Linha2":
				lineDown = grid.transform.GetChild (0).gameObject;
				lineList = lineDown.transform.GetComponent<LineIndentificator> ();
				foreach (GameObject campo in lineList.path) {
					lineDownPath.Add (campo);				
				}
				lineDown2 = null;
				lineUp = grid.transform.GetChild (2).gameObject;
				lineList = lineUp.transform.GetComponent<LineIndentificator> ();
				foreach (GameObject campo in lineList.path) {
					lineUpPath.Add (campo);				
				}
				lineUp2 = grid.transform.GetChild (3).gameObject;
				lineList = lineUp2.transform.GetComponent<LineIndentificator> ();
				foreach (GameObject campo in lineList.path) {
					lineUpPath2.Add (campo);				
				}
				break;



			case "Linha3":
				lineDown = grid.transform.GetChild (1).gameObject;
				lineList = lineDown.transform.GetComponent<LineIndentificator> ();
				foreach (GameObject campo in lineList.path) {
					lineDownPath.Add (campo);				
				}
				lineDown2 = grid.transform.GetChild (0).gameObject;
				lineList = lineDown2.transform.GetComponent<LineIndentificator> ();
				foreach (GameObject campo in lineList.path) {
					lineDownPath2.Add (campo);				
				}
				lineUp = grid.transform.GetChild (3).gameObject;
				lineList = lineUp.transform.GetComponent<LineIndentificator> ();
				foreach (GameObject campo in lineList.path) {
					lineUpPath.Add (campo);				
				}
				lineUp2 = grid.transform.GetChild (4).gameObject;
				lineList = lineUp2.transform.GetComponent<LineIndentificator> ();
				foreach (GameObject campo in lineList.path) {
					lineUpPath2.Add (campo);				
				}
				break;

			case "Linha4":
				lineDown = grid.transform.GetChild (2).gameObject;
				lineList = lineDown.transform.GetComponent<LineIndentificator> ();
				foreach (GameObject campo in lineList.path) {
					lineDownPath.Add (campo);				
				}
				lineDown2 = grid.transform.GetChild (1).gameObject;
				lineList = lineDown2.transform.GetComponent<LineIndentificator> ();
				foreach (GameObject campo in lineList.path) {
					lineDownPath2.Add (campo);				
				}
				lineUp = grid.transform.GetChild (4).gameObject;
				lineList = lineUp.transform.GetComponent<LineIndentificator> ();
				foreach (GameObject campo in lineList.path) {
					lineUpPath.Add (campo);				
				}
				lineUp2 = null;
				lineUpPath2 = null;
				break;

			case "Linha5":
				lineDown = grid.transform.GetChild (3).gameObject;
				lineList = lineDown.transform.GetComponent<LineIndentificator> ();
				foreach (GameObject campo in lineList.path) {
					lineDownPath.Add (campo);				
				}
				lineDown2 = grid.transform.GetChild (2).gameObject;
				lineList = lineDown2.transform.GetComponent<LineIndentificator> ();
				foreach (GameObject campo in lineList.path) {
					lineDownPath2.Add (campo);				
				}
				lineUp = null;
				lineUpPath = null;
				lineUp2 = null;
				lineUpPath2 = null;
				break;

			}//FECHA SWITCH
				
			if(linePath.Count > 0)
			for (int i = 0; i < linePath.Count; i++) {

					if (linePath [i].gameObject == other.gameObject) {


						if (i < 6)
							walk.Add (linePath [i + 1]);

						if (i < 5)
							walk.Add (linePath [i + 2]);

						if (i > 0)
							walk.Add (linePath [i - 1]);

						if (i > 1)
							walk.Add (linePath [i - 2]);

						if (lineUpPath.Count > 0)
							walk.Add (lineUpPath [i]);

						if (lineUpPath2.Count > 0)
							walk.Add (lineUpPath2 [i]);

						if (lineDownPath.Count > 0)
							walk.Add (lineDownPath [i]);

						if (lineDownPath2.Count > 0)
							walk.Add (lineDownPath2 [i]);
					}

			}//FECHA FOR PERCORRE LISTA

		}//FECHA IF TAG



	}//ONTRIGGERENTER

	void OnTriggerStay2D(Collider2D other){



	}//ONTRIGGERSTAY

	void OnTriggerExit2D(Collider2D other){

		if (objeto != null) {

			foreach (GameObject field in objeto) {

				if (field.gameObject == other.gameObject && field.tag == "Box") {
					objeto.Remove (field.gameObject);
				}

			}
		}

	}//ONTRIGGEREXIT



}//MONOBEHAVIOR