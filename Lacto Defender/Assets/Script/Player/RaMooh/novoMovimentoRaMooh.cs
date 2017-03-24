using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class novoMovimentoRaMooh : MonoBehaviour {

	[System.Serializable] public struct _campo{

		public GameObject box;
		public bool onTheField;

	}

	public bool clica = false;
	public bool prepara = false;
	public bool walking = false;
	public bool limpa = false;
	public bool limpaColor = false;
	public GameObject destino;


	int auxInt;
	_campo auxStr;

	//Linhas adjacentes
	GameObject grid;
	public GameObject line;
	public GameObject lineUp;
	public GameObject lineDown;

	//Lista de boxes possíveis
	public List<_campo> walkUp;
	public List<_campo> walkDown;
	public List<_campo> walkLeft;
	public List<_campo> walkRight;

	public bool criaLista = false;

	public GameObject alien;

	Vector4 backColor;

	void Start () {

		walkUp = new List<_campo> ();

		walkDown = new List<_campo> ();

		walkLeft = new List<_campo> ();

		walkRight = new List<_campo> ();

		alien = null;

	}
		
	void Update () {



		//GERENCIAMENTO DE DISPONIBILIDADE
		if (walkUp.Count>0) {
			
			auxStr = walkUp [0];
			auxStr.onTheField = walkUp [0].box.gameObject.transform.GetComponent<ScriptField> ().freeFloor;
			auxStr.box.gameObject.transform.GetComponent<ScriptField> ().onPath = auxStr.onTheField;
			walkUp [0] = auxStr;
			auxStr = new _campo ();
		}

		if (walkDown.Count>0) {

			auxStr = walkDown [0];
			auxStr.onTheField = walkDown [0].box.gameObject.transform.GetComponent<ScriptField> ().freeFloor;
			auxStr.box.gameObject.transform.GetComponent<ScriptField> ().onPath = auxStr.onTheField;
			walkDown [0] = auxStr;
			auxStr = new _campo ();
		}

		if (walkLeft.Count>0) {

			auxStr = walkLeft [0];
			auxStr.onTheField = walkLeft [0].box.gameObject.transform.GetComponent<ScriptField> ().freeFloor;
			auxStr.box.gameObject.transform.GetComponent<ScriptField> ().onPath = auxStr.onTheField;
			walkLeft [0] = auxStr;
			auxStr = new _campo ();

		}

		if (walkRight.Count>0) {

			auxStr = walkRight [0];
			auxStr.onTheField = walkRight [0].box.gameObject.transform.GetComponent<ScriptField> ().freeFloor;
			auxStr.box.gameObject.transform.GetComponent<ScriptField> ().onPath = auxStr.onTheField;
			walkRight [0] = auxStr;
			auxStr = new _campo ();

		}
		//GERENCIAMENTO DE DISPONIBILIDADE

		//PREPARA

		if (prepara == true) {


			if (walkUp.Count > 0) {
				auxStr = walkUp [0];
				if (auxStr.onTheField == true) {
					auxStr.box.gameObject.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (0, 1, 0, 1);

					if (auxStr.box.gameObject.transform.GetComponent<ScriptField> ().preparaCampo == true) {
						destino = auxStr.box.gameObject;
						walking = true;
						prepara = false;
					}

				} else {
					auxStr.box.gameObject.transform.GetComponent<SpriteRenderer> ().color = backColor;
				}
						
			}

			if (walkDown.Count > 0) {
				auxStr = walkDown [0];
				if (auxStr.onTheField == true) {
					auxStr.box.gameObject.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (0, 1, 0, 1);

					if (auxStr.box.gameObject.transform.GetComponent<ScriptField> ().preparaCampo == true) {
						destino = auxStr.box.gameObject;
						walking = true;
						prepara = false;
					}

				}else {
					auxStr.box.gameObject.transform.GetComponent<SpriteRenderer> ().color = backColor;
				}
			}

			if (walkLeft.Count > 0) {
				auxStr = walkLeft [0];
				if (auxStr.onTheField == true) {
					auxStr.box.gameObject.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (0, 1, 0, 1);

					if (auxStr.box.gameObject.transform.GetComponent<ScriptField> ().preparaCampo == true) {
						destino = auxStr.box.gameObject;
						walking = true;
						prepara = false;
					}

				}else {
					auxStr.box.gameObject.transform.GetComponent<SpriteRenderer> ().color = backColor;
				}
			}

			if (walkRight.Count > 0) {
				auxStr = walkRight [0];
				if (auxStr.onTheField == true) {
					auxStr.box.gameObject.transform.GetComponent<SpriteRenderer> ().color = new Vector4 (0, 1, 0, 1);

					if (auxStr.box.gameObject.transform.GetComponent<ScriptField> ().preparaCampo == true) {
						destino = auxStr.box.gameObject;
						walking = true;
						prepara = false;
					}

				}else {
					auxStr.box.gameObject.transform.GetComponent<SpriteRenderer> ().color = backColor;
				}
			}

		}

		//PREPARA

		//ANDA

		if (walking == true) {
			gameObject.transform.GetComponent<spawnPlayerRaMooh> ().onField = false;
			transform.position = Vector2.Lerp (transform.position, destino.transform.position, Time.deltaTime);
			limpa = true;
		}

		if (limpa == true) {
			
			if (walkUp.Count > 0) {
				auxStr = walkUp [0];
				auxStr.box.gameObject.transform.GetComponent<SpriteRenderer> ().color = backColor;
				auxStr.box.gameObject.transform.GetComponent<ScriptField> ().onPath = false;
			}

			if (walkDown.Count > 0) {
				auxStr = walkDown [0];
				auxStr.box.gameObject.transform.GetComponent<SpriteRenderer> ().color = backColor;
				auxStr.box.gameObject.transform.GetComponent<ScriptField> ().onPath = false;
			}

			if (walkLeft.Count > 0) {
				auxStr = walkLeft [0];
				auxStr.box.gameObject.transform.GetComponent<SpriteRenderer> ().color = backColor;
				auxStr.box.gameObject.transform.GetComponent<ScriptField> ().onPath = false;
			}

			if (walkRight.Count > 0) {
				auxStr = walkRight [0];
				auxStr.box.gameObject.transform.GetComponent<SpriteRenderer> ().color = backColor;
				auxStr.box.gameObject.transform.GetComponent<ScriptField> ().onPath = false;
			}

	

			walkUp.Clear ();
			walkDown.Clear ();
			walkRight.Clear ();
			walkLeft.Clear ();

			limpa = false;

		}

		if (limpaColor == true) {
			
			if (walkUp.Count > 0) {
				auxStr = walkUp [0];
				auxStr.box.gameObject.transform.GetComponent<SpriteRenderer> ().color = backColor;
				auxStr.box.gameObject.transform.GetComponent<ScriptField> ().onPath = false;
			}

			if (walkDown.Count > 0) {
				auxStr = walkDown [0];
				auxStr.box.gameObject.transform.GetComponent<SpriteRenderer> ().color = backColor;
				auxStr.box.gameObject.transform.GetComponent<ScriptField> ().onPath = false;
			}

			if (walkLeft.Count > 0) {
				auxStr = walkLeft [0];
				auxStr.box.gameObject.transform.GetComponent<SpriteRenderer> ().color = backColor;
				auxStr.box.gameObject.transform.GetComponent<ScriptField> ().onPath = false;
			}

			if (walkRight.Count > 0) {
				auxStr = walkRight [0];
				auxStr.box.gameObject.transform.GetComponent<SpriteRenderer> ().color = backColor;
				auxStr.box.gameObject.transform.GetComponent<ScriptField> ().onPath = false;
			}

			limpaColor = false;

		}
		
		//ANDA





	}
	//UPDATE


	void OnTriggerStay2D(Collider2D other){

		if (other.tag == "Enemy") {
			alien = other.gameObject;
		}

		if(criaLista == true){

			if(gameObject.transform.GetComponent<spawnPlayerRaMooh>().onField = true)
			if(other.tag == "Box")
				other.gameObject.transform.GetComponent<ScriptField> ().freeFloor = false;

			line = null;
			lineDown = null;
			lineUp = null;

			if(walkUp != null)
			walkUp.Clear ();
			
			if(walkDown != null)
			walkDown.Clear ();

			if(walkRight != null)
			walkRight.Clear ();

			if(walkLeft != null)
			walkLeft.Clear ();

			if (other.gameObject.tag == "Box") {

				grid = other.gameObject.transform.parent.parent.gameObject;
				line = other.gameObject.transform.parent.gameObject;

				for (int i = 0; i < grid.transform.GetComponent<LineIndentificator> ().qtd; i++) {

					if (grid.gameObject.transform.GetChild (i).gameObject == line.gameObject)
						auxInt = i;

				}

				if (auxInt < grid.transform.GetComponent<LineIndentificator> ().qtd - 1) {
					lineUp = grid.transform.GetChild (auxInt + 1).gameObject;
				}

				if (auxInt > 0) {
					lineDown = grid.transform.GetChild (auxInt - 1).gameObject;
				}

				auxInt = line.gameObject.transform.GetComponent<LineIndentificator> ().path.Count;

				if (auxInt > 0) {

					for (int i = 0; i < auxInt; i++) {

						if (line.gameObject.transform.GetChild (i).gameObject == other.gameObject) {

							if (lineUp != null) {
								var str = new _campo ();
								str.box = lineUp.gameObject.transform.GetChild (i).gameObject;
								str.onTheField = true;
								walkUp.Add (str);
							}

							if (lineDown != null) {
								var str = new _campo ();
								str.box = lineDown.gameObject.transform.GetChild (i).gameObject;
								str.onTheField = true;
								walkDown.Add (str);
							}

							if (i < auxInt - 1) {
								var str = new _campo ();
								str.box = line.gameObject.transform.GetChild (i+1).gameObject;
								str.onTheField = true;
								walkRight.Add (str);
							}

							if (i > 0) {
								var str = new _campo ();
								str.box = line.gameObject.transform.GetChild (i-1).gameObject;
								str.onTheField = true;
								walkLeft.Add (str);
							}


						}


					}

				}

			}
			criaLista = false;
		}
		//Fecha If Cria Lista

		//POSICIONA
		if(destino != null)
		if (other.gameObject == destino.gameObject) {
			other.gameObject.transform.GetComponent<ScriptField> ().preparaCampo = false;
			walking = false;
			if (gameObject.transform.position.x - other.gameObject.transform.position.x > -0.9f
			   || gameObject.transform.position.x - other.gameObject.transform.position.x < 0.1f) {

				gameObject.transform.position = other.gameObject.transform.position;
				destino = null;

			}
			gameObject.transform.GetComponent<spawnPlayerRaMooh> ().onField = true;
		}
		//POSICIONA
	}
	//FECHA ON TRIGGER STAY

	void OnTriggerExit2D(Collider2D other){


		if (other.tag == "Enemy") {
			alien = null;
		}

		if (other.tag == "Box") {
			if (gameObject.transform.GetComponent<spawnPlayerRaMooh> ().spawn == false)
				criaLista = true;
		}

	}

	void OnMouseDown(){

		if (walking == false) {
		
			if (clica && alien == null && gameObject.transform.GetComponent<spawnPlayerRaMooh> ().onField == true) {

				clica = false;
				prepara = true;

				backColor = new Vector4 (line.gameObject.transform.GetComponentInChildren<SpriteRenderer> ().color.r,
					line.gameObject.transform.GetComponentInChildren<SpriteRenderer> ().color.g,
					line.gameObject.transform.GetComponentInChildren<SpriteRenderer> ().color.b,
					line.gameObject.transform.GetComponentInChildren<SpriteRenderer> ().color.a);
			
			}

			if (prepara && clica) { 
			
				prepara = false;
				limpa = true;

			}

			if (gameObject.transform.GetComponent<spawnPlayerRaMooh> ().onField == true) {
				clica = true;
			}
		}
	}
	//FECHA ON MOUSE DOWN
}
