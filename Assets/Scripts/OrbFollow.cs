using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbFollow : MonoBehaviour
{
	private const float speed = 50;
	
	private Transform friend;
	private Transform enemy;
	private float random;

	// Use this for initialization
	void Start ()
	{
		random = speed;
		
		int count = transform.parent.childCount;
		int index = transform.GetSiblingIndex();
		friend = transform.parent.GetChild(mod(index + 1, count));
		enemy = transform.parent.GetChild(mod(count - 1, count));
	}
	
	/**
	 * mod, prevents negative numbers
	 */
	int mod(int x, int m) {
		return (x%m + m)%m;
	}
	
	// Update is called once per frame
	void Update ()
	{
		random = Mathf.Clamp(random + Random.Range(-speed, speed) * Time.deltaTime, speed, speed * 2);
		Vector3 avoidVector = transform.position - enemy.position;
		Vector3 followVector = friend.position - transform.position;
		transform.Translate((avoidVector.normalized + followVector.normalized) * random * Time.deltaTime);
	}
}
