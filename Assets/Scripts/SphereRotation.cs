using UnityEngine;
using System.Collections;

public class SphereRotation : MonoBehaviour {

	public GameObject mainObject;
	public float angle = Mathf.Round(Random.value * 360f);
	public float speed = Random.value * 10f;
	public float xaxis = 1f;
	public float yaxis = 1f;
	public float direction = 1f;
	public float speedmult = 10f;
	public float speedrand = 1f;


	void Start(){

		if (Random.value < 0.5f)
			direction = 1.0f;
		 else
			direction = -1.0f;

		if (Random.value < 0.5f)
			xaxis = 1.0f;
		else
			xaxis = 0f;

		if (xaxis == 0f)
			yaxis = 1f;
		
		else if (Random.value < 0.5f)
			yaxis = 1f;
		else
			yaxis = 0f;

		speedrand = (Random.value) * speedmult;
	}
		




		void FixedUpdate() {



		transform.RotateAround(mainObject.transform.position, Vector3.up, angle * (Time.deltaTime * speed * direction * xaxis * speedrand));
		transform.RotateAround(mainObject.transform.position, Vector3.right, angle * (Time.deltaTime * speed * direction * yaxis * speedrand));

	}
}
