using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DisableButton : MonoBehaviour {
	public Transform button;

	public void changestat(){

		if (button.GetComponent<Button>().IsInteractable() == true)
		{
			button.GetComponent<Button>().interactable = false; 
		}
		else //Else make it interactable
		{
			button.GetComponent<Button>().interactable = true;
		}
	}
}