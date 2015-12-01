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
		if (newColor == outColor) {
			ElseClicked();
		}
		color = newColor;
	}

	public Color GetColor(){
		return color;
	}

	void OnMouseDown(){//tells MainBoard this cube was clicked
		core.WasClicked (cords);
		if (color != startColor && color != outColor && active == false) {
			active = true;
			Activate ();
		}
	}

	public void ElseClicked(){//deactivate
		if (active) {
			active = false;
			Activate ();
		}
	}

	public void Activate(){//Make bigger
		if (active == true) {
			transform.localScale += new Vector3 (0.1f, 0.1f, 0.1f);
		} else {
			if(color != startColor && color!=outColor)
			transform.localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
		}
	}

	public bool IsColor(){//tells if it's a color, any color
		if (color != startColor && color != outColor) {
			return true;
		}
		return false;
	}

	public bool CanTurn(){//IE: is white
		bool CanTurn = false;
		if (color == startColor) {//can only turn if white
			CanTurn = true;
		}
		return CanTurn;
	}
	
	void Update () {
		GetComponent<Renderer> ().material.color = color;
	}
}
