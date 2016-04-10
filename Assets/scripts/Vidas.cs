using UnityEngine;
using System.Collections;

public class Vidas : MonoBehaviour {
	static public int vidas = 5;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		GUIText gt = this.GetComponent<GUIText>();
		gt.text = "Proyectiles: "+vidas;
	}
}