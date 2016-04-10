using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {
	static public CameraController S;
	public GameObject poi;
	public float camZ;
	public float easing = 0.05f;
	public Vector2 minXY;

	void Start(){

	}

	void Awake() {
		S = this;
		camZ = this.transform.position.z;
	}
	void FixedUpdate () {
		Vector3 destino;
		if (poi == null) {
			destino = Vector3.zero;
		} else {
			destino = poi.transform.position;
			if (poi.tag == "Proyectil") {
				/*poi.rigidbody.IsSleeping()*/
				if (Proyectil.tiempo>500f) {
					poi = null;
					GameObject.Find("Estela").GetComponent<Estela>().Borra();
					GameObject.Find("Estela").GetComponent<Estela>().poi=null;
					Proyectil.tiempo = 0;
					if(Vidas.vidas==0){
						Application.LoadLevel("escena_juego");
						Vidas.vidas=5;

					}
					return;
				}
			}
		}
		destino.z = camZ;
		//Se restringe la posicion x e y
		destino.x = Mathf.Max (minXY.x, destino.x);
		destino.y = Mathf.Max (minXY.y, destino.y);
	
		//Se interpola desde la posicion actual a la de destino para que el movimiento sea fluido
		Vector3 actual = Vector3.Lerp (transform.position, destino, easing);
		transform.position = actual;
		//Se modifica el tamaño de la camara a la altura del proyectil + 10(tamaño inicial)
		camera.orthographicSize = destino.y + 10;


	}
}
