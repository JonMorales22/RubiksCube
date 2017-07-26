using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.A))
		{
			Dim ();
		}
	}

	public void Dim()
	{
		Renderer rend = GetComponent<Renderer> ();
		Material mat = rend.material;
		Color col = mat.color;
		Color alphaCol = new Color (col.r, col.g, col.b, .25f);
		mat.color = alphaCol;
	}

}
