using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stones
{
    public class StoneRecycler : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag != "stone") return;
            Debug.Log("Stone start recycling");
            StoneValue stoneValue = other.transform.GetComponent<StoneValue>();
            if (stoneValue)
            {
                stoneValue.InitiateAnnihilation();
            }
        }
    }
}