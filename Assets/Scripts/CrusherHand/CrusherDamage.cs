using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrusherDamage : MonoBehaviour
{
    [SerializeField] float power = 0.05f;

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "stone") return;
        Debug.Log("Damaging stone");
        Stones.StoneHealth stoneHealth = other.transform.GetComponent<Stones.StoneHealth>();
        if (stoneHealth)
        {
            Debug.Log("Damaging stone");
            stoneHealth.ReceiveDamage(power);
        }
    }
}
