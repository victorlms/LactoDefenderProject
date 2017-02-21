using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoRaMooh : MonoBehaviour {



	public GameObject line;
	public GameObject lineUp;
	public GameObject lineDown;
	public GameObject alien;

	public List<GameObject> linePath;
	public List<GameObject> lineUpPath;
	public List<GameObject> lineDownPath;
	public List<GameObject> walkUp;
	public List<GameObject> walkDown;
	public List<GameObject> walkLeft;
	public List<GameObject> walkRight;

	public List<GameObject> objeto;

	GameObject grid;
	public bool limpa = false;
	public int contta;
	public float speed;

	public GameObject field;

	public bool walking = false;

	void Start () {
		alien = null;
		linePath = new List<GameObject> ();

		lineUpPath = new List<GameObject>();
		lineDownPath = new List<GameObject>();
		//	walk = new List<List<GameObject>> ();
		walkUp = new List<GameObject> ();
		walkDown = new List<GameObject> ();
		walkRight = new List <GameObject> ();
		walkLeft = new List<GameObject> ();
		objeto = new List<GameObject> ();

	}



	void Update ()
	{

		if (prepara) {

			foreach (GameObject campo in walkUp) {

				if (campo.gameObject.transform.GetComponent<ScriptField> ().onPath == true) {
					campo.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (0, 1, 0, 1);
					campo.gameObject.transform.GetComponent<ScriptField> ().walkObject = gameObject;
				}


			}

			foreach (GameObject campo in walkDown) {



				if (campo.gameObject.transform.GetComponent<ScriptField> ().onPath == true) {
					campo.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (0, 1, 0, 1);
					campo.gameObject.transform.GetComponent<ScriptField> ().walkObject = gameObject;
				}
			}

			foreach (GameObject campo in walkRight) {
				if (campo.gameObject.transform.GetComponent<ScriptField> ().onPath == true) {
					campo.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (0, 1, 0, 1);
					campo.gameObject.transform.GetComponent<ScriptField> ().walkObject = gameObject;
				}

			}

			foreach (GameObject campo in walkLeft) {
				if (campo.gameObject.transform.GetComponent<ScriptField> ().onPath == true) {
					campo.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (0, 1, 0, 1);
					campo.gameObject.transform.GetComponent<ScriptField> ().walkObject = gameObject;
				}

			}

		}

		if (walkUp.Count > 0)
			foreach (GameObject campo in walkUp) {

				if (campo.gameObject.transform.GetComponent<ScriptField> ().onPath == true 
					&& campo.gameObject.transform.GetComponent<ScriptField> ().walkObject != gameObject
					&& prepara == true  )
					campo.gameObject.transform.GetComponent<ScriptField> ().onPath = false;

			}

		if (walkDown.Count > 0)
			foreach (GameObject campo in walkDown) {

				if (campo.gameObject.transform.GetComponent<ScriptField> ().onPath == true
					&& campo.gameObject.transform.GetComponent<ScriptField> ().walkObject != gameObject
					&& prepara == true)
					campo.gameObject.transform.GetComponent<ScriptField> ().onPath = false;

			}

		if (walkLeft.Count > 0)
			foreach (GameObject campo in walkLeft) {

				if (campo.gameObject.transform.GetComponent<ScriptField> ().onPath == true 
					&& campo.gameObject.transform.GetComponent<ScriptField> ().walkObject != gameObject
					&& prepara == true)
					campo.gameObject.transform.GetComponent<ScriptField> ().onPath = false;

			}

		if (walkRight.Count > 0)
			foreach (GameObject campo in walkRight) {

				if (campo.gameObject.transform.GetComponent<ScriptField> ().onPath == true
					&& campo.gameObject.transform.GetComponent<ScriptField> ().walkObject != gameObject
					&& prepara == true)
					campo.gameObject.transform.GetComponent<ScriptField> ().onPath = false;

			}

		//ABRE_GERENCIAMENTO
		//WALK UP


		if (walkUp.Count == 1)
		if (walkUp [0].gameObject.transform.GetComponent<ScriptField> ().freeFloor == true) 
			walkUp [0].gameObject.transform.GetComponent<ScriptField> ().onPath = true;
		

		//WALK DOWN
	

		if (walkDown.Count == 1)
		if (walkDown [0].gameObject.transform.GetComponent<ScriptField> ().freeFloor == true) 
			walkDown [0].gameObject.transform.GetComponent<ScriptField> ().onPath = true;
		

		//WALK LEFT
	

		if(walkLeft.Count==1)
		if (walkLeft[0].gameObject.transform.GetComponent<ScriptField> ().freeFloor == true)
			walkLeft[0].gameObject.transform.GetComponent<ScriptField> ().onPath = true;

		//WALK RIGHT
	

		if(walkRight.Count==1)
		if (walkRight[0].gameObject.transform.GetComponent<ScriptField> ().freeFloor == true)
			walkRight[0].gameObject.transform.GetComponent<ScriptField> ().onPath = true;


		//FECHA_GERENCIAMENTO

		if (walkUp.Count > 0) {

			if (walkUp [0].gameObject.transform.GetComponent<ScriptField> ().freeFloor == false) {

				walkUp [0].gameObject.transform.GetComponent<ScriptField> ().onPath = false;
			}


			foreach (GameObject campo in walkUp) {


				if (campo.gameObject.transform.GetComponent<ScriptField> ().preparaCampo 
					&& prepara
					&& campo.gameObject.transform.GetComponent<ScriptField>().walkObject == gameObject) {
					walking = true;
					field = campo.gameObject;
					limpa = true;
				}

			}	
		}//FECHAWALKUP

		if (walkDown.Count > 0) {

		
			if (walkDown [0].gameObject.transform.GetComponent<ScriptField> ().freeFloor == false) {


				walkDown [0].gameObject.transform.GetComponent<ScriptField> ().onPath = false;
			}


			foreach (GameObject campo in walkDown) {

				if (campo.gameObject.transform.GetComponent<ScriptField> ().preparaCampo 
					&& prepara
					&& campo.gameObject.transform.GetComponent<ScriptField>().walkObject == gameObject) {
					walking = true;
					field = campo.gameObject;
					limpa = true;
				}
			}

		}//FECHAWALKDOWN

		if (walkLeft.Count > 0) {

		

			if (walkLeft [0].gameObject.transform.GetComponent<ScriptField> ().freeFloor == false) {


				walkLeft [0].gameObject.transform.GetComponent<ScriptField> ().onPath = false;
			}

			foreach (GameObject campo in walkLeft) {

				if (campo.gameObject.transform.GetComponent<ScriptField> ().preparaCampo 
					&& prepara
					&& campo.gameObject.transform.GetComponent<ScriptField>().walkObject == gameObject) {
					walking = true;
					field = campo.gameObject;
					limpa = true;
				}

			}
		}

		if (walkRight.Count > 0) {

		

			if (walkRight [0].gameObject.transform.GetComponent<ScriptField> ().freeFloor == false) {

				walkRight [0].gameObject.transform.GetComponent<ScriptField> ().onPath = false;
			}

			foreach (GameObject campo in walkRight) {

				if (campo.gameObject.transform.GetComponent<ScriptField> ().preparaCampo 
					&& prepara
					&& campo.gameObject.transform.GetComponent<ScriptField>().walkObject == gameObject) {
					walking = true;
					field = campo.gameObject;
					limpa = true;
				}

			}

		}

		if (walking) {
			transform.position = Vector2.Lerp (transform.position, field.transform.position, Time.deltaTime);
		}

		if (limpa) {

			foreach (GameObject color in walkUp) {
				color.gameObject.transform.GetComponent<SpriteRenderer> ().color = backColor;
			}

			foreach (GameObject color in walkDown) {
				color.gameObject.transform.GetComponent<SpriteRenderer> ().color = backColor;
			}
			foreach (GameObject color in walkLeft) {
				color.gameObject.transform.GetComponent<SpriteRenderer> ().color = backColor;
			}
			foreach (GameObject color in walkRight) {
				color.gameObject.transform.GetComponent<SpriteRenderer> ().color = backColor;
			}

			walkUp.Clear ();
			walkDown.Clear ();
			walkLeft.Clear ();
			walkRight.Clear ();
			prepara = false;
			limpa = false;
		}



	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.tag == "Box"){

			if (walking && other.gameObject == field.gameObject) {
				other.gameObject.transform.GetComponent<ScriptField> ().preparaCampo = false;
				other.gameObject.transform.GetComponent<ScriptField> ().cancelaCampo = false;

			}

			bool testa = false;

			if(objeto.Count > 0)
				objeto.Remove (objeto [0]);

			if (testa == false) {

				objeto.Add (other.gameObject);
			}

			line = null;
			lineDown = null;
			lineUp = null;

			if (linePath != null)
				linePath.Clear ();

			if (walkLeft != null)
				walkLeft.Clear ();

			if (walkRight != null)
				walkRight.Clear ();

			if (lineDownPath != null)
				lineDownPath.Clear ();

			if (lineUpPath != null)
				lineUpPath.Clear ();

			if (walkUp != null)
				walkUp.Clear ();

			if (walkDown != null)
				walkDown.Clear ();


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

			backColor = new Vector4 (linePath[0].transform.GetComponent<SpriteRenderer> ().color.r,
				linePath[0].transform.GetComponent<SpriteRenderer> ().color.g,
				linePath[0].transform.GetComponent<SpriteRenderer> ().color.b,
				linePath[0].transform.GetComponent<SpriteRenderer> ().color.a);

			switch (line.gameObject.transform.tag) {

			case "Linha1":

				lineUp = grid.transform.GetChild (1).gameObject;
				lineList = lineUp.transform.GetComponent<LineIndentificator> ();
				foreach (GameObject campo in lineList.path) {
					lineUpPath.Add (campo);				
				}
				break;



			case "Linha2":
				lineDown = grid.transform.GetChild (0).gameObject;
				lineList = lineDown.transform.GetComponent<LineIndentificator> ();
				foreach (GameObject campo in lineList.path) {
					lineDownPath.Add (campo);				
				}
			
				lineUp = grid.transform.GetChild (2).gameObject;
				lineList = lineUp.transform.GetComponent<LineIndentificator> ();
				foreach (GameObject campo in lineList.path) {
					lineUpPath.Add (campo);				
				}
				break;



			case "Linha3":
				lineDown = grid.transform.GetChild (1).gameObject;
				lineList = lineDown.transform.GetComponent<LineIndentificator> ();
				foreach (GameObject campo in lineList.path) {
					lineDownPath.Add (campo);				
				}
			
				lineUp = grid.transform.GetChild (3).gameObject;
				lineList = lineUp.transform.GetComponent<LineIndentificator> ();
				foreach (GameObject campo in lineList.path) {
					lineUpPath.Add (campo);				
				}
				break;

			case "Linha4":
				lineDown = grid.transform.GetChild (2).gameObject;
				lineList = lineDown.transform.GetComponent<LineIndentificator> ();
				foreach (GameObject campo in lineList.path) {
					lineDownPath.Add (campo);				
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
				break;

			}//FECHA SWITCH

			if (linePath.Count > 0) {

				for (int i = 0; i < linePath.Count; i++) {

					if (linePath [i].gameObject == objeto[0].gameObject) {

						if (i < 6) 
							walkRight.Add (linePath [i + 1].gameObject);

					

						if (i > 0)
							walkLeft.Add (linePath [i - 1].gameObject);



						if (lineUpPath.Count > 0 )
							walkUp.Add (lineUpPath [i].gameObject);


						if (lineDownPath.Count > 0)
							walkDown.Add (lineDownPath [i].gameObject);


					}


				}//FECHA FOR PERCORRE LISTA

			}

			foreach (GameObject fieldTest in walkUp) {
				fieldTest.gameObject.transform.GetComponent<ScriptField> ().onPath = true;
				//fieldTest.gameObject.transform.GetComponent<ScriptField> ().walkList.Add (transform.gameObject);
			}

			foreach (GameObject fieldTest in walkDown) {
				fieldTest.gameObject.transform.GetComponent<ScriptField> ().onPath = true;
				//fieldTest.gameObject.transform.GetComponent<ScriptField> ().walkList.Add (transform.gameObject);
			}

			foreach (GameObject fieldTest in walkLeft) {
				fieldTest.gameObject.transform.GetComponent<ScriptField> ().onPath = true;
				//fieldTest.gameObject.transform.GetComponent<ScriptField> ().walkList.Add (transform.gameObject);
			}

			foreach (GameObject fieldTest in walkRight) {
				fieldTest.gameObject.transform.GetComponent<ScriptField> ().onPath = true;
				//fieldTest.gameObject.transform.GetComponent<ScriptField> ().walkList.Add (transform.gameObject);
			}

		}//FECHA IF TAG

	}//ONTRIGGERENTER

	void OnTriggerStay2D(Collider2D other){

		if (other.gameObject.transform.tag == "Enemy")
			alien = other.gameObject;

	}//ONTRIGGERSTAY

	void OnTriggerExit2D(Collider2D other){

		if (gameObject.transform.GetComponent<spawnPlayerRaMooh> ().spawn == true) {

			if (other.tag == "Box") {

				if (objeto.Count > 0)
					for (int i = 0; i < objeto.Count; i++) {

						if (objeto [i].gameObject == other.gameObject) {
							//	field.transform.GetComponent<ScriptField> ().freeFloor = true;
							other.gameObject.transform.GetComponent<ScriptField> ().freeFloor = true;
							objeto.Remove (objeto [i].gameObject);

						}

					}
			}
		}

		if (walking) {



			if (other.gameObject == objeto [0]) {
				objeto.Remove (field.gameObject);
			}


		}

	}//ONTRIGGEREXIT

	Vector4 backColor;
	bool clica = false;
	public bool prepara = false;

	void OnMouseDown(){

		if (clica && gameObject.GetComponent<spawnPlayerRaMooh>().onField && alien == null) {

			clica = false;
			prepara = true;

		}

		if (prepara && clica) {
			prepara = false;
		}
		clica = true;

	}//ON MOUSE DOWN

}//MONOBEHAVIOUR
