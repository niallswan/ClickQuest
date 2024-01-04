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
    public int expToGive = 1;
    public int expToDrop;

    public bool enchanted;
    public Animator animator;

    private bool alive = true;

    public void Damage(bool input)
    {
        if(alive){
            if(input){
                GameManager.instance.SwingWeapon();
            }  
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
        if(enchanted){
            GameManager.instance.AddGold(goldToGive);
            EnemyManager.instance.DefeatEnemy(gameObject);
            for(int i = 0; i < goldToGive; i++){
                CoinController.instance.SpawnCoin();
            }
            for(int i = 0; i < expToDrop; i++){
                ExpLevelController.instance.SpawnExp(expToGive);
            }

        }else{
            GameManager.instance.AddGold(goldToGive);
            EnemyManager.instance.DefeatEnemy(gameObject);
            CoinController.instance.SpawnCoin();
            ExpLevelController.instance.SpawnExp(expToGive);
        }
    }
}
