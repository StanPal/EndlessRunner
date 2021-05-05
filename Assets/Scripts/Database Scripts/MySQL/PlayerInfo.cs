using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class PlayerInfo
{
    public int playerID;
    public string playername;
    public int score;

}

[Serializable]
public class Player
{
    public PlayerInfo[] player;
}

