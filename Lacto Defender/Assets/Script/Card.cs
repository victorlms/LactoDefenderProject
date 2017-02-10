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
	public bool walking = false;

	public List<GameObject> objeto;

	GameObject grid;

	public int contta;
	bool valida = false;

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
		
		foreach (GameObject campo in walk) {

			if (campo.transform.GetComponent<ScriptField> ().walk == true) {
				Debug.Log ("Vai ao campo");
				walking = true;
				destino.position = campo.transform.position;

			}
				
		}

		if (walking) {
			gameObject.transform.position = Vector2.Lerp (transform.position, destino.position, 10 * Time.deltaTime);
			Debug.Log ("ANDANDO");
		}
	}
		
	void OnTriggerEnter2D(Collider2D other){
		objeto.Add (other.gameObject);
	
		if (other.tag == "Box" && valida == true) {


				line = null;
				linePath.Clear ();
				lineDown = null;
				lineDown2 = null;
				lineDownPath.Clear ();
				lineDownPath2.Clear ();
				lineUp = null;
				lineUp = null;
				lineUpPath.Clear ();
				lineUpPath2.Clear ();
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

			for (int i = 0; i < linePath.Count; i++) {

				if (linePath [i].gameObject == other.gameObject) {

					if(linePath [i + 1] != null)
					walk.Add (linePath [i + 1]);
					
					if(linePath [i + 2] != null)
					walk.Add (linePath [i + 2]);
					
					if(linePath [i - 1] != null)
					walk.Add (linePath [i - 1]);
					
					if(linePath [i - 2] != null)
					walk.Add (linePath [i - 2]);
					
					if(lineUpPath [i] != null)
					walk.Add (lineUpPath [i]);
					
					if(lineUpPath2 [i] != null)
					walk.Add (lineUpPath2 [i]);
					
					if(lineDownPath [i] != null)
					walk.Add (lineDownPath [i]);
					
					if(lineDownPath2 [i] != null)						
					walk.Add (lineDownPath2 [i]);
				}
			
			}//FECHA FOR PERCORRE LISTA

		}//FECHA IF TAG
			
	}//ONTRIGGERENTER

	void OnTriggerStay2D(Collider2D other){
		
		if (other.gameObject == objeto [0]) {
			valida = true;
		}

	}//ONTRIGGERSTAY

	void OnTriggerExit2D(Collider2D other){
		valida = false;

		foreach (GameObject field in objeto) {

			if (field.gameObject == other.gameObject) {
				objeto.Remove (field.gameObject);
			}

		}

	}//ONTRIGGEREXIT


}
