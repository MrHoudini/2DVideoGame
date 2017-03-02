using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Movement : MonoBehaviour {

	private Rigidbody m_Rigidbody;
	private string m_MovementAxisName;
	private string m_TurnAxisName;
	private float m_MovementInputValue;
	private float m_TurnInputValue;
	public float m_Speed;
	public float m_MaxSpeed;
	public float m_TurnSpeed;
	public float m_Resistance;
	public float m_TurnDecrease;

	private void Awake ()
	{
		m_Rigidbody = GetComponent<Rigidbody> ();
	}

	void Start () 
	{
		m_MovementAxisName = "Vertical";
		m_TurnAxisName = "Horizontal";

		//Rotacio lockejada

	}

	void Update () 
	{
		m_MovementInputValue = Input.GetAxis (m_MovementAxisName);
		m_TurnInputValue = Input.GetAxis (m_TurnAxisName);
	}

	private void FixedUpdate ()
	{
		Move ();
		Turn ();
	}

	private void Move()
	{
		//Debug.Log (Input.GetAxis("Vertical"));

	
		//Moviment bàsic en la direxió de l'eix blau. Si la velocitat es 0 o està anant cap enrere l'avio funciona mes lent anant cap enrere. 
		//Aixo vol dir que el boto (s) frena l'avio pero no permet moure amb velocitat cap enrere.
		if (Input.GetAxis("Vertical") <= 0) //Parat o cap enrere
		{
			m_Rigidbody.drag = m_Resistance;
		}
		else // Pa'lante
		{
			//Vector3 movement = transform.forward * m_MovementInputValue * m_Speed * Time.deltaTime;
			m_Rigidbody.drag = 0f;
			m_Rigidbody.AddForce(transform.forward * m_MovementInputValue * m_Speed);
		}

		//Si no s'aporta input el player es va parant


		//Limit de velocitat
		if (m_Rigidbody.velocity.magnitude >= m_MaxSpeed) 
		{
			m_Rigidbody.velocity = m_Rigidbody.velocity.normalized * m_MaxSpeed;
		}
	}
		
	private void Turn()
	{

		if (Input.GetAxis ("Vertical") != 1) //Al alliberar la (w)
		{ 
			float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime / m_TurnDecrease;
			Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
			m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
		} 
		else //AL clickar la (w)
		{ 
			float turn = m_TurnInputValue * m_TurnSpeed * Time.deltaTime;
			Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
			m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
		}
			
		//m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationX;
		//m_Rigidbody.constraints = RigidbodyConstraints.FreezeRotationY;
	}
		
}



