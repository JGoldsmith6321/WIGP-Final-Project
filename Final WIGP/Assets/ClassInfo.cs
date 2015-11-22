using UnityEngine;
using System.Collections;

public class ClassInfo : MonoBehaviour {

	public MainBoard core;
	public int[] cords;
	public Color color = Color.white;
	public Color startColor = Color.white;
	public bool active = false;
	public Color outColor = Color.black;

	// Use this for initialization
	void Start () {
		core = GameObject.FindGameObjectWithTag ("core").GetComponent<MainBoard>();
	
	}

	public void SetCords(int[] at){
		cords = at;
	}

	public void SetColor(Color newColor){
		color = newColor;
	}

	void OnMouseDown(){
		core.WasClicked (cords);
		if (color != startColor && color != outColor && active == false) {
			active = true;
			Activate ();
		}
	}

	public void ElseClicked(){
		if (active == true) {
			active = false;
			Activate ();
		}
	}

	public void Activate(){
		if (active == true) {
			transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
		} else {
			if(color != startColor && color!=outColor)
			transform.localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
		}
	}

	public bool CanTurn(){
		bool CanTurn = false;
		if (color == startColor) {//can only turn if white
			CanTurn = true;
		}
		return CanTurn;
	}

	// Update is called once per frame
	void Update () {
		GetComponent<Renderer> ().material.color = color;
	}
}
