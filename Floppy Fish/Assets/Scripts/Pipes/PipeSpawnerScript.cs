using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
    public Player player;

    public GameObject pipe;
    [Header("Pipe Spawn Parameters")]
    [SerializeField] public float spawnRate;
    [SerializeField] public float maxSpawnHeightRange;
    private float timer = 0;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (!player.gameStarted)
        {
            return;
        }

        if(player.playerIsAlive == false)
        {
            return;
        }

        if (timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            SpawnPipe();
        }
    }

    void SpawnPipe()
    {
        float bottomPoint = transform.position.y - maxSpawnHeightRange;
        float topPoint = transform.position.y + maxSpawnHeightRange + 0.01f;

        float yDistance = Random.Range(bottomPoint, topPoint);
        Instantiate(pipe, new Vector3(transform.position.x, yDistance, 0), transform.rotation);
    }
}
