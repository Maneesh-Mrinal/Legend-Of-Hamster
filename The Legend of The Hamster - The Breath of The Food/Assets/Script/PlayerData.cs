using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public bool isFirstTime;
    public int playHealth;
    public int seedCount;
    public bool isGunEnabled;
    public bool isGunCollected;
    public PlayerData(PlayerMovement player)
    {
        playHealth = player.playerHealth;
        seedCount = player.collectedSeedCount;
        isGunEnabled= player.isGunEnabled;
        isGunCollected = player.isGunCollected;
    }
}
