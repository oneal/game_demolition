using UnityEngine;
using System.Collections;

public class Castillo : MonoBehaviour {

	public GameObject[] instanciasCastillos;
	private GameObject castillo;
	// Use this for initialization
	void Start () {
	
	}
	void Awake(){
		//GameObject ancla = GameObject.Find ("AnclaCastillos");
		//instanciasCastillos = new GameObject[3];
		int valor = Random.Range (0, instanciasCastillos.Length);
		castillo = Instantiate(instanciasCastillos[valor]) as GameObject;
		//castillo.transform.parent = ancla.transform;
	}
	// Update is called once per frame
	void Update () {
		
	}


}
