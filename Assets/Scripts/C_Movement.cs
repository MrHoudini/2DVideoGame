using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C_Movement : MonoBehaviour {

	public GameObject player;
	private Vector3 offset; 
	public float m_DampTime = 0.2f;
	public float m_DampTimeSize = 0.2f;
	private float m_ZoomSpeed;
	private Vector3 velocity = Vector3.zero;
	private Camera m_Camera;
	public float m_Size;
	public float m_BigSize;

	void Start () {
		offset = transform.position - player.transform.position;
		m_Camera = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//transform.position = player.transform.position + offset;
		Vector3 targetPosition = player.transform.position + offset;
		transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, m_DampTime);

		//Zoom
		if (Input.GetAxis ("Vertical") == 1) {
			m_Camera.orthographicSize = Mathf.SmoothDamp (m_Camera.orthographicSize, m_BigSize, ref m_ZoomSpeed, m_DampTimeSize);
		} else {
			m_Camera.orthographicSize = Mathf.SmoothDamp (m_Camera.orthographicSize, m_Size, ref m_ZoomSpeed, m_DampTimeSize);
		}
		//m_Camera.orthographicSize = 30;
	}
}

