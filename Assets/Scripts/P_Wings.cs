using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Wings : MonoBehaviour {

	public GameObject m_Wings;
	private float m_Angle;
	private float m_Scale;

	void Start () {
	}
	

	void FixedUpdate () {
		Vector3 direction = new Vector3(0f, 1.0f, 0f);
		float angle = Vector3.Angle( direction, transform.forward ); //0-180 

		float angleRedux = angle * 0.01744444f;//0-3.14
		m_Scale = Mathf.Cos(angleRedux) * 10; //0-1;
		m_Wings.transform.localScale = new Vector3(m_Scale, m_Wings.transform.localScale.y, m_Wings.transform.localScale.z);
		Debug.Log (m_Scale);
	
	}
}
