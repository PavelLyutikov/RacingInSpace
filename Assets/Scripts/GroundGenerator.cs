using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour
{

    public GameObject[] groundPrefabs;
    private List<GameObject> activeGround = new List<GameObject>();
    private float spawnPosition = 0;
    private float groundLength = 100;
    [SerializeField] private Score scoreScript;

    [SerializeField] private Transform player;
    private int startGrounds = 6;

    void Start()
    {
        int checkScore = int.Parse(scoreScript.scoreText.text.ToString());

        for (int i = 0; i < startGrounds; i++)
        {
            if (i == 0)
            {
                SpawnGround(0);
            }


            if (checkScore > 100)
            {
                SpawnGround(Random.Range(6, 20));
            }
            else if (checkScore > 60)
            {
                SpawnGround(Random.Range(6, 17));
            }
            else if (checkScore > 30)
            {
                SpawnGround(Random.Range(4, 15));
            }
            else
            {
                SpawnGround(Random.Range(0, 9));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        int checkScore = int.Parse(scoreScript.scoreText.text.ToString());


        if (player.position.z - 60 > spawnPosition - (startGrounds * groundLength))
        {

            if (checkScore > 100)
            {
                SpawnGround(Random.Range(6, 20));
                DeleteGround();
            }
            else if (checkScore > 60)
            {
                SpawnGround(Random.Range(6, 17));
                DeleteGround();
            }
            else if (checkScore > 30)
            {
                SpawnGround(Random.Range(4, 15));
                DeleteGround();
            }
            else
            {
                SpawnGround(Random.Range(0, 9));
                DeleteGround();
            }
        }
    }

    private void SpawnGround(int groundIndex)
    {
        GameObject nextGround = Instantiate(groundPrefabs[groundIndex], transform.forward * spawnPosition, transform.rotation);
        activeGround.Add(nextGround);
        spawnPosition += groundLength;
    }
    private void DeleteGround()
    {
        Destroy(activeGround[0]);
        activeGround.RemoveAt(0);
    }
}