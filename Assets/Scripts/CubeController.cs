using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
	
	public bool mouseClick, flag;
	public Vector3 direction;
	public float waitTime, deltaTime;
	public float velocity, acceleration;
	public float torque;
	public Vector3 startPos, finalPos;
	public Rigidbody rb;

	void Update()
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		if (Input.GetMouseButtonDown (0) && Physics.Raycast (ray)) {
			startPos = Input.mousePosition;
			mouseClick = true;
			if(!flag)
				StartCoroutine (MouseMove ());
		}
		if (Input.GetMouseButtonUp (0)&&mouseClick==true) {
			mouseClick = false;
			finalPos = Input.mousePosition;
			direction = calcDirectionVector ();
			velocity = calcVelocity();
			acceleration = calcAcceleration();
			ApplyForce ();
		}
		if (Input.GetKeyDown (KeyCode.Space))
		{
			//transform.rotation = Quaternion.identity;

			rb.velocity = Vector3.zero;
			rb.angularVelocity = Vector3.zero;
			transform.position = Vector3.zero;
		}
//		if (Input.GetKeyDown (KeyCode.Q))
//		{
//			CubitScript[] cubeArray = GetComponentsInChildren<CubitScript> ();
//			foreach (CubitScript temp in cubeArray)
//			{
//				if (!temp.label.Equals("Center"))
//				{
//					temp.Dim ();
//				}
//			}
//		}
//		if (Input.GetKeyDown(KeyCode.RightArrow))
//		{
//			rb.AddTorque (-transform.up * torque);
//		}
//		if (Input.GetKeyDown(KeyCode.DownArrow))
//		{
//			rb.AddTorque (transform.right * torque);
//		}
	}

	IEnumerator MouseMove()
	{	
		flag = true;
		float startTime = Time.time;
		while (mouseClick)
		{
			yield return new WaitForSeconds(waitTime);
		}
		float endTime = Time.time;
		deltaTime = endTime - startTime;
		flag = false;
	}

	Vector3 calcDirectionVector()
	{
		return finalPos - startPos;
	}

	float calcVelocity()
	{
		return (Vector3.Magnitude(finalPos-startPos) / deltaTime);
	}

	float calcAcceleration()
	{
		return (velocity / deltaTime);
	}

	void ApplyForce()
	{
		Vector3 worldVector = Camera.main.ScreenToViewportPoint (direction);
		Vector3 newVector = new Vector3(-worldVector.y, -worldVector.x, 0f);
		Debug.Log (newVector);
		rb.AddTorque (newVector * torque);
	}
}
