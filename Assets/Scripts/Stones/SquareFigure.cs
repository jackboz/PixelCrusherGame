using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Stones
{
    public class SquareFigure : MonoBehaviour
    {
        [SerializeField] GameObject cube;
        [SerializeField] Vector2 leftBottom;
        [SerializeField] GameObject scorePrefab;
        [SerializeField] GameObject levelUI;
        [SerializeField] GameProgress gameProgress;
        [SerializeField] float angleRange = 10f; // degrees
        [SerializeField] float sizeAmplifier = 10f; // percent
        [SerializeField] int cubeNumbers = 35; // one side
        [SerializeField] SoundController soundController;
        [SerializeField] AudioClip crushingSound;

        float cubeLength;

        public int TotalCubes { get; private set; }

        void Awake()
        {
            if (cube == null)
            {
                Debug.LogWarning("Cube prefab is not set");
            }
            cubeLength = cube.transform.localScale.x;
            if (scorePrefab == null)
            {
                Debug.LogWarning("ScoreLabel prefab is not set");
            }
            if (levelUI == null)
            {
                Debug.LogWarning("Level UI panel is not set");
            }
            if (gameProgress == null)
            {
                Debug.LogWarning("Game Progress object is not set");
            }
            if (soundController == null)
            {
                Debug.LogWarning("Sound Controller is not set");
            }
            if (crushingSound == null)
            {
                Debug.LogWarning("Crushing sound is not set");
            }
            TotalCubes = cubeNumbers * cubeNumbers;
        }

        public void Fill()
        {
            foreach (Transform t in transform)
            {
                Destroy(t.gameObject);
            }
            GameObject child;
            for (int i = 0; i < cubeNumbers; i++)
                for (int j = 0; j < cubeNumbers; j++)
                {
                    child = Instantiate(cube, new Vector3(leftBottom.x + cubeLength * i, leftBottom.y + cubeLength * j, transform.position.z),
                        Quaternion.Euler(new Vector3(Random.Range(-angleRange, angleRange + 1), Random.Range(-angleRange, angleRange + 1), Random.Range(-angleRange, angleRange + 1)))
                        );
                    child.transform.localScale *= (100.0f + Random.Range(3, sizeAmplifier + 1)) / 100;
                    child.transform.parent = transform;
                    StoneValue stoneValue = child.transform.GetComponent<StoneValue>();
                    if (stoneValue)
                    {
                        stoneValue.gameProgress = gameProgress;
                        stoneValue.scorePrefab = scorePrefab;
                    }
                }
        }

        public GameObject GetLevelUIObject()
        {
            return levelUI;
        }

        public void PlayCrushingSound()
        {
            if ((soundController) && (crushingSound))
            {
                soundController.PlaySoundWithoutRepeat(crushingSound);
            }
        }
    }
}