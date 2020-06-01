using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public KeyCode eat;
    private float myTime = 0.0F;
    private float eatTime = 1F;
    // Update is called once per frame
    void Update()
    {

        if (this.GetComponent<PlayerMovement>().getHold())
        {
            if (Input.GetKey(eat) && myTime < eatTime)
            {
                if (this.GetComponent<PlayerMovement>().getPush())
                {
                    print("interrupt");
                    myTime = 0.0F;
                }
                else
                {
                    this.GetComponent<PlayerMovement>().setFreeze(true);
                    myTime = myTime + Time.deltaTime;
                }

            }
            else if (Input.GetKey(eat) && myTime >= eatTime)
            {
                this.GetComponent<PlayerMovement>().setFreeze(false);
                this.GetComponent<PlayerMovement>().setHold(false);
                print("eat");
                myTime = 0.0F;
            }
            else
            {
                myTime = 0.0F;
            }
        }

    }


}
