using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public Player player;

    [Header("Movement Parameters")]
    [SerializeField] public float moveSpeed;
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    void Update()
    {
        if (player.playerIsAlive == false)
        {
            return;
        }

        transform.position = transform.position + (Vector3.left * moveSpeed * Time.deltaTime);

    }
}
