using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreAndTimeTxt : MonoBehaviour {

	public MainBoard core;
	public Text txt;
	
	void Start () {
		core = GameObject.FindGameObjectWithTag ("core").GetComponent<MainBoard>();
	}

	void Update () {
		int time = (int)Time.time;
		txt.text = "Score: " + core.GetScore() + "  Time: " + time;
	}
}
