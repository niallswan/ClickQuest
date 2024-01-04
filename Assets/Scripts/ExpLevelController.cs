using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpLevelController : MonoBehaviour
{
    public static ExpLevelController instance;
    private void Awake()
    {
        instance = this;
    }

    public int currentExperience;

    public ExpDrop expDropToSpawn;
    private List<ExpDrop> expDropPool = new List<ExpDrop>();

    public List<int> expLevels;
    public int currentLevel = 1, levelCount = 100;

    private Rigidbody2D RB;

    // Start is called before the first frame update
    void Start()
    {
        while(expLevels.Count < levelCount){
            expLevels.Add(Mathf.CeilToInt(expLevels[expLevels.Count - 1] * 1.1f));
        }
    }

    public void GetExp(int amountToGet)
    {
        currentExperience += amountToGet;

        if(currentExperience >= expLevels[currentLevel]){
            LevelUp();
        }

        UIController.instance.UpdateExperience(currentExperience, expLevels[currentLevel], currentLevel);
    }

    public void SpawnExp(int expValue)
    {
        ExpDrop newExp = GetFromPool();
        newExp.gameObject.SetActive(true);
        //ExpDrop exp = Instantiate(drop, position, Quaternion.identity);
        newExp.expValue = expValue;
        newExp.InvokeMagnet();
        RB = newExp.GetComponent<Rigidbody2D>();
        newExp.transform.position = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f);
        RB.velocity = new Vector2(Random.Range(-4f, 4f), 5f);
    }

    void LevelUp()
    {
        //Reduce current EXP by amount required to level up
        currentExperience -= expLevels[currentLevel];
        //Level up
        currentLevel++;

        //If maxed out stay at max level
        if(currentLevel >= expLevels.Count){
            currentLevel = expLevels.Count -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public ExpDrop GetFromPool()
    {
        ExpDrop expDropToOutput = null;

        if(expDropPool.Count == 0){
            expDropToOutput = Instantiate(expDropToSpawn, Vector3.zero, Quaternion.identity);
        }else{
            expDropToOutput = expDropPool[0];
            expDropPool.RemoveAt(0);
        }

        return expDropToOutput;
    }

    public void PlaceInPool(ExpDrop expDropToPlace)
    {
        expDropToPlace.gameObject.SetActive(false);
        expDropPool.Add(expDropToPlace);
    }
}
