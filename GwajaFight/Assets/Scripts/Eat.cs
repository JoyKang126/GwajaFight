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

        if (GetComponent<PlayerMovement>().getHold())
        {
            if (Input.GetKeyUp(eat) && myTime < eatTime)
            {
                myTime = 0.0F;
                GetComponent<PlayerMovement>().setFreeze(false);
                GetComponent<PlayerPickupDrop>().returnSnack();
                GetComponent<PlayerMovement>().animator.SetBool("Eating", false);
            }
            else if (Input.GetKey(eat) && myTime < eatTime)
            {
                if (GetComponent<PlayerMovement>().getPush())
                {
                    print("interrupt");
                    GetComponent<PlayerPickupDrop>().returnSnack();
                    GetComponent<PlayerMovement>().animator.SetBool("Eating", false);
                    myTime = 0.0F;
                }
                else
                {
                    GetComponent<PlayerPickupDrop>().moveSnack();
                    GetComponent<PlayerMovement>().animator.SetBool("Eating", true);
                    GetComponent<PlayerMovement>().setFreeze(true);
                    myTime = myTime + Time.deltaTime;
                }

            }
            else if (Input.GetKey(eat) && myTime >= eatTime)
            {
                GetComponent<PlayerMovement>().setFreeze(false);
                GetComponent<PlayerMovement>().setHold(false);
                print("eat");
                GetComponent<PlayerPickupDrop>().eat();
                GetComponent<PlayerMovement>().animator.SetBool("Eating", false);
                myTime = 0.0F;
            }
            else
            {
                myTime = 0.0F;
            }
        }

    }

    
}
