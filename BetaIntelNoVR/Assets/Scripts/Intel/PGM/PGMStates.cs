using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PGMStates : MonoBehaviour
{

    public SerialHandlerPGM serialHandlerPGM;
    
    int currentState = 5;
    int previousState = 5;

    [HideInInspector]
    public string serialPGMString;

    // Update is called once per frame
    void Update()
    {

        currentState = Intel.sharedInstance.ExerciseState;


        if (currentState == 0 && currentState != previousState)
        {
            if (Intel.sharedInstance.resistanceMode == false)
            {
                serialHandlerPGM.Write("1");
                // serialPGMString = "1";
            }
            else
            {
                serialHandlerPGM.Write("0");
                //serialPGMString = "0";
            }
        }


        if (currentState == 2 && currentState != previousState)
        {
            if (Intel.sharedInstance.resistanceMode == false)
            {
                //serialPGMString = "0";
                serialHandlerPGM.Write("0");
            }
            else
            {
                serialHandlerPGM.Write("1");
                //serialPGMString = "1";
            }

        }

        previousState = currentState;


    }
}
