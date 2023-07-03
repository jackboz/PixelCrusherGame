using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeUIController : MonoBehaviour
{
    [SerializeField] GameProgress gameProgress;
    [SerializeField] IncreaseLevel handLevel;
    [SerializeField] IncreaseLevel conveyorLevel;
    [SerializeField] IncreaseLevel crusherLevel;

    void Start()
    {
        if (gameProgress == null)
        {
            Debug.LogError("Set GameProgress component");
            return;
        }
        if (handLevel == null)
        {
            Debug.LogError("Set IncreaseLevel component for Hand");
            return;
        }
        handLevel.SetPrice(gameProgress.GetPrice(GameProgress.Purchasable.HandSize));
        if (conveyorLevel == null)
        {
            Debug.LogError("Set IncreaseLevel component for Conveyor");
            return;
        }
        conveyorLevel.SetPrice(gameProgress.GetPrice(GameProgress.Purchasable.ConveyorSize));
        if (crusherLevel == null)
        {
            Debug.LogError("Set IncreaseLevel component for Crusher");
            return;
        }
        crusherLevel.SetPrice(gameProgress.GetPrice(GameProgress.Purchasable.CrusherSize));
    }

    public void IncreaseHandLevel()
    {
        gameProgress.IncreaseHandLevel();
        handLevel.SetPrice(gameProgress.GetPrice(GameProgress.Purchasable.HandSize));
    }

    public void IncreaseConveyorLevel()
    {
        gameProgress.IncreaseConveyorLevel();
        conveyorLevel.SetPrice(gameProgress.GetPrice(GameProgress.Purchasable.ConveyorSize));
    }

    public void IncreaseCrusherLevel()
    {
        gameProgress.IncreaseCrusherLevel();
        crusherLevel.SetPrice(gameProgress.GetPrice(GameProgress.Purchasable.CrusherSize));
    }
}
