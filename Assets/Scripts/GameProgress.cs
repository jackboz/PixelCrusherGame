using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameManager))]
public class GameProgress : MonoBehaviour
{
    // TODO set max for HandLevel and ConveyorLevel
    public int Money { get; private set; }
    public int HandLevel { get; private set; }
    public int ConveyorLevel { get; private set; }
    public int CrusherSizeLevel { get; private set; }
    public int RecycledCubesNumber { get; private set; }
    public float LevelProgress { get { return (float)RecycledCubesNumber / figure.TotalCubes; } }

    public int MaxHandLevel { get; private set; } = 4;
    public int MaxCrusherSizeLevel { get; private set; } = 4;
    public int MaxConveyorLevel { get; private set; } = 4;

    public enum Purchasable
    {
        HandSize,
        CrusherSize,
        ConveyorSize
    }

    [SerializeField] CreateRods hand;
    [SerializeField] Stones.Conveyor conveyor;
    [SerializeField] Stones.SquareFigure figure;

    LevelUIController levelUIController;
    UpgradeUIController upgradeUIController;
    Crusher crusher;

    Dictionary<Purchasable, List<int>> prices = new Dictionary<Purchasable, List<int>>();

    void Start()
    {
        crusher = FindObjectOfType<Crusher>();
        if (crusher == null)
        {
            Debug.LogError("Game object with Crusher component not found");
        }
        crusher.SetMaxLevel(MaxCrusherSizeLevel);
        if (conveyor == null)
        {
            Debug.LogError("Set Conveyor component");
            return;
        }
        conveyor.SetMaxLevel(MaxConveyorLevel);
        if (hand == null)
        {
            Debug.LogError("Set Hand component");
            return;
        }
        hand.SetMaxLevel(MaxHandLevel);
        if (figure == null)
        {
            Debug.LogError("Figure is not set");
        }
    }

    public void FirstInitialization()
    {
        Money = 0;
        HandLevel = 1;
        ConveyorLevel = 1;
        CrusherSizeLevel = 1;
        RecycledCubesNumber = 0;
        levelUIController = GetComponent<GameManager>().LevelUIController;
        upgradeUIController = GetComponent<GameManager>().UpgradeUIController;

        prices.Add(Purchasable.HandSize, new List<int>() { 30, 150, 500 });
        prices.Add(Purchasable.CrusherSize, new List<int>() { 60, 300, 1000 });
        prices.Add(Purchasable.ConveyorSize, new List<int>() { 100, 600, 2000 });
    }

    public void AddMoney(int money)
    {
        Money += money;
        levelUIController.SetMoney(Money);
        Debug.Log("Earned " + money.ToString());
    }

    public void IncreaseHandLevel()
    {
        if (HandLevel == MaxHandLevel) return;

        if (Money < prices[Purchasable.HandSize][HandLevel - 1]) return;

        AddMoney(-prices[Purchasable.HandSize][HandLevel - 1]);
        HandLevel += 1;
        hand.ResizeHand(HandLevel);
    }

    public void IncreaseConveyorLevel()
    {
        if (ConveyorLevel == MaxConveyorLevel) return;

        if (Money < prices[Purchasable.ConveyorSize][ConveyorLevel - 1]) return;

        AddMoney(-prices[Purchasable.ConveyorSize][ConveyorLevel - 1]);
        ConveyorLevel += 1;
        conveyor.ResizeConveyor(ConveyorLevel);
    }

    public void IncreaseCrusherLevel()
    {
        if (CrusherSizeLevel == MaxCrusherSizeLevel) return;

        if (Money < prices[Purchasable.CrusherSize][CrusherSizeLevel - 1]) return;

        AddMoney(-prices[Purchasable.CrusherSize][CrusherSizeLevel - 1]);
        CrusherSizeLevel += 1;
        crusher.IncreaseSize(CrusherSizeLevel);
    }

    public void IncreaseRecycledCubes(int number)
    {
        RecycledCubesNumber += number;
        levelUIController.SetProgress(LevelProgress);
    }

    public int GetPrice(Purchasable purchasable)
    {
        int res = -1;
        switch (purchasable)
        {
            case Purchasable.HandSize:
                if (HandLevel < MaxHandLevel) res = prices[purchasable][HandLevel - 1];
                break;
            case Purchasable.CrusherSize:
                if (CrusherSizeLevel < MaxCrusherSizeLevel) res = prices[purchasable][CrusherSizeLevel - 1];
                break;
            case Purchasable.ConveyorSize:
                if (ConveyorLevel < MaxConveyorLevel) res = prices[purchasable][ConveyorLevel - 1];
                break;
        }
        return res;
    }

    public void ResetLevelProgress()
    {
        RecycledCubesNumber = 0;
        levelUIController.SetProgress(LevelProgress);
    }
}
