using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class findSinglePlayerResults : MonoBehaviour
{

    GameObject persistentGameObject;
    public GameObject UItext;

    // Use this for initialization
    void Start()
    {
        persistentGameObject = GameObject.Find("singleplayerResults");

        singleplayerResults sp = persistentGameObject.GetComponent<singleplayerResults>();

        Debug.Log(sp.winner);

        UItext.GetComponent<Text>().text = sp.winner;

    }

    // Update is called once per frame
    void Update()
    {
    }
}