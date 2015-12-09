using UnityEngine;
using System.Collections;

public class ColorCodesLetter : MonoBehaviour {

	public string[] names = new string[] {"B","G","R","Y","M"};
	public Color[] Colors = new Color[]{Color.blue,Color.green,Color.red,Color.yellow,Color.magenta}; 
	public TextMesh text;
	public StartEndStuff worldObjCode;

	// Use this for initialization
	void Start () {
		worldObjCode = GameObject.FindGameObjectWithTag ("globalObj").GetComponent<StartEndStuff>();
		text = GetComponent<TextMesh> ();
		text.text = " ";
	}

	public void UpdateLetter(Color color){
		text.text = " ";
		if (worldObjCode.UseColorBlindMode ()) {
			for (int at = 0; at < Colors.Length; at++) {
				if (color == Colors [at]) {
					text.text = names [at];
				}
			}
		}
	}

	// Update is called once per frame
	void Update () {
	
	}
}
