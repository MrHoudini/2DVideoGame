using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Gravity : MonoBehaviour {

	private Rigidbody m_Rigidbody;
	//private Rigidbody m_RigidbodyChild;
	public float m_gravity;

	void Start () {
		m_Rigidbody = GetComponent<Rigidbody> ();
		//m_RigidbodyChild = GetComponentInChildren<Rigidbody> ();
	}
	

	void FixedUpdate () {
		if (Input.GetAxis ("Vertical") == 0)
		{ 
			float gforce = m_gravity * -1.0f;
			Vector3 result = new Vector3 (0, gforce, 0);
			Physics.gravity = result;
			//m_RigidbodyChild.AddForce (result*gforce);
			//Debug.Log(m_RigidbodyChild.velocity);
		} 
		else 
		{ 
			m_Rigidbody.useGravity = false;
		}
	}
}
