using UnityEngine;
using System.Collections;

public class ParedRoja : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnCollisionEnter(Collision otro){
		if (otro.gameObject.tag == "Proyectil") {
			Destroy (this.gameObject);
		}	
		
	}
}