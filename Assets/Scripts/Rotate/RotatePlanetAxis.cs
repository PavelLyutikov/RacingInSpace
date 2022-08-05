using UnityEngine;

public class RotatePlanetAxis : MonoBehaviour
{
    
    void Update()
    {
        transform.Rotate(new Vector3(0f, 1.1f, 0f));
    }
}
