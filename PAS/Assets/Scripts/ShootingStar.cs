using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingStar : MonoBehaviour
{
    public GameObject shootingStar;

    public bool debugMode = false;

    public SingleMain singleMain = null; //Shooting stars as powerups only work for single player mode. 

    private float checkpointTime = 0, amplitude = 2.8f, omega = 6f, xScalar = 14;
    private int currentLevel = 0;

    GameObject cloneStar;
    System.Random r = new System.Random();
    bool isUp = true;
    bool starAlive = false;

    void Update()
    {
        checkpointTime += Time.deltaTime;
        float x = -10 + xScalar * checkpointTime * (1 + currentLevel / 100);
        float y = amplitude * Mathf.Sin(omega * checkpointTime);
        if (starAlive) { cloneStar.transform.localPosition = new Vector3(x, y, 0); }

        if (debugMode)
        {
            if (!starAlive) starFactory(1);
            if (Input.GetKeyDown(KeyCode.Space)) destroyStar();
        }

    }
    public void starFactory(int level)
    {
        cloneStar = Instantiate(shootingStar, new Vector3(-15, (float)(r.NextDouble() * 5 - 5), 0), Quaternion.identity) as GameObject;
        starAlive = true;
        cloneStar.GetComponent<ParticleSystem>().GetComponent<Renderer>().sortingLayerName = "star";
        cloneStar.GetComponent<ShootingStarObject>().setStarFactory(this);

        if (singleMain != null) cloneStar.GetComponent<ShootingStarObject>().setSingleMain(singleMain);

        cloneStar.GetComponent<ShootingStarObject>().setPowerUp(PowerUp.getRandomPowerUp());

        checkpointTime = 0;
        this.currentLevel = level;
    }
    public Vector3 destroyStar()
    {
        Vector3 lastPos = new Vector3();
        foreach (GameObject shape in GameObject.FindGameObjectsWithTag("ShootingStar"))
        {
            lastPos = shape.transform.position;
            Object.Destroy(shape);
            starAlive = false;
        }
        return lastPos;
    }
}