using UnityEngine;
using System.Collections;

public class ClassInfo : MonoBehaviour {

	public MainBoard core;
	public int[] cords;
	public Color color = Color.white;
	public Color startColor = Color.white;
	public bool active = false;
	public Color outColor = Color.black;
	public Color otherOutColor = Color.gray;
	public ColorCodesLetter text;

	// Use this for initialization
	void Start () {
		text = GetComponentInChildren<ColorCodesLetter>();
		core = GameObject.FindGameObjectWithTag ("core").GetComponent<MainBoard>();
	}

	public void SetCords(int[] at){
		cords = at;
	}

	public void SetColor(Color newColor){
		if (newColor == outColor || newColor == otherOutColor) {
			ElseClicked();
		}
		color = newColor;
		GetComponent<Renderer> ().material.color = color;
		text.UpdateLetter (color);
	}

	public Color GetColor(){
		return color;
	}

	void OnMouseDown(){//tells MainBoard this cube was clicked
		core.WasClicked (cords);
		if (color != startColor && color != outColor && color!= otherOutColor && active == false) {
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
			if(color != startColor && color!=outColor && color!= otherOutColor)
			transform.localScale -= new Vector3 (0.1f, 0.1f, 0.1f);
		}
	}

	public bool IsColor(){//tells if it's a color, any color
		if (color != startColor && color != outColor && color!= otherOutColor) {
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
	}
}
