using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class IncreaseLevel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI levelLabel;
    [SerializeField] TextMeshProUGUI maxLabel;

    void Start()
    {
        if (levelLabel == null)
        {
            Debug.LogError("Level Label is not set");
        }
        if (maxLabel == null)
        {
            Debug.LogError("Max Level Label is not set");
        }
        maxLabel.enabled = false;
    }

    public void SetPrice(int number)
    {
        if (number == -1)
        {
            levelLabel.enabled = false;
            maxLabel.enabled = true;
        }
        else
        {
            levelLabel.SetText("$" + number.ToString());
        }
    }
}
