using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player1State : playerStateHandler
{
    public override void setKeys()
    {
        keyPunch = KeyCode.S;
        keyRotFwrd = KeyCode.D;
        keyRotBack = KeyCode.A;
    }
}
