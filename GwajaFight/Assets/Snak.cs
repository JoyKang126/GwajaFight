using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snack : MonoBehaviour //this should inherit from the object class right?
{
    // each snack has a point value
    // maybe we can consider giving some snacks special properties? (if we have time)
    // ie: eating wasabi peas only gives 1 point but it could speed you up? or maybe a snack
    // could be worth like zero points but it makes you eat things faster or smth
    
    // check if there's a static eating time for all snacks, maybe it can scale with pointValue

    public int pointValue;

    // points:
    //  the number of points a snack is worth
    public void setPointValue(int points)
    {
        pointValue = points;
    }

    // I don't think we need a getPointValue function


    // I assume the character class will handle any picking up/dropping/eating
    // so for example, for eating in the character class, it would check to see if
    // the snack has been successfully eaten before calling like
    // playerPoints += object.pointValue; or smth like that

    // NOTE:
    // I thought about an Update() function for the snacks, but couldn't really think 
    // of anything that it would do that wouldn't be covered by the character class already


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
        setPointValue(2); // subject to change
    }
}

public class yakult : Snack
{
    void Start()
    {
        setPointValue(2); // subject to change
    }
}

public class pocky : Snack
{
    void Start()
    {
        setPointValue(2); // subject to change
    }
}

public class shrimpChips : Snack
{
    void Start()
    {
        setPointValue(2); // subject to change
    }
}