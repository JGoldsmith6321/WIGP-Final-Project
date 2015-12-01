using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MainBoard : MonoBehaviour {

	public GameObject nextCube;
	public NextCubeCode nextCubeCode;
	public GameObject cube;
	public int xMax = 8;
	public int yMax = 5;
	public float xSpotStart = -5.59f;
	public float ySpotStart = -3.1f;
	public float instCubesMoveBy = 1.6f;
	public int fullGameTime = 60;
	public float turnTime = 2f;
	public float lastTurnTime = 0;
	public ClassInfo[,] grid = new ClassInfo[8,5];//[xMax,yMax]
	public Color[] Colors = new Color[]{Color.blue,Color.green,Color.red,Color.yellow,Color.magenta}; 
	public int[] lastCubeClicked = new int[] {9,6};
	public Color nextCubeColor;
	public List<Color> row1;
	public List<Color> row2;
	public List<Color> row3;
	public List<Color> row4;
	public List<Color> row5;
	public bool keyWasPressedThisTurn = true;
	public bool closeGame = false;
	public int score = 0;
	public int plusScoreOne = 10;
	public int plusScoreMany = 5;
	public bool won = false;



	// Use this for initialization
	void Start () {
		nextCubeCode = nextCube.GetComponent<NextCubeCode> ();
		float ySpot = ySpotStart;
		for (int y = 0; y < yMax; y++) {
			float xSpot = xSpotStart;
			for(int x = 0; x < xMax; x++){// the x side
				Vector3 pos = new Vector3(xSpot,ySpot,0);
				GameObject thisCube = Instantiate(cube,pos,Quaternion.identity) as GameObject;
				grid[x,y] = thisCube.GetComponent<ClassInfo>();
				int[] cords = new int[]{x,y};
				grid[x,y].SetCords(cords);
				xSpot = xSpot + instCubesMoveBy;
			}
			ySpot = ySpot + instCubesMoveBy;
		}
		// set lists for each row
		//row1 = new List<Color>(grid[]);
	
	}

	public void ChangeNextCube(bool newTurn){//changes the next cube color
		if (newTurn) {
			nextCubeColor = Colors [Random.Range (0, Colors.Length)];
		} else {
			nextCubeColor = Color.white;
		}
		nextCubeCode.ChangeColor (nextCubeColor);
	}

	public void WasClicked(int[] clickedCube){
		//is given [x,y] and updates other cubes, moves active cube if clicked cube is white and last cube clicked is colored and next to it
		ClassInfo classThisCube = grid[clickedCube[0],clickedCube[1]];
		if (classThisCube.IsColor ()) {
			if(lastCubeClicked [0] != 9 && lastCubeClicked != clickedCube){
				grid[lastCubeClicked[0],lastCubeClicked[1]].ElseClicked();//set last cube to not active
			}
			lastCubeClicked = clickedCube;
		}
		else{
			if (lastCubeClicked [0] != 9){
				ClassInfo classLastCube = grid[lastCubeClicked[0],lastCubeClicked[1]];
				if ((lastCubeClicked [0] + 1 == clickedCube[0]&&lastCubeClicked [1] == clickedCube[1])||
				(lastCubeClicked [0] - 1 == clickedCube[0]&&lastCubeClicked [1] == clickedCube[1])||
				(lastCubeClicked [1] + 1 == clickedCube[1]&&lastCubeClicked [0] == clickedCube[0])||
				(lastCubeClicked [1] - 1 == clickedCube[1]&&lastCubeClicked [0] == clickedCube[0])){
					if(classThisCube.CanTurn() && classLastCube.IsColor()){
						classLastCube.ElseClicked();//set last cube to not active
						classThisCube.SetColor(classLastCube.GetColor());
						classLastCube.SetColor(Color.white);
						lastCubeClicked = clickedCube;
					}
				}
			}
		}
	}

	bool EndGame(){//checks the end game stuff
		if (Time.time > fullGameTime) {
			if(score>0){won = true;}
			return true;}
		return false;
	}

	public int GetScore(){//return score
		UpdateScore ();
		return score;
	}

	public void UpdateScore(){//checks for score things, sets them to black
		bool hasAPlus = false;
		ClassInfo[] plusCubes = new ClassInfo[]{grid[0,0]}; // or it throws an error
		int rowAt = 1;
		int colAt = 1;
		//for all center columns
		while (colAt != yMax-1 && hasAPlus == false) {
			//check for a +
			while (rowAt != xMax-1) {
				if (grid [rowAt - 1, colAt].IsColor () && grid [rowAt, colAt].IsColor () && grid [rowAt + 1, colAt].IsColor ()
					&& grid [rowAt, colAt + 1].IsColor () && grid [rowAt, colAt - 1].IsColor ()) {
					hasAPlus = true;
					plusCubes = new ClassInfo[]{grid [rowAt - 1, colAt], grid [rowAt, colAt], grid [rowAt + 1, colAt], grid [rowAt, colAt + 1], grid [rowAt, colAt - 1]};
				}
				if (grid [rowAt, colAt - 1].IsColor () && grid [rowAt, colAt].IsColor () && grid [rowAt, colAt + 1].IsColor ()
				    && grid [rowAt + 1, colAt].IsColor () && grid [rowAt - 1, colAt].IsColor ()) {
					hasAPlus = true;
					plusCubes = new ClassInfo[]{grid [rowAt, colAt - 1], grid [rowAt, colAt], grid [rowAt, colAt + 1], grid [rowAt + 1, colAt], grid [rowAt - 1, colAt]};
				}
				rowAt++;
			}
			colAt++;
			rowAt = 1;
		}

		if (hasAPlus) {
			Color baseColor = plusCubes[0].GetColor ();
			if(plusCubes[1].GetColor ()==baseColor && plusCubes[2].GetColor ()==baseColor && plusCubes[3].GetColor ()==baseColor && plusCubes[4].GetColor ()==baseColor){
				score = score + plusScoreOne;
			}
			else{score = score + plusScoreMany;}
			int changingAt=0;
			while(changingAt < 5){
				plusCubes[changingAt].SetColor(Color.black);
				changingAt++;
			}
		}
	}

	ClassInfo FindASpot(int row){//finds a spot to place the next cube color
		ClassInfo toChange = null;
		int openSpots = 0;
		bool canReturn = false;
		if (row != grid.GetLength(0)) {//just looking at one row
			int spotAt = 0;
			while(spotAt < grid.GetLength (0)){
				ClassInfo checking = grid[spotAt,row];
				if (checking.CanTurn()){
					openSpots++;
				}
				spotAt++;
			}
			if(openSpots != 0){
				while(canReturn == false){
					toChange = grid[Random.Range(0,grid.GetLength(0)), row];
					if (toChange.CanTurn()){
						return toChange;
						//canReturn = true;
					}
				}
				
			}
		}
		if (row == grid.GetLength (0)) {//to find any open
			int xSpotAt = 0;
			int ySpotAt = 0;
			while (ySpotAt < grid.GetLength (1)) {
				while (xSpotAt < grid.GetLength (0)) {
					ClassInfo checking = grid[xSpotAt, ySpotAt];
					if (checking.CanTurn () ) {
						openSpots++;
					}
					xSpotAt++;
				}
				ySpotAt++;
			}
			if(openSpots != 0){
				while (canReturn == false){
					toChange = grid[Random.Range(0,grid.GetLength(0)), Random.Range(0,grid.GetLength(1))];
					if (toChange.CanTurn()){
						return toChange;
						//canReturn = true;
					}
				}
				
			}
		}
		if (openSpots == 0) {
			Application.LoadLevel (0);
		}
		return null;
	}


	// Update is called once per frame
	void Update () {
		GetScore ();
		if (EndGame ()) {
			Application.LoadLevel (0);
		}
		if (Time.time > lastTurnTime) {//at start of turn
			ChangeNextCube (true);
			lastTurnTime = Time.time + turnTime;
			if (keyWasPressedThisTurn == false) {//if nothing was pressed, change a random cube to black, score--
				if (score>0){
					score--;}
				ClassInfo toChange = FindASpot(grid.GetLength (0));
				if(toChange != null){
					toChange.SetColor(Color.black);
				}else{Application.LoadLevel (0);}//redundant, but I like it
			}
			keyWasPressedThisTurn = false;
		}
		int pressed = 0;
		//player presses button
		if (Input.GetKeyDown (KeyCode.Alpha1) || Input.GetKeyDown (KeyCode.Keypad1)) {
			pressed = 1;
			keyWasPressedThisTurn = true;
		} else if (Input.GetKeyDown (KeyCode.Alpha2) || Input.GetKeyDown (KeyCode.Keypad2)) {
			pressed = 2;
			keyWasPressedThisTurn = true;
		} else if (Input.GetKeyDown (KeyCode.Alpha3) || Input.GetKeyDown (KeyCode.Keypad3)) {
			pressed = 3;
			keyWasPressedThisTurn = true;
		} else if (Input.GetKeyDown (KeyCode.Alpha4) || Input.GetKeyDown (KeyCode.Keypad4)) {
			pressed = 4;
			keyWasPressedThisTurn = true;
		} else if (Input.GetKeyDown (KeyCode.Alpha5) || Input.GetKeyDown (KeyCode.Keypad5)) {
			pressed = 5;
			keyWasPressedThisTurn = true;
		}

		if (pressed != 0){
			ClassInfo toChange = FindASpot(pressed-1);
			if(toChange != null){
				toChange.SetColor(nextCubeColor);
				ChangeNextCube(false);
			}

		}
	}
}
