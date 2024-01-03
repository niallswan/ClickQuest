using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifetime;
    private float lifeCounter;

    public Rigidbody2D RB;

    // Update is called once per frame
    void Update()
    {
        if(lifeCounter > 0){
            lifeCounter -= Time.deltaTime;

            if(lifeCounter <= 0){
                CoinController.instance.PlaceInPool(this);
            }
        }
    }

    public void Setup()
    {
        lifeCounter = lifetime;
    }
}
