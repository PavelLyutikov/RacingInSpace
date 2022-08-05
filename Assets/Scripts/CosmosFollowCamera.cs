using UnityEngine;

public class CosmosFollowCamera : MonoBehaviour
{
    public Transform player;

    void Update()
    {

        transform.position = new Vector3(0f, 0f, player.transform.position.z);
    }
}
