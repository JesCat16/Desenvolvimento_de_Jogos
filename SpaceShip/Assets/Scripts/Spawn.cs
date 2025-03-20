using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public Transform navePrefab;
    public Transform cometaPrefab;
    public float spawnRate = 2f;
    private bool isPlayerPosition = false;
    private Transform playerTransforme;
    private float randomizar;
    void Start()
    {
        playerTransforme = GameObject.FindGameObjectWithTag("Player").transform;
        InvokeRepeating("Spawner", spawnRate,spawnRate);
    }

    private void Spawner()
    {
        isPlayerPosition = !isPlayerPosition;

        Vector3 spawnPosition;

        if (isPlayerPosition && playerTransforme != null)
        {
            spawnPosition = new Vector3(transform.position.x,
                                        playerTransforme.position.y,
                                        transform.position.z);
        }
        else
        {
            spawnPosition = new Vector3(transform.position.x,
                                        Random.Range(-4, 4),
                                        transform.position.z);
        }

        if(randomizacao()>= 0.5)
        {
            var NaveTransform = Instantiate(navePrefab) as Transform;
            NaveTransform.position = spawnPosition;
        }
        else
        {
            var CometaTransform = Instantiate(cometaPrefab) as Transform;
            CometaTransform.position = spawnPosition;
        }
    }

    private float randomizacao()
    {
        return randomizar = Random.value;
    }
  
}
