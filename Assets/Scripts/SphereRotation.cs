using UnityEngine;
using System.Collections;

public class SphereRotation : MonoBehaviour {

	public GameObject mainObject;
    private float period;
    private float radius;
    private Vector3 axis;

    void Start() {
        period = Random.Range(6, 20);
        radius = Random.Range(5, 30);
        axis = Random.onUnitSphere;
        transform.position = axis * radius;
	}

    void Update() {
        transform.RotateAround(Vector3.zero, axis, (360f / period) * Time.deltaTime);
    }
}
