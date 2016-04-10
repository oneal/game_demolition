using UnityEngine;
using System.Collections;

public class Tirachinas : MonoBehaviour {
	static public Tirachinas S;
	public GameObject proyectil;
	public GameObject prefabproyectil;
	public GameObject proyectilgrande;
	public GameObject puntolanzamiento;
	public Vector3 posicionLanzamiento;
	public float velocidad=60f;
	public bool modoApuntando;
	public GameObject objetivo;

	void Awake(){
		S = this;
		Transform puntoLanzamientoTrans = transform.Find("PuntoLanzamiento");
		puntolanzamiento = puntoLanzamientoTrans.gameObject;
		puntolanzamiento.SetActive( false );
		posicionLanzamiento = puntoLanzamientoTrans.position;
	}

	void OnMouseEnter(){

		puntolanzamiento.SetActive (true);
	}

	void OnMouseExit(){

		puntolanzamiento.SetActive (false);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!modoApuntando) return;

		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = -Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint( mousePos2D );

		Vector3 mouseDelta = mousePos3D-posicionLanzamiento;
		float maxMagnitude = this.GetComponent<SphereCollider>().radius;
		if (mouseDelta.magnitude > maxMagnitude) {
			mouseDelta.Normalize();
			mouseDelta *= maxMagnitude;
		}

		Vector3 projPos = posicionLanzamiento + mouseDelta;
		proyectil.transform.position = projPos;
		if ( Input.GetMouseButtonUp(0) ) {

			modoApuntando = false;
			proyectil.rigidbody.isKinematic = false;
			proyectil.rigidbody.velocity = -mouseDelta * velocidad;
			CameraController.S.poi = proyectil;

			if(Vidas.vidas<0){
				Application.LoadLevel("escena_juego");
				Vidas.vidas=5;
			}

		}

	}
	void OnMouseDown() {
		modoApuntando = true;
		if(Vidas.vidas==2){
			proyectil = Instantiate(proyectilgrande) as GameObject;
			Vidas.vidas--;
		}else{
			proyectil = Instantiate(prefabproyectil) as GameObject;
			Vidas.vidas--;
		}
		proyectil.transform.position = posicionLanzamiento;
		proyectil.rigidbody.isKinematic = true;

	}


	
	
}
