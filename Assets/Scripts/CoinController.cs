using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    public static CoinController instance;

    private void Awake()
    {
        instance = this;
    }

    public Coin coinToSpawn;

    private Rigidbody2D RB;
    

    private List<Coin> coinPool = new List<Coin>();

    public void SpawnCoin()
    {
        Coin newCoin = GetFromPool();
        newCoin.Setup();
        newCoin.gameObject.SetActive(true);
        RB = newCoin.GetComponent<Rigidbody2D>();

        newCoin.transform.position = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        newCoin.transform.localScale = new Vector3(1,1,1);
        RB.velocity = new Vector2(Random.Range(-5f, 5f), 5f);
    }

    public Coin GetFromPool()
    {
        Coin coinToOutput = null;

        if(coinPool.Count == 0){
            coinToOutput = Instantiate(coinToSpawn, Vector3.zero, Quaternion.identity);
        }else{
            coinToOutput = coinPool[0];
            coinPool.RemoveAt(0);
        }

        return coinToOutput;
    }

    public void PlaceInPool(Coin coinToPlace)
    {
        coinToPlace.gameObject.SetActive(false);
        coinPool.Add(coinToPlace);
    }
}
