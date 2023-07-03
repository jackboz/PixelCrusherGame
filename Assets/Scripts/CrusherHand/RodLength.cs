using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodLength : MonoBehaviour
{
    // Start is called before the first frame update
    public void SetRodLength(float length)
    {
        Vector3 newScale = transform.localScale;
        newScale.y = length;
        transform.localScale = newScale;
    }
}
