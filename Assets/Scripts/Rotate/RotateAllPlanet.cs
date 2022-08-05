using UnityEngine;

public class RotateAllPlanet : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, 0.15f));
    }
}
