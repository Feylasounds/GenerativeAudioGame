using UnityEngine;
using System.Collections;

public class EnemyRotation : MonoBehaviour
{

    public GameObject mainObject;
    private float velocity;
    private float radius;
    private Vector3 axis;

    void Start()
    {
        velocity = Random.Range(1, 10);
        radius = Random.Range(6, 10);
        Vector3 basis1 = Random.onUnitSphere;
        Vector3 basis2 = Random.onUnitSphere;
        axis = Vector3.Cross(basis1, basis2);
        transform.position = basis1 * radius;
    }

    void Update()
    {
        transform.RotateAround(Vector3.zero, axis, (velocity / radius) * Time.deltaTime);
        transform.Rotate(0, (360 * Time.deltaTime / 4), 0);
    }
}
