using UnityEngine;
using System.Collections;

public class PlayerFlight : MonoBehaviour {

	static private float speed = 40.0f;
	static public float extspeed{get{return speed;}set{speed = value;}}

	public float speedosc = 1f;
	public float speedfilt = 1f;
    public float gravity = 30.0f;
	public float acceleration = 2.0f;
	public Hv_engine_AudioLib HeavyScriptEng;
	public float EngineFreq = 200f;
	public float EngineAmp = 0.5f;
	public float entropy = 1.0f;
	
	
	// Use this for initialization
	void Start () {	
		HeavyScriptEng.amplitude = EngineAmp;
		HeavyScriptEng.SendEvent(Hv_engine_AudioLib.Event.Mastervoiceonoff);
	
		//HeavyScriptEng.oscFreq = EngineFreq;
	}
	
	
	// Update is called once per frame
	void Update () {
        transform.position += transform.forward * Time.deltaTime * speed;

		if (Input.GetKey (KeyCode.LeftShift)) {
			speed += (Time.deltaTime * acceleration);
		}

		if (Input.GetKey (KeyCode.LeftControl)) {
			speed -= (Time.deltaTime * acceleration);
		}

		float maxRotation = 85;
		
		Quaternion desiredRotation = Quaternion.Euler(
			-Input.GetAxis("Vertical") * maxRotation, // pitch
			transform.localEulerAngles.y + Input.GetAxis("Horizontal") * maxRotation, // yaw
			0 //-Input.GetAxis("Horizontal") * 45 // roll
		);

		// advance towards desiredRotation by factor of Time.deltaTime
		transform.localRotation = Quaternion.Lerp(transform.localRotation, desiredRotation, Time.deltaTime);
		Vector3 zeroZ = transform.localEulerAngles;
		zeroZ.z = 0;
		transform.localEulerAngles = zeroZ;
		
		
		//Quaternion targetPitch = Quaternion.AngleAxis(45 * Input.GetAxis("Vertical"), transform.right);
		
		//transform.localRotation = Quaternion.Lerp(transform.localRotation, transform.localRotation*targetPitch, Time.deltaTime);

		//transform.Rotate(Input.GetAxis("Vertical"), Input.GetAxis("Zaxis"), -Input.GetAxis("Horizontal")); 
		HeavyScriptEng.filterFreq = speed * speedfilt * 10;


		HeavyScriptEng.SetFloatParameter(Hv_engine_AudioLib.Parameter.Oscfreq, speed * speedosc * 20);


		speed -= transform.forward.y * Time.deltaTime * gravity;
		speed -= transform.forward.z * Time.deltaTime * entropy;
	}
}