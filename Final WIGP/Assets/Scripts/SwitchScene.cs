using UnityEngine;
using System.Collections;

public class SwitchScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void Go (){
		Application.LoadLevel (1);
	}

	public void Restart (){
		Application.LoadLevel (0);
	}

	public void InfoScreen (){
		Application.LoadLevel (3);
	}

	// Update is called once per frame
	void Update () {
	}
}
