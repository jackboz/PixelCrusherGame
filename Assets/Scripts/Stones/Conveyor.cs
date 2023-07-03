using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stones
{
    public class Conveyor : MonoBehaviour
    {
        [SerializeField] float velocity = 10f;
        [SerializeField] float maxLength = 8f;
        int maxLevel = 4;
        float initialSize = 1.5f;
        List<float> levelSizes = new List<float>();
        Transform scalingPoint;

        void Awake()
        {
            scalingPoint = transform.parent;
            if (scalingPoint == null)
            {
                Debug.LogError("Conveyor game object should have a parent game object for proper scaling");
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.tag != "stone") return;
            Rigidbody rb = other.GetComponent<Rigidbody>();
            if (rb)
            {
                Vector3 v = rb.velocity;
                v.x = -velocity;
                rb.velocity = v;
            }
        }

        public void ResizeConveyor(int level)
        {
            if ((level < 1) || (level > maxLevel)) return;

            Vector3 newScale = scalingPoint.localScale;
            newScale.x = levelSizes[level - 1];
            scalingPoint.localScale = newScale;
        }

        public void SetMaxLevel(int level)
        {
            maxLevel = level;
            Init();
        }

        void Init()
        {
            levelSizes.Clear();
            float step = (maxLength - initialSize) / (maxLevel - 1);
            float current = initialSize;
            for (int i = 0; i < maxLevel; i++)
            {
                levelSizes.Add(current);
                current += step;
            }
        }
    }
}