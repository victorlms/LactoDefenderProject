using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movimentoMoohMooh : MonoBehaviour {
	

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
		objeto = new List<GameObject> ();

	}



	void Update ()
	{
		
		if (walkUp.Count > 1) {
			if (walkUp [1].gameObject.transform.GetComponent<ScriptField> ().freeFloor == true)
				walkUp [1].gameObject.transform.GetComponent<ScriptField> ().onPath = true;
			
			if (walkUp[0].gameObject.transform.GetComponent<ScriptField> ().freeFloor == true)
				walkUp[0].gameObject.transform.GetComponent<ScriptField> ().onPath = true;
		}

		if(walkUp.Count==1)
		if (walkUp[0].gameObject.transform.GetComponent<ScriptField> ().freeFloor == true)
			walkUp[0].gameObject.transform.GetComponent<ScriptField> ().onPath = true;



		if (walkUp.Count > 0) {

			if (walkUp.Count > 1) {

				if (walkUp [1].gameObject.transform.GetComponent<ScriptField> ().freeFloor == false)
					walkUp [1].gameObject.transform.GetComponent<ScriptField> ().onPath = false;

			}

			if (walkUp [0].gameObject.transform.GetComponent<ScriptField> ().freeFloor == false) {

				if (walkUp.Count > 1)
					walkUp [1].gameObject.transform.GetComponent<ScriptField> ().onPath = false;

				walkUp [0].gameObject.transform.GetComponent<ScriptField> ().onPath = false;
			}


			foreach (GameObject campo in walkUp) {

				if (campo.gameObject.transform.GetComponent<ScriptField> ().preparaCampo && prepara) {
					walking = true;
					field = campo.gameObject;
					limpa = true;
				}
			}	
		}//FECHAWALKUP

		if (walkDown.Count > 0) {

			if (walkDown.Count > 1) {

				if (walkDown [1].gameObject.transform.GetComponent<ScriptField> ().freeFloor == false)
					walkDown [1].gameObject.transform.GetComponent<ScriptField> ().onPath = false;

			}

			if (walkDown [0].gameObject.transform.GetComponent<ScriptField> ().freeFloor == false) {

				if (walkDown.Count > 1)
					walkDown [1].gameObject.transform.GetComponent<ScriptField> ().onPath = false;

				walkDown [0].gameObject.transform.GetComponent<ScriptField> ().onPath = false;
			}
		

			foreach (GameObject campo in walkDown) {

				if (campo.gameObject.transform.GetComponent<ScriptField> ().preparaCampo && prepara) {
					walking = true;
					field = campo.gameObject;
					limpa = true;
				}
			}

		}//FECHAWALKDOWN
		
		if (walkLeft.Count > 0) {
			
			if (walkLeft.Count > 1) {
				
				if (walkLeft [1].gameObject.transform.GetComponent<ScriptField> ().freeFloor == false) 
					walkLeft [1].gameObject.transform.GetComponent<ScriptField> ().onPath = false;

				
			}

			if (walkLeft [0].gameObject.transform.GetComponent<ScriptField> ().freeFloor == false) {
				
				if (walkLeft.Count > 1)
					walkLeft [1].gameObject.transform.GetComponent<ScriptField> ().onPath = false;

				walkLeft [0].gameObject.transform.GetComponent<ScriptField> ().onPath = false;
			}

			foreach (GameObject campo in walkLeft) {
		
				if (campo.gameObject.transform.GetComponent<ScriptField> ().preparaCampo && prepara) {
					walking = true;
					field = campo.gameObject;
					limpa = true;
				}

			}
		}

		if (walkRight.Count > 0) {
		
			if (walkRight.Count > 1) {

				if (walkRight [1].gameObject.transform.GetComponent<ScriptField> ().freeFloor == false)
					walkRight [1].gameObject.transform.GetComponent<ScriptField> ().onPath = false;

			}

			if (walkRight [0].gameObject.transform.GetComponent<ScriptField> ().freeFloor == false) {

				if (walkRight.Count > 1)
					walkRight [1].gameObject.transform.GetComponent<ScriptField> ().onPath = false;

				walkRight [0].gameObject.transform.GetComponent<ScriptField> ().onPath = false;
			}

			foreach (GameObject campo in walkRight) {

				if (campo.gameObject.transform.GetComponent<ScriptField> ().preparaCampo && prepara) {
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

						if (i < 6) 
							walkRight.Add (linePath [i + 1].gameObject);

						if (i < 5 )
							walkRight.Add (linePath [i + 2].gameObject);

						if (i > 0)
							walkLeft.Add (linePath [i - 1].gameObject);

						if (i > 1)
							walkLeft.Add (linePath [i - 2].gameObject);

						if (lineUpPath.Count > 0 )
							walkUp.Add (lineUpPath [i].gameObject);

						if (lineUpPath2.Count > 0)
							walkUp.Add (lineUpPath2 [i].gameObject);

						if (lineDownPath.Count > 0)
							walkDown.Add (lineDownPath [i].gameObject);

						if (lineDownPath2.Count > 0)
							walkDown.Add (lineDownPath2 [i].gameObject);
						
					}
						

				}//FECHA FOR PERCORRE LISTA

			}

			foreach (GameObject fieldTest in walkUp) {
				fieldTest.gameObject.transform.GetComponent<ScriptField> ().onPath = true;
			}

			foreach (GameObject fieldTest in walkDown) {
				fieldTest.gameObject.transform.GetComponent<ScriptField> ().onPath = true;
			}

			foreach (GameObject fieldTest in walkLeft) {
				fieldTest.gameObject.transform.GetComponent<ScriptField> ().onPath = true;
			}

			foreach (GameObject fieldTest in walkRight) {
				fieldTest.gameObject.transform.GetComponent<ScriptField> ().onPath = true;
			}

		}//FECHA IF TAG
			
	}//ONTRIGGERENTER

	void OnTriggerStay2D(Collider2D other){

	}//ONTRIGGERSTAY

	void OnTriggerExit2D(Collider2D other){

		if (gameObject.transform.GetComponent<spawnPlayer> ().spawn == true) {

			if (other.tag == "Box") {


				if (objeto.Count > 0)
					for (int i = 0; i<objeto.Count; i++) {

						if (objeto[i].gameObject == other.gameObject) {
							//	field.transform.GetComponent<ScriptField> ().freeFloor = true;
							other.gameObject.transform.GetComponent<ScriptField> ().freeFloor = true;
							objeto.Remove (objeto[i].gameObject);

						}

					}

			}
		}

		if (walking) {



			if (other.gameObject == objeto[0]) {
					objeto.Remove (field.gameObject);
				}


		}

	}//ONTRIGGEREXIT

	Vector4 backColor;
	bool clica = false;
	public bool prepara = false;

	void OnMouseDown(){

		if (clica && gameObject.GetComponent<spawnPlayer>().onField ) {

			foreach (GameObject campo in walkUp) {

				if(campo.gameObject.transform.GetComponent<ScriptField> ().onPath == true)
				campo.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (0, 1, 0, 1);


			}

			foreach (GameObject campo in walkDown) {
				if(campo.gameObject.transform.GetComponent<ScriptField> ().onPath == true)
				campo.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (0, 1, 0, 1);


			}

			foreach (GameObject campo in walkRight) {
					if(campo.gameObject.transform.GetComponent<ScriptField> ().onPath == true)
					campo.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (0, 1, 0, 1);


			}

			foreach (GameObject campo in walkLeft) {
				if(campo.gameObject.transform.GetComponent<ScriptField> ().onPath == true)
				campo.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (0, 1, 0, 1);

			}

			clica = false;
			prepara = true;

		}
		clica = true;

	}



}//MONOBEHAVIOR