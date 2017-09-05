using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Instructions : MonoBehaviour {

    Text instructions;
    int timer = 350;

	// Use this for initialization
	void Start () {
        instructions = GetComponent<Text>();
        instructions.text = "Use the arrow keys to move and left ctrl to shoot fire. Burn the bats that are attacking you and the beautiful forest!";
	}
	
	// Update is called once per frame
	void Update () {
        if (timer > 0)
            timer = timer - 1;
        else
            instructions.text = "";
	}
}
