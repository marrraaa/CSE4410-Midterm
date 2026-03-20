using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tunnelSpawner : MonoBehaviour
{
    public GameObject[] tunnelsPrefabs;

    private Transform playerTransform;
    private int locZ = -15;
    private int tunnelLength = 100;
    private int tunnOnScreen = 6;
    private int lastTunnel = 0;
    private int safe = 80;

    private List <GameObject> curTunnels;
    // Start is called before the first frame update
    void Start()
    {
        curTunnels = new List<GameObject>();
        playerTransform = GameObject.FindWithTag("Player").transform;

        for(int i = 0; i < tunnOnScreen; i++)
        {
            if (i < 3)
            {
                addTunnel(0);
            }
            else
            {
                addTunnel();
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.z - safe > (locZ - tunnOnScreen * tunnelLength))
        {
            addTunnel();
            deleteTunnel();
        }
    }

    private int RandomPrefabIndex()
    {
        if(tunnelsPrefabs.Length <= 1)
        {
            return 0;
        }

        int randomIndex = lastTunnel;
        while(randomIndex == lastTunnel)
        {
            randomIndex = Random.Range(0, tunnelsPrefabs.Length);
        }
        lastTunnel = randomIndex;
        return randomIndex;
    }
    private void addTunnel(int prefabIndex =- 1) 
    {
        GameObject go;
        if(prefabIndex == -1)
        {
            go = Instantiate(tunnelsPrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
        {
            go = Instantiate(tunnelsPrefabs[prefabIndex]) as GameObject;
        }
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * locZ;
        locZ += tunnelLength;
        curTunnels.Add(go);
    }

    private void deleteTunnel()
    {
        Destroy(curTunnels[0]);
        curTunnels.RemoveAt(0);
    }
}
