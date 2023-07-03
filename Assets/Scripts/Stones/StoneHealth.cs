using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stones
{
    public class StoneHealth : MonoBehaviour
    {
        [SerializeField] float health = 1.0f;

        Rigidbody rb;
        Transform childCollider;

        void Start()
        {
            rb = transform.GetComponent<Rigidbody>();
            childCollider = transform.Find("CrusherLimitCollider");
        }

        public void ReceiveDamage(float damage)
        {
            if ((damage < 0) || (health < 0)) return;

            health -= damage;

            if (health <= 0)
            {
                Debug.Log("Stone destroyed");
                if (rb)
                {
                    rb.isKinematic = false;
                    rb.useGravity = true;
                }
                if (transform.parent)
                {
                    transform.parent.GetComponent<SquareFigure>().PlayCrushingSound();
                }
                if (childCollider)
                {
                    childCollider.gameObject.SetActive(false);
                }
            }
        }
    }
}
