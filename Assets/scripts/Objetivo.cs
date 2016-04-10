using UnityEngine;
using System.Collections;

public class Objetivo: MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider otro){
		if (otro.gameObject.tag == "Proyectil") {
			Application.LoadLevel("escena_juego");
			Vidas.vidas = 5;
		}	
		
	}
}
