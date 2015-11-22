using UnityEngine;
using System.Collections;

public class NextCubeCode : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}

	public void ChangeColor (Color setColor){
		GetComponent<Renderer> ().material.color = setColor;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
