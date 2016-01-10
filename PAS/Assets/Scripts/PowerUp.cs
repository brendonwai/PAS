using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {

    public enum Types { ScoreIncrease, TimeIncrease, LifeIncrease, NULL };

    static public string toString(Types type)
    {
        if (type == Types.LifeIncrease) return "LifeIncrease";
        else if (type == Types.ScoreIncrease) return "ScoreIncrease";
        else if (type == Types.TimeIncrease) return "TimeIncrease";
        else return "ERROR";
    }

    static public Types getRandomPowerUp()
    {
        int ranNum = Random.Range(0, 3);

        switch (ranNum)
        {
            case 0:
                return Types.TimeIncrease;
            case 1:
                return Types.ScoreIncrease;
            case 2:
                return Types.LifeIncrease;
            default:
                return Types.NULL;
        }
    }
}
