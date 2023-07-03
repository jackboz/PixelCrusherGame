using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUISwitcher : MonoBehaviour
{
    [SerializeField] GameObject startMenuPanel;
    [SerializeField] GameObject levelPanel;

    public enum LevelUIState
    {
        Start,
        Level
    }

    public static LevelUIState levelUIState;

    public void SwitchToLevel()
    {
        levelUIState = LevelUIState.Level;
        SwitchUI();
    }

    public void SwitchToStartMenu()
    {
        levelUIState = LevelUIState.Start;
        SwitchUI();
    }

    void SwitchUI()
    {
        switch (levelUIState)
        {
            case LevelUIState.Start:
                startMenuPanel.SetActive(true);
                levelPanel.SetActive(false);
                break;
            case LevelUIState.Level:
                startMenuPanel.SetActive(false);
                levelPanel.SetActive(true);
                break;
        }
    }
}
