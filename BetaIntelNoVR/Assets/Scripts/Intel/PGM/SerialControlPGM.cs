using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SerialControlPGM : MonoBehaviour {

    public SerialHandlerPGM serialHandlerPGM;
    public PGMStates pgmState;
    string pgmCurrentSerial = "5";
    string pgmLastSerial;

    void Updata()
    {
        pgmCurrentSerial = pgmState.serialPGMString;

        if (pgmCurrentSerial != pgmLastSerial)
        {
            serialHandlerPGM.Write(pgmCurrentSerial);
        }

        pgmLastSerial = pgmCurrentSerial;
    }
}
