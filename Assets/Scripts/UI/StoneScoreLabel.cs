using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneScoreLabel : MonoBehaviour
{
    [SerializeField] float floatingTime = 1.8f; //seconds
    [SerializeField] float floatingSpeed = 7f; //pixels per seconds

    float floatingTimer = 0;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.up * floatingSpeed * Time.deltaTime);
        floatingTimer += Time.deltaTime;
        if (floatingTimer >= floatingTime)
        {
            Destroy(gameObject);
        }
    }
}
