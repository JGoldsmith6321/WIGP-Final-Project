using UnityEngine;
using System.Collections;
//thank you:http://www.sitepoint.com/saving-data-between-scenes-in-unity/
public class StartEndStuff : MonoBehaviour {
	
	public float time = 0;
	public int score = 0;
	public bool won = false;
	public bool colorBlindModeOn = false;

	public static StartEndStuff Instance;
			
			void Awake ()   {
				if (Instance == null)
				{
					DontDestroyOnLoad(gameObject);
					Instance = this;
				}
				else if (Instance != this)
				{
					Destroy (gameObject);
				}
			}

	public void SetAll(bool wonGame, float timer, int theScore){
		time = timer;
		score = theScore;
		won = wonGame;
		SaveData ();
	}

	public float GetTime(){
		return time;
	}

	public int GetScore(){
		return score;
	}

	public bool GetWon(){
		return won;
	}

	public bool UseColorBlindMode(){
		return colorBlindModeOn;
	}

	public void ReverseUseColorBlindMode(){
		colorBlindModeOn = !colorBlindModeOn;
		SaveData ();
	}

	public void SaveData(){
		StartEndStuff.Instance.time = time;
		StartEndStuff.Instance.score = score;
		StartEndStuff.Instance.won = won;
		StartEndStuff.Instance.colorBlindModeOn = colorBlindModeOn;
	}

	void Start () {
		time = StartEndStuff.Instance.time;
		score = StartEndStuff.Instance.score;
		won = StartEndStuff.Instance.won;
		colorBlindModeOn = StartEndStuff.Instance.colorBlindModeOn;
	}

	void GetData(){
		time = StartEndStuff.Instance.time;
		score = StartEndStuff.Instance.score;
		won = StartEndStuff.Instance.won;
		colorBlindModeOn = StartEndStuff.Instance.colorBlindModeOn;
	}

	void Update () {
	
	}
}
