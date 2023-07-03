using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class ProgressBar : MonoBehaviour
{
    [SerializeField] float initialValue = 0;
    Slider slider;

    void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        slider.value = initialValue;
    }

    public void SetProgress(float newProgress)
    {
        slider.value = Mathf.Clamp01(newProgress);
    }
}
