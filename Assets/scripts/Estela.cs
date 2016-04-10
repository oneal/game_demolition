using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Estela : MonoBehaviour {
	static public Estela S; //Singleton
	public float minDist = 0.1f;
	public LineRenderer linea;
	private GameObject _poi;
	public List<Vector3> puntos;

	void Awake() {

		S = this;
		linea = GetComponent<LineRenderer> ();
		linea.enabled = false;
		puntos = new List<Vector3> ();
	}
	public GameObject poi {
		get {
			return(_poi);
		}
		set {
			_poi = value;
			if (_poi != null) {
				linea.enabled = false;
				puntos = new List<Vector3>();
				AddPoint();
			}
		}
	}

	public void Borra() {
		_poi = null;
		linea.enabled = false;
		puntos = new List<Vector3> ();
	}
	public void AddPoint() {
		Vector3 pt = poi.transform.position;
		Debug.Log (pt);
		if (puntos.Count > 0 && (pt - ultimoPunto).magnitude < minDist) {
			//si el punto no esta lo suficientemente alejado del ultimo punto, no hace nada
			return;
		}
		if (puntos.Count == 0) {
			//Si es el punto de lanzamiento

			Vector3 puntoLanzamiento =Tirachinas.S.puntolanzamiento.transform.position;
			Vector3 puntoLanzamientoDiff = pt - puntoLanzamiento;
			puntos.Add(pt + puntoLanzamientoDiff);
			puntos.Add(pt);
			linea.SetVertexCount(2);
			linea.SetPosition(0, puntos[0]);
			linea.SetPosition(1, puntos[1]);
			linea.enabled = true;
		} else {
			puntos.Add(pt);
			linea.SetVertexCount(puntos.Count);
			linea.SetPosition(puntos.Count - 1, ultimoPunto);
			linea.enabled = true;
		}
	}
	public Vector3 ultimoPunto {
		get {
			if (puntos == null) {
				//Si no hay puntos devuelve zero
				return (Vector3.zero);
			}
			return (puntos[puntos.Count - 1]);
		}
	}
	void FixedUpdate() {
		if (poi == null) {
			if (CameraController.S.poi != null) {
				if (CameraController.S.poi.tag == "Proyectil") {
					poi = CameraController.S.poi;
				} else {
					return;
				
				}
			} else {
				return;
			}

		}


		AddPoint ();
		/*if (poi.rigidbody.IsSleeping ()) {
			poi = null;
		}*/
		
	}
}
