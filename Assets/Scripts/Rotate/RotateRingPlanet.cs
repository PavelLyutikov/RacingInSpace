using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateRingPlanet : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(0.2f, 0.8f, 0f));
    }
}
