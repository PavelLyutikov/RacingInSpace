using UnityEngine;

public class RotateAsteroids : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(new Vector3(0f, 0f, -0.05f));
    }
}
