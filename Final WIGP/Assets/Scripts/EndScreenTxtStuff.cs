using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EndScreenTxtStuff : MonoBehaviour {

	public Text scoreTxt;
	public Text wonTxt;
	public Text timeTxt;
	public float time;
	public int score;
	public bool wonGame;
	public GameObject globalObj;
	public StartEndStuff globalObjCode;

	// Use this for initialization
	void Start () {
		globalObj = GameObject.FindGameObjectWithTag("globalObj");
		globalObjCode = globalObj.GetComponent<StartEndStuff> ();
		score = globalObjCode.GetScore ();
		time = globalObjCode.GetTime ();
		if (time < 0) {
			time =0;}// I was getting weird negative outputs
		wonGame = globalObjCode.GetWon ();
		if (wonGame) {
			wonTxt.text = "You Won!";
		} else {
			wonTxt.text = "You Lost!";
		}
		scoreTxt.text = "Score: " + score;
		timeTxt.text = "Time Left: " + time;
	}

	// Update is called once per frame
	void Update () {
	
	}
}
