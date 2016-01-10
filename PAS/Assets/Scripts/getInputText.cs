using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class getInputText : MonoBehaviour
{
    void Start()
    {
        var input = gameObject.GetComponent<InputField>();
        var se = new InputField.SubmitEvent();
        se.AddListener(SubmitName);
        input.onEndEdit = se;
        input.DeactivateInputField();
        this.gameObject.SetActive(false);

        //or simply use the line below, 
        //input.onEndEdit.AddListener(SubmitName);  // This also works
    }

    private void SubmitName(string arg0)
    {
        Debug.Log(arg0);
    }
}
