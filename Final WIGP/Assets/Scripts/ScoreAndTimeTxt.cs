using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreAndTimeTxt : MonoBehaviour {

	public MainBoard core;
	public Text scoreTxt;
	public Text timeTxt;
	public int fullGameTime = 60;
	public int time;
	
	void Start () {
		core = GameObject.FindGameObjectWithTag ("core").GetComponent<MainBoard>();
	}

	void Update () {
		time = core.GetTime ();
		time = fullGameTime - time;
		scoreTxt.text = "Score: " + core.GetScore ();
		if (time > 10) {
			timeTxt.text =  "Time: " + time;
		} else {
			timeTxt.color = Color.red;
			timeTxt.text = "Time: " + time;
		}
	}
}
