using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snack : MonoBehaviour //this should inherit from the object class right?
{
    
    // check if there's a static eating time for all snacks, maybe it can scale with pointValue

    public int pointValue;

    // points:
    //  the number of points a snack is worth
    public void setPointValue(int points)
    {
        pointValue = points;
    }

    public int getPointValue()
    {
        return pointValue;
    }


}