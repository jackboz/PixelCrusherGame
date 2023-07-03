using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // TODO: load level params via ScriptableObject
    public int LevelNumber { get; private set; }
    public UpgradeUIController UpgradeUIController { get; private set; }
    public LevelUIController LevelUIController { get; private set; }
    //TODO Delete
    public SoundController SoundController { get; private set; }

    [SerializeField] UpgradeUIController upgradeUIController;
    [SerializeField] LevelUIController levelUIController;
    [SerializeField] GameProgress gameProgress;
    [SerializeField] InputManager inputManager;
    [SerializeField] LevelUISwitcher levelUISwitcher;
    [SerializeField] CreateRods createRods;
    [SerializeField] Stones.SquareFigure squareFigure;
    [SerializeField] SoundController soundController;

    void Awake()
    {
        LevelNumber = 1;
        if (gameProgress == null)
        {
            Debug.LogError("Set Game Progress component");
            return;
        }
        if (upgradeUIController == null)
        {
            Debug.LogError("Set UpgradeUIController");
            return;
        }
        UpgradeUIController = upgradeUIController;
        if (levelUIController == null)
        {
            Debug.LogError("Set level ui controller");
            return;
        }
        LevelUIController = levelUIController;
        LevelUIController.SetLevel(LevelNumber);
        if (inputManager == null)
        {
            Debug.LogError("Set Input Manager");
            return;
        }
        if (levelUISwitcher == null)
        {
            Debug.LogError("Set LevelUISwitcher");
            return;
        }
        if (createRods == null)
        {
            Debug.LogError("Set CreateRods component");
            return;
        }
        if (squareFigure == null)
        {
            Debug.LogError("Set SquareFigure");
            return;
        }
        gameProgress.FirstInitialization();
        if (soundController == null)
        {
            Debug.LogWarning("Set Sound controller");
            return;
        }
        SoundController = soundController;
    }

    void Start()
    {
        LevelUIController.SwitchToStartMenu();
    }

    void Update()
    {
        if (gameProgress.LevelProgress > 0.97) SceneManager.LoadScene("EndLevelScene");
    }

    public void SwitchToLevel()
    {
        inputManager.IsOn = true;
    }

    public void SwitchToStartMenu()
    {
        inputManager.IsOn = false;
        createRods.CreateRodsInit();
        squareFigure.Fill();
        gameProgress.ResetLevelProgress();
        if (SoundController) SoundController.Reset();
    }
}
