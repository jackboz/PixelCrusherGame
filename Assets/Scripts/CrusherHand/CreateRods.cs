using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateRods : MonoBehaviour
{
    [SerializeField] int handLevel = 1;
    [SerializeField] float rodLength = 2.0f;
    [SerializeField] float yLevelSize = 1.0f;
    [SerializeField] GameObject rodPrefab;
    [SerializeField] GameObject endJoint;
    [SerializeField] GameProgress gameProgress;

    int maxLevel = 4;

    List<float> angles = new List<float>();
    List<GameObject> rods = new List<GameObject>();

    void Awake()
    {
        if (endJoint == null)
        {
            Debug.LogError("Set EndJoint game object");
        }
    }

    public void CreateRodsInit()
    {
        if (gameProgress == null)
        {
            Debug.LogWarning("Game Progress component is not set");
        }
        else
        {
            handLevel = gameProgress.HandLevel;
        }
        BuildHand();
    }
    public void BuildHand()
    {
        angles.Clear();
        DestroyRods();
        endJoint.GetComponent<HingeJoint>().connectedBody = null;
        // Calculating angles
        if (handLevel == 1)
        {
            angles.Add(0);
            angles.Add(0);
        }
        else
        {
            float angle = Mathf.Acos(yLevelSize / 2 / rodLength);
            for (int i = 0; i < handLevel; i++)
            {
                angles.Add(angle * 180 / Mathf.PI);
                angles.Add(-angle * 180 / Mathf.PI);
            }
        }

        GameObject rod;
        Rigidbody connectedRb = null;
        Transform rodStartPoint;

        Vector3 pos = transform.position;
        for (int i = 0; i < angles.Count; i++)
        {
            rod = Instantiate(rodPrefab, pos, Quaternion.Euler(new Vector3(0, 0, angles[i])), transform);
            rodStartPoint = rod.transform.Find("RodStartPoint");
            rodStartPoint.GetComponent<RodLength>().SetRodLength(rodLength);
            rodStartPoint.GetComponent<HingeJoint>().connectedBody = connectedRb;
            connectedRb = rodStartPoint.GetComponent<Rigidbody>();
            rod.transform.Find("Joint").transform.parent = rodStartPoint;
            pos = rodStartPoint.Find("RodEndPoint").transform.position;
            rods.Add(rod);
        }
        endJoint.GetComponent<Rigidbody>().isKinematic = true;
        endJoint.transform.position = pos;
        endJoint.transform.rotation = Quaternion.Euler(90, 0, 0);
        endJoint.GetComponent<Rigidbody>().isKinematic = false;
        endJoint.GetComponentInChildren<HingeJoint>().connectedBody = connectedRb;
    }

    public void ResizeHand(int level)
    {
        if ((level < 1) || (level > maxLevel)) return;

        handLevel = level;
        BuildHand();
    }

    void DestroyRods()
    {
        foreach (GameObject rod in rods)
        {
            Destroy(rod);
        }
        rods.Clear();
    }

    public void SetMaxLevel(int level)
    {
        maxLevel = level;
    }
}
