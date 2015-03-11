using UnityEngine;
using System.Collections;

public class THERESSOMETHINGINSIDEME : MonoBehaviour {

	void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log("holy shit there's inside me");
	}

}
