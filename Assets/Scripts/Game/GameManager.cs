using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public List<GameObject> enemyList;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        GameObject[] enemyArr = GameObject.FindGameObjectsWithTag("Enemy");
        enemyList = new List<GameObject>(enemyArr);
    }

    public void DestroyEnemy(GameObject enemy)
    {
        if (enemyList.Count > 0)
        {
            enemyList.Remove(enemy);
            if(enemyList.Count == 0)
            {
                UIManager.instance.OpenFinishPanel();
            }
        }
    }

}
