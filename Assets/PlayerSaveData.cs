using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSaveData
{
    // Start is called before the first frame update
    public int level;
    public string date;

    public PlayerSaveData(int dataLevel, string dataName)
    {
        level = dataLevel;
        date = dataName;
    }
}
