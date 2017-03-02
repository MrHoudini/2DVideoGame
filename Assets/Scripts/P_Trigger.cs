using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Trigger : MonoBehaviour {

	private Rigidbody m_Rigidbody;
	public float force;


	private void Awake ()
	{
		m_Rigidbody = GetComponent<Rigidbody> ();
	}

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other)
	{
		Vector3 center = new Vector3(0f,0f,0f);
		Vector3 direction = center - transform.position;
		m_Rigidbody.AddForce (direction * force);
	}
}
