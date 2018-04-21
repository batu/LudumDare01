using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quad : Clickable {

    QuadGame quadGame;
    int current_number;
    TextMesh text;
    SpriteRenderer rend;


    public void visualInit(int number) {
        text.text = number.ToString();
    }
    public void init(int number) {
        current_number = number;
        text.text = current_number.ToString();
        rend.color = Color.white;
    }

    public void updateColor(Color color) {
        rend.color = color;
    }
    override public void Click() {
        quadGame.addToClickedList(current_number, transform);
    }

	// Use this for initialization
	void Start () {
        quadGame = transform.parent.gameObject.GetComponent<QuadGame>();
        rend = GetComponent<SpriteRenderer>();
        text = transform.GetComponentInChildren<TextMesh>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
