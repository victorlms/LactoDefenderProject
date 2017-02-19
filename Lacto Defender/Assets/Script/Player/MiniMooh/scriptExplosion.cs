using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptExplosion : MonoBehaviour {

	public int dano;
	//Vector4 alphacolor;
//	Color backColor;

	void Start () {

	//	backColor = transform.GetComponent<SpriteRenderer> ().color;

	//	alphacolor = new Vector4 (backColor.r,
		//	backColor.g,
		//	backColor.b,
		//	1);
		

	}
	

	void Update () {
		
		gameObject.transform.localScale += new Vector3 (0.2f, 0.2f,0);

	//	alphacolor = new Vector4(alphacolor.x, alphacolor.y, alphacolor.z, alphacolor.w - 0.3f);

		//backColor.a = new Vector4 (alphacolor.x, alphacolor.y, alphacolor.z, alphacolor.w);

		if(transform.localScale.x > 10)
			Destroy(gameObject);
	}

	void OnTriggerStay2D(Collider2D other){

		if (other.gameObject.tag == "Enemy") {
			other.gameObject.transform.GetComponent<StatusEnemy> ().life -= dano;
		}

	}
}
