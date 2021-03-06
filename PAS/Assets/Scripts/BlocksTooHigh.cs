﻿using UnityEngine;
using System.Collections;

public class BlocksTooHigh : MonoBehaviour {

	public BoxCollider2D blockStopper;

	public float removeStopperDuration;

	float removeStopperTimestamp;

	bool triggerIsActive = false; 

	void Start()
	{

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Shape")
		{
			blockStopper.isTrigger = true;
			triggerIsActive = true;
			removeStopperTimestamp = removeStopperDuration + Time.time;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Shape")
		{
			blockStopper.isTrigger = true;
			triggerIsActive = true;
			removeStopperTimestamp = removeStopperDuration + Time.time;
		}
	}


	void Update()
	{
		if (Time.time > removeStopperTimestamp && triggerIsActive == true)
		{
			blockStopper.isTrigger = false;
			triggerIsActive = false;
		}

	}
}
