using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public Player player;

    [Header("Movement Parameters")]
    [SerializeField] public float moveSpeed;
    [SerializeField] private float deadZone;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {
        if(player.playerIsAlive == false)
        {
            return;
        }

        transform.position = transform.position + (Vector3.left * moveSpeed * Time.deltaTime);
    
        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
