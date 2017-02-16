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
	//public List<List<GameObject>> walk;
	public List<GameObject> walkUp;
	public List<GameObject> walkDown;
	public List<GameObject> walkLeft;
	public List<GameObject> walkRight;
	public List<GameObject> walkExcept;


	public List<GameObject> objeto;

	GameObject grid;
	public bool limpa = false;
	public int contta;
	public float speed;

	public GameObject field;

	public bool walking = false;
	bool voltaColor = false;
	bool exited = false;

	void Start () {

		linePath = new List<GameObject> ();
	
		lineUpPath = new List<GameObject>();
		lineUpPath2 = new List<GameObject>();
		lineDownPath = new List<GameObject>();
		lineDownPath2 = new List<GameObject>();
	//	walk = new List<List<GameObject>> ();
		walkUp = new List<GameObject> ();
		walkDown = new List<GameObject> ();
		walkRight = new List <GameObject> ();
		walkLeft = new List<GameObject> ();
		walkExcept = new List<GameObject> ();
		objeto = new List<GameObject> ();

	}



	void Update ()
	{
				
		for(int i = 0; i < walkExcept.Count; i++) {

			if (walkExcept[i].gameObject.transform.GetComponent<ScriptField> ().freeFloor == true) {
				walkExcept.Remove (walkExcept[i]);
				if (i % 2 != 0)
					walkExcept.Remove (walkExcept [i++]);
			}

		}

		foreach (GameObject campo in walkUp) {

			if (campo.gameObject.transform.GetComponent<ScriptField> ().freeFloor == false){

				bool testa = true;

				foreach (GameObject box in walkExcept) {
					if (box == campo)
						testa = false;
				}
				if (testa) {
					
					walkExcept.Add (campo.gameObject);
					Debug.Log ("Adicionou o primeiro");
					Debug.Log ("tamanho é" + walkUp.Count);
					Debug.Log (campo.gameObject.tag + " E "+walkUp[0].gameObject.tag);

					if (walkUp.Count > 1 && (campo.gameObject == walkUp [0].gameObject)) {
						Debug.Log ("Adicionando exceção");
						walkExcept.Add (walkUp [1]);
						Debug.Log ("Tentou adicionar");
					}
				}
			}

			if (campo.gameObject.transform.GetComponent<ScriptField> ().preparaCampo && prepara) {
				walking = true;
				field = campo.gameObject;
				limpa = true;
			}
					
		}

		foreach (GameObject campo in walkDown) {
			
			if (campo.gameObject.transform.GetComponent<ScriptField> ().freeFloor == false){

				bool testa = true;

				foreach (GameObject box in walkExcept) {
					if (box == campo)
						testa = false;
				}
				if (testa) {
					walkExcept.Add (campo.gameObject);
				}
			}

			if (campo.gameObject.transform.GetComponent<ScriptField> ().preparaCampo && prepara) {
				walking = true;
				field = campo.gameObject;
				limpa = true;
			}

		}

		foreach (GameObject campo in walkLeft) {

			if (campo.gameObject.transform.GetComponent<ScriptField> ().freeFloor == false) {

				bool testa = true;

				foreach (GameObject box in walkExcept) {
					if (box == campo)
						testa = false;
				}
				if (testa) {
					walkExcept.Add (campo.gameObject);
				}
			}

			if (campo.gameObject.transform.GetComponent<ScriptField> ().preparaCampo && prepara) {
				walking = true;
				field = campo.gameObject;
				limpa = true;
			}

		}

		foreach (GameObject campo in walkRight) {

			if (campo.gameObject.transform.GetComponent<ScriptField> ().freeFloor == false){

				bool testa = true;

				foreach (GameObject box in walkExcept) {
					if (box == campo)
						testa = false;
				}
				if (testa) {
					walkExcept.Add (campo.gameObject);
				}
			}

			if (campo.gameObject.transform.GetComponent<ScriptField> ().preparaCampo && prepara) {
				walking = true;
				field = campo.gameObject;
				limpa = true;
			}

		}

		if (walking) {
			transform.position = Vector2.Lerp (transform.position, field.transform.position, Time.deltaTime);
		}

		/*if (limpa) {
			walkUp.Clear ();
			walkDown.Clear ();
			walkLeft.Clear ();
			walkRight.Clear ();
			walkExcept.Clear ();
		}*/



	}

	void OnTriggerEnter2D(Collider2D other){
		
		if (other.tag == "Box"){

			if (walking && other.gameObject == field.gameObject) {
				other.gameObject.transform.GetComponent<ScriptField> ().preparaCampo = false;
				other.gameObject.transform.GetComponent<ScriptField> ().cancelaCampo = false;

			}

		objeto.Add (other.gameObject);


				line = null;
				lineDown = null;
				lineDown2 = null;
				lineUp = null;
				lineUp2 = null;

				if (linePath != null)
					linePath.Clear ();
					
				if (walkLeft != null)
					walkLeft.Clear ();

				if (walkRight != null)
					walkRight.Clear ();
			
				if (lineDownPath != null)
					lineDownPath.Clear ();
			
				if (lineDownPath2 != null)
					lineDownPath2.Clear ();
			
				if (lineUpPath != null)
					lineUpPath.Clear ();
			
				if (lineUpPath2 != null)
					lineUpPath2.Clear ();
			
				//if (walk != null)
				//	walk.Clear ();

				if (walkUp != null)
					walkUp.Clear ();
			
				if (walkDown != null)
					walkDown.Clear ();

				if(walkExcept != null)
					walkExcept.Clear ();

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
			
				break;

			}//FECHA SWITCH
				
			if (linePath.Count > 0) {
				
				for (int i = 0; i < linePath.Count; i++) {

					if (linePath [i].gameObject == objeto[0].gameObject) {

						if (i < 5 )
							walkRight.Add (linePath [i + 2].gameObject);

						if (i < 6 )
							walkRight.Add (linePath [i + 1].gameObject);

						if (i > 0)
							walkLeft.Add (linePath [i - 1].gameObject);

						if (i > 1)
							walkLeft.Add (linePath [i - 2].gameObject);

						if (lineUpPath.Count > 0 )
							walkUp.Add (lineUpPath [i].gameObject);

						if (lineUpPath2.Count > 0)
							walkUp.Add (lineUpPath2 [i].gameObject);

						if (lineDownPath != null)
							walkDown.Add (lineDownPath [i].gameObject);

						if (lineDownPath2 != null)
							walkDown.Add (lineDownPath2 [i].gameObject);
						
					}
						

				}//FECHA FOR PERCORRE LISTA
				/*
				if(walkUp.Count > 0)
				foreach (GameObject campo in walkUp) {
					walk.Add (campo.gameObject);
				}
				
				if(walkDown.Count > 0)
				foreach (GameObject campo in walkDown) {
					walk.Add (campo.gameObject);
				}
				
				if(walkLeft.Count > 0)
				foreach (GameObject campo in walkLeft) {
					walk.Add (campo.gameObject);
				}
				
				if(walkRight.Count > 0)
				foreach (GameObject campo in walkRight) {
					walk.Add (campo.gameObject);
				}
*/
			}

		}//FECHA IF TAG
			
	}//ONTRIGGERENTER

	void OnTriggerStay2D(Collider2D other){

	}//ONTRIGGERSTAY

	void OnTriggerExit2D(Collider2D other){

		if (objeto.Count >0) {

			foreach (GameObject field in objeto) {

				if (field.gameObject == objeto[0].gameObject) {
					exited = true;
					objeto.Remove (field.gameObject);

				}

			}
		}

	}//ONTRIGGEREXIT

	Vector4 backColor;
	bool clica = false;
	public bool prepara = false;

	void OnMouseDown(){

		if (clica && gameObject.GetComponent<spawnPlayer>().onField ) {

			foreach (GameObject campo in walkUp) {

				backColor = new Vector4 (campo.transform.GetComponent<SpriteRenderer> ().color.r,
					campo.transform.GetComponent<SpriteRenderer> ().color.g,
					campo.transform.GetComponent<SpriteRenderer> ().color.b,
					campo.transform.GetComponent<SpriteRenderer> ().color.a);

				campo.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (0, 1, 0, 1);


			}

			foreach (GameObject campo in walkDown) {

				backColor = new Vector4 (campo.transform.GetComponent<SpriteRenderer> ().color.r,
					campo.transform.GetComponent<SpriteRenderer> ().color.g,
					campo.transform.GetComponent<SpriteRenderer> ().color.b,
					campo.transform.GetComponent<SpriteRenderer> ().color.a);

				campo.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (0, 1, 0, 1);


			}

			foreach (GameObject campo in walkRight) {
				
					backColor = new Vector4 (campo.transform.GetComponent<SpriteRenderer> ().color.r,
						campo.transform.GetComponent<SpriteRenderer> ().color.g,
						campo.transform.GetComponent<SpriteRenderer> ().color.b,
						campo.transform.GetComponent<SpriteRenderer> ().color.a);
				
					campo.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (0, 1, 0, 1);


			}

			foreach (GameObject campo in walkLeft) {

				backColor = new Vector4 (campo.transform.GetComponent<SpriteRenderer> ().color.r,
					campo.transform.GetComponent<SpriteRenderer> ().color.g,
					campo.transform.GetComponent<SpriteRenderer> ().color.b,
					campo.transform.GetComponent<SpriteRenderer> ().color.a);

				campo.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (0, 1, 0, 1);


			}

			clica = false;
			prepara = true;

		}
		clica = true;

	}



}//MONOBEHAVIOR