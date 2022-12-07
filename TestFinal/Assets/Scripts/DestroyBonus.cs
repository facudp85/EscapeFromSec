using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBonus : MonoBehaviour
{

    float timeToKill = 9f;
    void Start()
    {
        Destroy(gameObject, timeToKill);

    }

    void Update()
    {

    }
}

