using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int gold;
    public TextMeshProUGUI goldText;

    public TextMeshProUGUI zoneStageText;
    public TextMeshProUGUI killsToNextStageText;

    public Sprite[] zones;
    private int currentStage;
    private int currentZone;
    private int enemiesUntilStageChange;

    private int stagesUntilZoneChange;
    public Image zoneImage;
    public Animator weaponAnimator;

    public static GameManager instance;

    void Awake()
    {
        instance = this;
        enemiesUntilStageChange = 10;
        stagesUntilZoneChange = 10;
        currentStage = 1;
        currentZone = 0;
        killsToNextStageText.text = "0/10";
        zoneStageText.text = "Zone: " + (currentZone + 1).ToString() + ", Stage: " + currentStage.ToString();
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

    public void SwingWeapon()
    {
        weaponAnimator.SetTrigger("Swing");
    }

    public void StageCheck()
    {
        enemiesUntilStageChange--;
        var remaining = enemiesUntilStageChange - 10;

        killsToNextStageText.text = (-remaining).ToString() + "/10";
        zoneStageText.text = "Zone: " + (currentZone + 1).ToString() + ", Stage: " + currentStage.ToString();

        if(enemiesUntilStageChange == 0){
            enemiesUntilStageChange = 10;
            currentStage++;

            if(currentStage > 10){
                currentStage = 1;
                currentZone++;
            }

            zoneImage.sprite = zones[currentZone];
            killsToNextStageText.text = "0/10";
            zoneStageText.text = "Zone: " + (currentZone + 1).ToString() + ", Stage: " + currentStage.ToString();
        }

        
    }
}
