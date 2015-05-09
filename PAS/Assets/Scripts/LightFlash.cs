using UnityEngine;
using System.Collections;

public class LightFlash : MonoBehaviour {

    public float flashDuration = 2;

    Light light;
    float t = 0; //For lerping
    Color currentColor = Color.white;
    Color normalColor = Color.white;
    Color incorrectColor = new Color(255f/255,163f/255,163f/255,255f/255);
    Color correctColor = new Color(169f/255,255f/255,219f/255,255f/255);

    bool flashingIncorrect = false;
    bool flashingCorrect = false;

	// Use this for initialization
	void Start () 
    {
        light = this.GetComponent<Light>();	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (flashingCorrect)
        {
            light.color = Color.Lerp(normalColor, correctColor, t);
            currentColor = Color.Lerp(normalColor, correctColor, t);
        }

        else if (flashingIncorrect)
        {
            light.color = Color.Lerp(normalColor, incorrectColor, t);
            currentColor = Color.Lerp(normalColor, incorrectColor, t);
        }

        else
        {
            light.color = Color.Lerp(currentColor, normalColor, t);
            currentColor = Color.Lerp(currentColor, normalColor, t);
        }

        if (currentColor == correctColor || currentColor == incorrectColor)
        {
            resetFlashes();
        }

        if (t < 1)
            t += Time.deltaTime / flashDuration;
           


	}

    void resetFlashes()
    {
        flashingCorrect = false;
        flashingIncorrect = false;
        t = 0;
    }

    public void flashIncorrect()
    {
        flashingIncorrect = true;
        t = 0;
    }

    public void flashCorrect()
    {
        flashingCorrect = true;
        t = 0;
    }
}
