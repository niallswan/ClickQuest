using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public Enemy currentEnemy;
    public Transform canvas;

    public static EnemyManager instance;

    private GameObject enemyToSpawn;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CreateNewEnemy();
    }

    public void CreateNewEnemy()
    {
        var enchantRoll = Random.Range(1, 10);
        Debug.Log(enchantRoll);

        if(enchantRoll > 1){
            enemyToSpawn = enemyPrefabs[Random.Range(0, enemyPrefabs.Length-1)];
        }else{
            enemyToSpawn = enemyPrefabs[3];
        }

        GameObject obj = Instantiate(enemyToSpawn, canvas);

        currentEnemy = obj.GetComponent<Enemy>();
    }

    public void DefeatEnemy(GameObject enemy)
    {
        Destroy(enemy);
        CreateNewEnemy();
        GameManager.instance.StageCheck();
    }
}
