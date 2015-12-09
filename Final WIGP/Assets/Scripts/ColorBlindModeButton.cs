using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorBlindModeButton : MonoBehaviour {
	
	public StartEndStuff worldObjCode;
	public GameObject buttonTxtObj;
	public Text buttonTxt;


	// Use this for initialization
	void Start () {
		buttonTxt = buttonTxtObj.GetComponent<Text>();
		worldObjCode = GameObject.FindGameObjectWithTag ("globalObj").GetComponent<StartEndStuff>();
		if (worldObjCode.UseColorBlindMode ()) {
			buttonTxt.text = "Color Blind Mode: ON";
		} else {
			buttonTxt.text = "Color Blind Mode: OFF";
		}
	}

	public void ChangeText(){
		worldObjCode.ReverseUseColorBlindMode ();
		if (worldObjCode.UseColorBlindMode ()) {
			buttonTxt.text = "Color Blind Mode: ON";
		} else {
			buttonTxt.text = "Color Blind Mode: OFF";
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
