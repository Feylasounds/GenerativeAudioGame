using UnityEngine;
using System.Collections;

public class SphereRotation : MonoBehaviour {

	public GameObject mainObject;
    private float period;
    private float radius;
    private Vector3 axis;

    void Start() {
        period = Random.Range(6, 20);
        radius = Random.Range(60, 360);
        Vector3 basis1 = Random.onUnitSphere;
        Vector3 basis2 = Random.onUnitSphere;
        axis = Vector3.Cross(basis1, basis2);
        transform.position = basis1 * radius;
	}

    void Update() {
        transform.RotateAround(Vector3.zero, axis, (360f / period) * Time.deltaTime);
    }
}
