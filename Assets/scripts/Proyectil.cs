using UnityEngine;
using System.Collections;

public class Proyectil : MonoBehaviour {
	static public float tiempo;
	private bool choque;
	// Use this for initialization
	void Start () {
		tiempo = 0;
		choque = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (choque) {
			tiempo++;
			//Debug.Log (tiempo);
		}

	}

	void OnCollisionEnter(Collision otro){
		if(otro.gameObject.tag=="Pared"){
			tiempo=Time.deltaTime;
			choque=true;
		}
	}

}
