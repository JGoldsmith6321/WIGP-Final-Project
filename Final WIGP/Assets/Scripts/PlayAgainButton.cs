﻿using UnityEngine;
using System.Collections;

public class PlayAgainButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	void OnMouseDown(){
		Application.LoadLevel (0);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
