using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum statusPlayer {atk, death, move, standby };

public class StatusPlayer : MonoBehaviour {

	// FUNÇÃO DESSE SCRIPT É SER, A PRINICIPIO, APENAS UM DEPÓSITO DE INFORMAÇÃO SOBRE O PLAYER

	public float life = 100f;
	public float damage = 10f;
	public float time = 100f;

}