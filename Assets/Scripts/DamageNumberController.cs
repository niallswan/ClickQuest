using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumberController : MonoBehaviour
{
    public static DamageNumberController instance;

    private void Awake()
    {
        instance = this;
    }

    public DamageNumber numberToSpawn;
    public Transform numberCanvas;
    

    private List<DamageNumber> numberPool = new List<DamageNumber>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SpawnDamage(int damageAmount)
    {
        DamageNumber newDamage = GetFromPool();
        newDamage.Setup(damageAmount);
        newDamage.gameObject.SetActive(true);

        newDamage.transform.position = new Vector3(Random.Range(0f, 2.5f), Random.Range(-1f, 1f), 0f);
    }

    public DamageNumber GetFromPool()
    {
        DamageNumber numberToOutput = null;

        if(numberPool.Count == 0){
            numberToOutput = Instantiate(numberToSpawn, numberCanvas);
        }else{
            numberToOutput = numberPool[0];
            numberPool.RemoveAt(0);
        }

        return numberToOutput;
    }

    public void PlaceInPool(DamageNumber numberToPlace)
    {
        numberToPlace.gameObject.SetActive(false);
        numberPool.Add(numberToPlace);
    }
}