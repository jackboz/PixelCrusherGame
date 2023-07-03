using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(LevelUISwitcher))]
public class LevelUIController : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] TextMeshProUGUI levelLabel;
    [SerializeField] TextMeshProUGUI moneyLabel;
    [SerializeField] ProgressBar progressBar;

    void Start()
    {
        if (levelLabel == null)
        {
            Debug.LogError("Set level label");
            return;
        }
        if (moneyLabel == null)
        {
            Debug.LogError("Set money label");
            return;
        }
        if (gameManager == null)
        {
            Debug.LogError("Set Game Manager");
            return;
        }
        if (progressBar == null)
        {
            Debug.LogError("Set Progress Bar");
            return;
        }
    }

    public void SetLevel(int number)
    {
        levelLabel.SetText("Level " + number.ToString());
    }

    public void SetMoney(int number)
    {
        moneyLabel.SetText("$" + number.ToString());
    }

    public void SetProgress(float number)
    {
        progressBar.SetProgress(number);
    }

    public void SwitchToStartMenu()
    {
        GetComponent<LevelUISwitcher>().SwitchToStartMenu();
        gameManager.SwitchToStartMenu();
    }

    public void SwitchToLevelMenu()
    {
        GetComponent<LevelUISwitcher>().SwitchToLevel();
        gameManager.SwitchToLevel();
    }
}
