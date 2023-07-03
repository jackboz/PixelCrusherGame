using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crusher : MonoBehaviour
{
    [SerializeField] float rotatingSpeed = 0.5f;
    [SerializeField] float maxSize = 14.0f;
    [SerializeField] int maxLevel = 4;

    float initialSize = 7.0f;
    List<float> levelSizes = new List<float>();

    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotatingSpeed * Time.deltaTime));
    }

    public void IncreaseSize(int level)
    {
        if ((level < 1) || (level > maxLevel)) return;

        Vector3 newScale = transform.localScale;
        newScale.x = levelSizes[level - 1];
        newScale.y = levelSizes[level - 1];
        Debug.Log("size " + newScale);
        transform.localScale = newScale;
    }

    public void SetMaxLevel(int level)
    {
        maxLevel = level;
        Init();
    }

    void Init()
    {
        levelSizes.Clear();
        float step = (maxSize - initialSize) / (maxLevel - 1);
        float current = initialSize;
        for (int i = 0; i < maxLevel; i++)
        {
            levelSizes.Add(current);
            current += step;
        }
    }
}
