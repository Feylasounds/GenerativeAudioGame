using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistortedVerts : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		var distortedSphere = GetComponent<MeshFilter>();
		var vertices = distortedSphere.mesh.vertices;
		
		for (var i = 0; i < vertices.Length; i++)
		{
			vertices[i] *= Random.Range(0f, 2f);
		}

		distortedSphere.mesh.vertices = vertices;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
