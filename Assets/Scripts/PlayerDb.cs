using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDb
{
    public long dmgMade;

    public PlayerDb(long dmgMade)
    {
        this.dmgMade = dmgMade;
    }

    public PlayerDb()
    {
        dmgMade = 0;
    }
}