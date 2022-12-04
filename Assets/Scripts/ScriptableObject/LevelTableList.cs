using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelTableList : ScriptableObject
{
    public List<LevelTable> levelTables;
}

[System.Serializable]
public class LevelTable
{
    public int requiredExp;
    public Upgrade_Base upgrade;
}