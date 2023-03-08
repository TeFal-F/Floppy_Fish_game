using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public Player player;

    [Header("Rotation Parameters")]
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float rotationSpeedDead;
    [SerializeField] private float rotationJumpModifier;
    [SerializeField] private float rotationUpperBorder;
    [SerializeField] private float rotationLowerBorder;
    private float rotationDeathZ;
    [SerializeField] private float rotationTimer;
    public float rotationTime;
    private float rotZ;
    public bool goesUpwards;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }
    private void Start()
    {
        rotationDeathZ = 180f;
        goesUpwards = false;
        rotationTime = 0f;
    }

    private void Update()
    {
        if (player.gameStarted == false)
        {
            return;
        }

        if (player.playerIsAlive == false)
        {
            if (rotZ < 0)
            {
                rotationDeathZ = -rotationDeathZ;
            }
            if (rotZ < 0 && rotZ > rotationDeathZ)
            {
                rotZ -= Time.deltaTime * rotationSpeedDead;
            }
            else if (rotZ >= 0 && rotZ < rotationDeathZ)
            {
                rotZ += Time.deltaTime * rotationSpeedDead;
            }
        }
        else
        {
            if (goesUpwards == true)
            {
                if (rotZ <= rotationUpperBorder)
                {
                    rotZ += Time.deltaTime * rotationSpeed * rotationJumpModifier;
                }
                rotationTime += Time.deltaTime;
                if (rotationTime >= rotationTimer)
                {
                    rotationTime = 0f;
                    goesUpwards = false;
                }
            }
            else
            {
                if (rotZ >= rotationLowerBorder)
                {
                    rotZ -= Time.deltaTime * rotationSpeed;
                }
            }    
        }

        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}