using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int gold;
    public TextMeshProUGUI goldText;

    public Sprite[] stages;
    private int currentStage;
    private int enemiesUntilStageChange;
    public Image stageImage;

    public static GameManager instance;

    void Awake()
    {
        instance = this;
        enemiesUntilStageChange = 5;
    }

    public void AddGold(int amount)
    {
        gold += amount;
        goldText.text = ": " + gold.ToString();
    }

    public void SpendGold(int amount)
    {
        gold -= amount;
        goldText.text = ": " + gold.ToString();        
    }

    public void StageCheck()
    {
        enemiesUntilStageChange--;

        if(enemiesUntilStageChange == 0){
            enemiesUntilStageChange = 5;
            currentStage++;

            if(currentStage == stages.Length){
                currentStage = 0;
            }

            stageImage.sprite = stages[currentStage];
        }
    }
}
