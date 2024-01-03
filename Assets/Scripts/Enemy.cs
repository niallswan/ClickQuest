using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Image healthBarFill;
    public int currentHP;
    public int maxHP;
    public int goldToGive;
    public Animator animator;

    private bool alive = true;

    public void Damage()
    {
        if(alive){
            animator.SetTrigger("Damaged");
            currentHP--;
            healthBarFill.fillAmount = (float)currentHP / (float)maxHP;

            DamageNumberController.instance.SpawnDamage(1);

            if(currentHP <= 0){   
                animator.SetBool("IsDead", true);           
                Invoke("Defeated", 0.5f);
                alive = false;
            }
        }       
    }

    public void Defeated()
    {
        GameManager.instance.AddGold(goldToGive);
        EnemyManager.instance.DefeatEnemy(gameObject);
        CoinController.instance.SpawnCoin();
    }
}
