using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public bool isFirstTime;
    public int playHealth;
    public int seedCount;
    public bool isGunEnabled = false;
    public bool isGunCollected = false;
    public PlayerData(PlayerMovement player)
    {
        playHealth = player.playerHealth;
        seedCount = player.collectedSeedCount;
        isGunEnabled= player.isGunEnabled;
        isGunCollected = player.isGunCollected;
    }
}
