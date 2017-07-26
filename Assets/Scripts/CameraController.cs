using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	Camera cam;
	int mask = 255;
	int cornerLayer = 8, edgeLayer = 9, centerLayer = 10;
	//bool cornersOn = true, centerOn = true, edgesOn = true;

	void Start()
	{
		cam = GetComponent<Camera> ();
		int mask = cam.cullingMask;
	}

	void Update()
	{
		//corner
		if (Input.GetKeyDown (KeyCode.Q))
		{
			//int cornerlayer = 8; 
			//DisableLayer (cornerlayer);

			int layerMask = ~(1 << edgeLayer | 1 << centerLayer);
			cam.cullingMask = layerMask;
		}
		//edge
		if (Input.GetKeyDown (KeyCode.W))
		{
			int layerMask = ~(1 << cornerLayer | 1 << centerLayer);
			cam.cullingMask = layerMask;
		}
		//center
		if (Input.GetKeyDown (KeyCode.E))
		{
			int layerMask = ~(1 << cornerLayer | 1 << edgeLayer);
			cam.cullingMask = layerMask;
		}
		if (Input.GetKeyDown (KeyCode.R))
		{
			cam.cullingMask = -1;
		}
	}

//	void DisableLayer(int layer)
//	{
//		int layerMask = ~(1 << layer);
//		cam.cullingMask = layerMask;
//	}
}
