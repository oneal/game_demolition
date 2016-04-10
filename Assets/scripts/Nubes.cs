using UnityEngine;
using System.Collections;
public class Nubes : MonoBehaviour {
	public int numNubes = 40;
	public GameObject[] nubePrefabs;
	public Vector3 nubePosMin;
	public Vector3 nubePosMax;
	public float nubeEscalaMin = 1;
	public float nubeEscalaMax = 5;
	public float nubeVelocidadMult = 0.5f;
	public GameObject[] instancias;
	void Awake() {
		instancias = new GameObject[numNubes];
		GameObject ancla = GameObject.Find ("AnclaNubes");
		GameObject nube;
		for (int i=0; i<numNubes; i++) {
			//instanciamos nube
			int prefabNum = Random.Range(0 , nubePrefabs.Length);
			nube = Instantiate(nubePrefabs[prefabNum]) as GameObject;
			Vector3 cPos = Vector3.zero;
			//posicion nube
			cPos.x = Random.Range(nubePosMin.x, nubePosMax.x);
			cPos.y = Random.Range(nubePosMin.y, nubePosMax.y);
			//escalamos nube
			float escalaU = Random.value;
			float escalaVal = Mathf.Lerp(nubeEscalaMin, nubeEscalaMax, escalaU);
			//las nubes mas alejadas estaran mas cerca del suelo
			cPos.y = Mathf.Lerp(nubePosMin.y, cPos.y, escalaU);
			//las nubes mas pequeñas estaran mas lejos
			cPos.z = 100 - 90*escalaU;
			//aplicar transformaciones
			nube.transform.position = cPos;
			nube.transform.localScale = Vector3.one * escalaVal;
			nube.transform.parent = ancla.transform;
			instancias[i] = nube;
		}
	}
	public void Update() {
		foreach (GameObject nube in instancias) {
			float escalaVal = nube.transform.localScale.x;
			Vector3 cPos = nube.transform.position;
			//Movemos nube
			cPos.x -= escalaVal * Time.deltaTime * nubeVelocidadMult;
			if (cPos.x <= nubePosMin.x) {
				cPos.x = nubePosMax.x;
			}
			nube.transform.position = cPos;
		}
	}
}
