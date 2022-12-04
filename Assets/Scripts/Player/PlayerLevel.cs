using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevel : MonoBehaviour
{
    [SerializeField] private LevelTableList levelTableList;

    [SerializeField] private GameObject _LvUpEffect;

    [SerializeField] private int _currentLv; // Test public
    [SerializeField] private int _currentExp; // Same 

    private float timer;

    private void Update()
    {
        // For exp test.
        if (Input.GetKeyDown(KeyCode.T))
        {
            AddExp(1);
        }
    }

    public void AddExp(int exp)
    {
        _currentExp += exp;

        if (CheckLevelUp(_currentLv, _currentExp))
        {
            LevelUp();
        }
    }

    bool CheckLevelUp(int currentLv, float currentExp)
    {
        return (currentExp >= levelTableList.levelTables[currentLv].requiredExp) ? true : false;
    }

    void LevelUp()
    {
        while (_currentExp >= levelTableList.levelTables[_currentLv].requiredExp)
        {
            levelTableList.levelTables[_currentLv].upgrade.Upgrade(this.gameObject);

            _currentExp -= levelTableList.levelTables[_currentLv].requiredExp;
            _currentLv++;

            Instantiate(_LvUpEffect, transform.position, Quaternion.identity);
        }
    }
}
