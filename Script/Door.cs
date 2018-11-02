using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Door : MonoBehaviour {

	public delegate void UpdateDoor ();
	public UpdateDoor onDoor;

	bool state;
	bool moving;
	
	void Start () {
		GameControl.door += Toggle;
		state = false;	
	}

	void Update () {
		if (moving)
			onDoor();	
	}

	void Open () {
		if (transform.localEulerAngles.y < 90)
			transform.Rotate (0, 1, 0);
		else
			moving = false;		
	}

	void Close () {
		if (transform.localEulerAngles.y > 1)
			transform.Rotate (0,-1, 0);
		else
			moving = false;		
	}

	void Toggle () {
		moving = true;
		state = !state;
		if (state)
			onDoor = Open;
		else
			onDoor = Close;
	}

	private void OnCollisionEnter(Collision other) {
		if (other.gameObject.CompareTag("Player")) {
			GameControl.doors = true;		
		}
	}
	
}



﻿
