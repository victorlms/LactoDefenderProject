using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterPack : MonoBehaviour {

	public List<GameObject> pack;
	public List<GameObject> aprova;


	bool adiciona;

	void Start () {
		pack = new List<GameObject> ();
		aprova = new List<GameObject> ();
	}

	void Update () {

		if (pack != null) {
			foreach (GameObject monster in pack) {
				if (monster == null)
					pack.Remove (monster);
			}
		}
		if (pack != null) {
			foreach (GameObject monster in pack) {

				if (monster.gameObject.transform.GetComponent<novoMovimentoRaMooh> ()) {

					if (aprova.Count > 0)
						foreach (GameObject testa in aprova) {
							if (testa == monster)
								adiciona = false;
							else
								adiciona = true;
						}
					else
						adiciona = true;

					if (monster.gameObject.transform.GetComponent<novoMovimentoRaMooh> ().prepara == true && adiciona == true) {
						aprova.Add (monster);
					}
				} else if (monster.gameObject.transform.GetComponent<novoMovimentoMoohMooh> ()) {

					if (aprova.Count > 0)
						foreach (GameObject testa in aprova) {
							if (testa == monster)
								adiciona = false;
							else
								adiciona = true;
						}
					else
						adiciona = true;

					if (monster.gameObject.transform.GetComponent<novoMovimentoMoohMooh> ().prepara == true && adiciona == true) {
						aprova.Add (monster);
					}
				}

			}
		}

		if (aprova.Count > 0) {
			foreach (GameObject monster in aprova) {

				if (monster.gameObject.transform.GetComponent<novoMovimentoRaMooh> ()) {
					if (monster == null)
						aprova.Remove (monster);
					else if (monster.gameObject.transform.GetComponent<novoMovimentoRaMooh> ().prepara == false)
						aprova.Remove (monster);
				} else if (monster.gameObject.transform.GetComponent<novoMovimentoMoohMooh> ()) {
					if (monster == null)
						aprova.Remove (monster);
					else if (monster.gameObject.transform.GetComponent<novoMovimentoMoohMooh> ().prepara == false)
						aprova.Remove (monster);
				}
			}
		}

					
			



		if (aprova.Count > 1) {
			
			for (int i = 0; i < aprova.Count; i++) {


				if (aprova[i].gameObject.transform.GetComponent<novoMovimentoRaMooh> ()) {
					if (aprova [i].gameObject.transform.GetComponent<novoMovimentoRaMooh> ().prepara == true) {


						for (int j = 0; j < i - 1; j++) {

							if (aprova [j].gameObject.transform.GetComponent<novoMovimentoRaMooh> ().prepara == true) {
								aprova [j].gameObject.transform.GetComponent<novoMovimentoRaMooh> ().prepara = false;
								aprova [j].gameObject.transform.GetComponent<novoMovimentoRaMooh> ().limpaColor = true;
								aprova [j].gameObject.transform.GetComponent<novoMovimentoRaMooh> ().criaLista = true;
							}

						}

					}
				}

				if (aprova[i].gameObject.transform.GetComponent<novoMovimentoMoohMooh> ()) {
					if (aprova [i].gameObject.transform.GetComponent<novoMovimentoMoohMooh> ().prepara == true) {


						for (int j = 0; j < i - 1; j++) {

							if (aprova [j].gameObject.transform.GetComponent<novoMovimentoMoohMooh> ().prepara == true) {
								aprova [j].gameObject.transform.GetComponent<novoMovimentoMoohMooh> ().prepara = false;
								aprova [j].gameObject.transform.GetComponent<novoMovimentoMoohMooh> ().limpaColor = true;
								aprova [j].gameObject.transform.GetComponent<novoMovimentoMoohMooh> ().criaLista = true;
							}

						}

					}
				}





			}
		}

		

	}
}
