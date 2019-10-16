using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2State : playerStateHandler
{
    public override void setKeys()
    {
        keyPunch = KeyCode.K;
        keyRotFwrd = KeyCode.J;
        keyRotBack = KeyCode.L;
    }
}