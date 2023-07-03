using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Stones
{
    public class StoneValue : MonoBehaviour
    {
        public GameObject scorePrefab;
        public GameProgress gameProgress;
        [SerializeField] int maxRange = 5;

        [SerializeField] float annihilateTime = 3.0f; //seconds

        bool isAnnihilating = false;
        float annihilateTimer = 0;

        public int Value { get; private set; }

        void Start()
        {
            Value = Random.Range(1, maxRange + 1);
        }

        void Update()
        {
            if (isAnnihilating)
            {
                annihilateTimer += Time.deltaTime;
                if (annihilateTimer >= annihilateTime) DestoyStone();
            }
        }

        public void InitiateAnnihilation()
        {
            isAnnihilating = true;
        }

        void DestoyStone()
        {
            if (scorePrefab)
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
                GameObject scoreLabel = Instantiate(scorePrefab, screenPos, Quaternion.identity);
                scoreLabel.transform.SetParent(transform.parent.GetComponent<SquareFigure>().GetLevelUIObject().transform);
                scoreLabel.GetComponent<TextMeshProUGUI>().SetText(Value.ToString());
            }

            if (gameProgress)
            {
                gameProgress.AddMoney(Value);
                gameProgress.IncreaseRecycledCubes(1);
            }

            Destroy(gameObject);
        }
    }

}