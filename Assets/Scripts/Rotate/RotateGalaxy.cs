using UnityEngine;

public class RotateGalaxy : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(0f, -0.1f, 0f));
    }
}
