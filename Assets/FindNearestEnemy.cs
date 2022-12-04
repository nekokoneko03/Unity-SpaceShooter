using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindNearestEnemy : MonoBehaviour
{
    public static FindNearestEnemy instance;

    #region singleton
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
            return;
        }
    }
    #endregion

    public GameObject GetNearestEnemy(Vector3 target)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        float nearestDist = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float dist = Vector3.Distance(target, enemy.transform.position);
            if (dist <= nearestDist)
            {
                nearestDist = dist;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            return nearestEnemy;
        }
        else
        {
            Debug.Log("There is no game object with enemy tag");
            return null;
        }
    }
}
