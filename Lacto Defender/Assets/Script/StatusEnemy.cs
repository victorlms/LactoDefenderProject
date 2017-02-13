using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum status {move , atk, onHit , death };

public class StatusEnemy : MonoBehaviour {

// FUNÇÃO DESSE SCRIPT É SER, A PRINICIPIO, APENAS UM DEPÓSITO DE INFORMAÇÃO SOBRE O INIMIGO

	public float life;
	public float damage;
	public float speed;
	public int coinValue;

}