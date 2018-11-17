using UnityEngine;
using System.Collections;

public class coremanager : MonoBehaviour {

	//Core Function
	public GameObject player;
	public AudioSource Core1;
	public MeshRenderer Corerender1;
	public SphereCollider Corecol1;


	public GameObject enemy;

	public float ASAmp;
	public float CoreScaleA = 1f;
	public float CoreScaleB = 1f;

	//Heavy Parameters

	public Hv_coreofinal_AudioLib CoreA;

	public float MetroA;
	public float MastVoiceVolA;

	public float OscMidiFreqA;
	public float objVarA;
	public float AtktA = 1;
	public float DectA = 1;
	public float HF1A;
	public float HF2A;
	public float HF3A;
	public float HF4A;
	public float HV1A;
	public float HV2A;
	public float HV3A;
	public float HV4A;
	public float DistA = 0.01f;
	public float LPFA;
	public float HPFA;
	public float speed;
    public float delayTimeLeft;
    public float delayTimeRight;

	// Harry's Amplitude Transform Control

	public float[] freqscale;
	public float ampsum = 0;
	public float ampscale, startampscale;
	public int range;
	public int inv;
	public Vector3 val;
	public Material Coloringbook;
	public float ampcap;
	public float ampdetector;
	public Color c1, c2;
	public float audioGetRepeatRate = 0.05f;


	// Use this for initialization
	void Start () {


	//AudioSource functions

		Core1 = GetComponent (typeof(AudioSource)) as AudioSource;

		Core1.spatialBlend = 1;

	//	freqscale = new float[128];
	//	InvokeRepeating ("getAudio", 0f, audioGetRepeatRate);



		// Heavy Param Control

		Hv_coreofinal_AudioLib CoreA = GetComponent<Hv_coreofinal_AudioLib> ();

		MastVoiceVolA = 0.8f; //Voice Volume or Amplitude: Controls Amp at the End of the Chain
		OscMidiFreqA = 1 + Mathf.Round(Random.value * 120f);
		
		//Clock Loop Length. For a static, all-encompassing loop, remove Random.value * 12000f
		//With this in place, all orbs will operate on an independent loop-length, making the piece hardly repetitive.
		MetroA = 4000f + Random.value * 12000f;
		
		//Attack and Decay Times
		AtktA = Random.value * 500f;
		DectA = Random.value * 1000f;
		
		//Place within loop time
		objVarA = Mathf.Round (Random.value * 16);

		//Upper partial amplitudes? Needs clarification
		HV1A = Random.value;
		HV2A = Random.value;
		HV3A = Random.value;
		HV4A = Random.value;
		//Upper partial spectral structure? Needs clarification
		HF1A = Mathf.Sin (Random.value *20f);
		HF2A = Random.value * 20f;
		HF3A = Random.value * 20f;
		HF4A = Random.value * 20f;
		//Distortion Level
        DistA = 0.01f + (Random.value * 2);
		
		//Delaytimes Left and Right
        delayTimeLeft = (Random.value * 4000);
        delayTimeRight = (Random.value * 4000);

		CoreA.SetFloatParameter (Hv_coreofinal_AudioLib.Parameter.Masterclock, MetroA);
		CoreA.SetFloatParameter (Hv_coreofinal_AudioLib.Parameter.Objvar, objVarA);

		CoreA.SetFloatParameter(Hv_coreofinal_AudioLib.Parameter.Mastervoicevolume, MastVoiceVolA);

		CoreA.SetFloatParameter(Hv_coreofinal_AudioLib.Parameter.Oscfreq, OscMidiFreqA);

		CoreA.SetFloatParameter (Hv_coreofinal_AudioLib.Parameter.Atkt, AtktA); //Attack Time

		CoreA.SetFloatParameter (Hv_coreofinal_AudioLib.Parameter.Dect, DectA); //Decay Time

		CoreA.SetFloatParameter (Hv_coreofinal_AudioLib.Parameter.Hv1, HV1A);

		CoreA.SetFloatParameter (Hv_coreofinal_AudioLib.Parameter.Hv2, HV2A);

		CoreA.SetFloatParameter (Hv_coreofinal_AudioLib.Parameter.Hv3, HV3A);

		CoreA.SetFloatParameter (Hv_coreofinal_AudioLib.Parameter.Hv4, HV4A);

		CoreA.SetFloatParameter (Hv_coreofinal_AudioLib.Parameter.Hf1, HF1A);

		CoreA.SetFloatParameter (Hv_coreofinal_AudioLib.Parameter.Hf2, HF2A);

		CoreA.SetFloatParameter (Hv_coreofinal_AudioLib.Parameter.Hf3, HF3A);

		CoreA.SetFloatParameter (Hv_coreofinal_AudioLib.Parameter.Hf4, HF4A);

		CoreA.SetFloatParameter (Hv_coreofinal_AudioLib.Parameter.Distortioncrush, DistA);

		CoreA.SetFloatParameter (Hv_coreofinal_AudioLib.Parameter.Lowpassfreq, LPFA);

        CoreA.SetFloatParameter(Hv_coreofinal_AudioLib.Parameter.Delaytimeleft, delayTimeLeft);

        CoreA.SetFloatParameter(Hv_coreofinal_AudioLib.Parameter.Delaytimeright, delayTimeRight);



        //PD Send Receiver Callback

        CoreA.RegisterSendHook();

		CoreA.FloatReceivedCallback += OnFloatMessage;

		float CoreScaleB = 1f;
	

	}

	//AudioSource Getdata

	//void getAudio(){
	//	freqscale = Core1.GetSpectrumData (128, 0, FFTWindow.BlackmanHarris);
	//	ampdetector = freqscale [range];
	//	float ampcapped = Mathf.Min (ampdetector, ampcap);
	//	val = inv * Vector3.one * Mathf.Min (startampscale * 0.99f, Mathf.Abs (ampscale * freqscale [range])) + Vector3.one * startampscale;
	//	gameObject.transform.localScale = val;
	//	if (ampcapped == ampcap) {
	//		Coloringbook.color = c2;
	//	}
	//	else
	//		Coloringbook.color = c1;
	//}


	//Heavy Send Receiver

	void OnFloatMessage(Hv_coreofinal_AudioLib.FloatMessage message) {
		Debug.Log(message.receiverName + ": " + message.value);

		float CoreScaleB = 20 * message.value;
	

	
	}

	void Update () {
		
		float LPFA = speed * 1.5f;
		CoreA.SetFloatParameter (Hv_coreofinal_AudioLib.Parameter.Lowpassfreq, LPFA);
	
		//Array Sum
	
		//foreach(float item in freqscale){
		//	ampsum += item;

	//	}





		//transform.localScale = new Vector3 (CoreScaleA * (1+CoreScaleB), CoreScaleA * (1 + CoreScaleB), CoreScaleA * (1 + CoreScaleB));
	
		speed = PlayerFlight.extspeed;
	}




	//Trigger Detection Section

	void OnTriggerEnter ( Collider other)
		{
		Corerender1.enabled = false;
		Corecol1.enabled = false;
		Core1.spatialBlend = 0;
		foreach (Transform child in transform) {
			child.gameObject.SetActive(false);
		}	
		
		transform.GetChild(1).gameObject.SetActive(false);
	
			
			
		}
}