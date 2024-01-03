using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpDrop : MonoBehaviour
{
    public int expValue;

    public float moveSpeed;

    private GameObject weapon;

    public Rigidbody2D RB;

    private bool magnet = false;
    // Start is called before the first frame update
    void Start()
    {     
        weapon = GameObject.Find("Weapon");
    }

    // Update is called once per frame
    void Update()
    {
        if(magnet == true){
            transform.position = Vector3.MoveTowards(transform.position, weapon.transform.position, moveSpeed * Time.deltaTime);
        }else{
            RB.gravityScale = 1f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player" && magnet == true){
            ExpLevelController.instance.GetExp(expValue);
            ExpLevelController.instance.PlaceInPool(this);
            magnet = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.tag=="Player" && magnet == true){
            ExpLevelController.instance.GetExp(expValue);
            ExpLevelController.instance.PlaceInPool(this);
            magnet = false;
        }
    }
    public void InvokeMagnet()
    {
        Invoke("Magnet", 1f);
    }

    public void Magnet()
    {
        magnet = true;
        RB.velocity = Vector2.zero;
        RB.gravityScale = 0f;
    }
}
