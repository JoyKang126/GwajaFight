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

public class wasabiPeas : Snack
{
    void Start()
    {
        setPointValue(1);
    }
}

public class whaleChips: Snack
{
    void Start()
    {
        setPointValue(2); // subject to change
    }
}

public class lycheeJelly : Snack
{
    void Start()
    {
        setPointValue(3); // subject to change
    }
}

public class yakult : Snack
{
    void Start()
    {
        setPointValue(4); // subject to change
    }
}

public class pocky : Snack
{
    void Start()
    {
        setPointValue(5); // subject to change
    }
}

public class shrimpChips : Snack
{
    void Start()
    {
        setPointValue(6); // subject to change
    }
}