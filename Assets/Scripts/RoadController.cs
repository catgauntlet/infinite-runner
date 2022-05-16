using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadController : MonoBehaviour
{
    public GameObject roadPrefab;

    public Vector3 lastBlockPosition;
    public float moveOffset;

    public GameObject startingRoadBlock;

    public bool buildingRoad = false;
    private int roadCount = 0;

    public void StartBuildingRoad()
    {
        if (!buildingRoad)
        {
            buildingRoad = true;
            InvokeRepeating("CreateNewRoadPart", 0.5f, 0.5f);
        }

    }

    void Start()
    {
        startingRoadBlock = GameObject.Find("Roadpart (18)");
        lastBlockPosition = startingRoadBlock.transform.position;
        moveOffset = startingRoadBlock.GetComponent<Collider>().bounds.size.x /2;
    }

    public void CreateNewRoadPart()
    {
        Vector3 spawnPosition = Vector3.zero;

        float chance = Random.Range(0, 100);

        if (chance < 50)
        {
            spawnPosition = new Vector3(lastBlockPosition.x + moveOffset, lastBlockPosition.y, lastBlockPosition.z + moveOffset);
        } else
        {
            spawnPosition = new Vector3(lastBlockPosition.x - moveOffset, lastBlockPosition.y, lastBlockPosition.z + moveOffset);
        }

        GameObject newRoadPart = Instantiate(roadPrefab, spawnPosition, Quaternion.Euler(0, 45, 0));

        lastBlockPosition = newRoadPart.transform.position;

        roadCount++;

        if (roadCount % 5 == 0)
        {
            newRoadPart.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
