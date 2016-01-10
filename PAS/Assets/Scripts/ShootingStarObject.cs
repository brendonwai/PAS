using UnityEngine;
using System.Collections;

public class ShootingStarObject : MonoBehaviour
{

    private ShootingStar starFactory;
    private SingleMain singleMain;

    public GameObject PowerUpLife_Sprite;
    public GameObject PowerUpScore_Sprite;
    public GameObject PowerUpTime_Sprite;


    private PowerUp.Types powerUp;

    

    public void setPowerUp(PowerUp.Types p)
    {
        if (starFactory.debugMode) Debug.Log("I'm a " + PowerUp.toString(p) + ", hi there : )");
        powerUp = p;

        setPowerUpSprite();
    }

    void setPowerUpSprite()
    {
        //NOTE: This does not disable the previous sprite if this function has been called twice for a single object.
        //If we ever want to add the functionality of stars with dynamic power ups, this will need to be changed.
        switch(powerUp)
        {
            case PowerUp.Types.LifeIncrease:
                PowerUpLife_Sprite.SetActive(true);
                break;
            case PowerUp.Types.ScoreIncrease:
                PowerUpScore_Sprite.SetActive(true);
                break;
            case PowerUp.Types.TimeIncrease:
                PowerUpTime_Sprite.SetActive(true);
                break;
        }
    }

    public void setStarFactory(ShootingStar factory)
    {
        starFactory = factory;
    }

    public void setSingleMain(SingleMain single)
    {
        singleMain = single;
    }

    void OnMouseDown()
    {
        if (starFactory.debugMode) Debug.Log("I've been clicked! ;O");

        starFactory.destroyStar();
    }
}