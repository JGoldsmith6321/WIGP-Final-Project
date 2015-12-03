using UnityEngine;
using System.Collections;

public class NextCubeCode : MonoBehaviour {
	
	public ColorCodesLetter text;

	// Use this for initialization
	void Start () {
		text = GetComponentInChildren<ColorCodesLetter>();
	}

	public void ChangeColor (Color setColor){
		GetComponent<Renderer> ().material.color = setColor;
		text.UpdateLetter (setColor);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
