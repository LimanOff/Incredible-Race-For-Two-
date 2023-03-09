using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Dot_Truck : System.Object
{
	public WheelCollider leftWheel;
	public GameObject leftWheelMesh;
	public WheelCollider rightWheel;
	public GameObject rightWheelMesh;
	public bool motor;
	public bool steering;
	public bool reverseTurn;
}

public class Dot_Truck_Controller : MonoBehaviour {

	public float maxMotorTorque;
	public float maxSteeringAngle;

	private float _motor;
	private float _steering;
	private float _brakeTorque;

	private string _playerName;
	public Rigidbody _rb;

	public List<Dot_Truck> truck_Infos;

	private void Start() 
	{
		_playerName = gameObject.name;
	}
	public void VisualizeWheel(Dot_Truck wheelPair)
	{
		Quaternion rot;
		Vector3 pos;
		wheelPair.leftWheel.GetWorldPose ( out pos, out rot);
		wheelPair.leftWheelMesh.transform.position = pos;
		wheelPair.leftWheelMesh.transform.rotation = rot;
		wheelPair.rightWheel.GetWorldPose ( out pos, out rot);
		wheelPair.rightWheelMesh.transform.position = pos;
		wheelPair.rightWheelMesh.transform.rotation = rot;
	}

	public void Update()
	{
		if(_playerName == "Player1")
		{
		 _motor = maxMotorTorque * Input.GetAxis("Vertical_WASD");
		 _steering = maxSteeringAngle * Input.GetAxis("Horizontal_WASD");
		}

		if(_playerName == "Player2")
		{
		 _motor = maxMotorTorque * Input.GetAxis("Vertical_ARROWS");
		 _steering = maxSteeringAngle * Input.GetAxis("Horizontal_ARROWS");
		}
		
		if((_rb.velocity.magnitude < 0.1) || _motor != 0)
		{
			_brakeTorque = 0;
		}
		
		if (_motor == 0)
		{
			_brakeTorque = maxMotorTorque;
		}
		

		foreach (Dot_Truck truck_Info in truck_Infos)
		{
			if (truck_Info.steering == true) {
				truck_Info.leftWheel.steerAngle = truck_Info.rightWheel.steerAngle = ((truck_Info.reverseTurn)?-1:1)*_steering;
			}

			if (truck_Info.motor == true)
			{
				truck_Info.leftWheel.motorTorque = _motor;
				truck_Info.rightWheel.motorTorque = _motor;
			}

			truck_Info.leftWheel.brakeTorque = _brakeTorque * _brakeTorque;
			truck_Info.rightWheel.brakeTorque = _brakeTorque * _brakeTorque;

			VisualizeWheel(truck_Info);
		}
	}
}