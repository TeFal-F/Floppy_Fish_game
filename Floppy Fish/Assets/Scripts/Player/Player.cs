using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public LogicScript logic;
    public PlayerRotation playerrot;
    private Animator anim;

    public bool playerIsAlive { get; private set; }
    public bool gameStarted { get; private set; }
    public bool gamePaused { get; private set; }

    [Header("Movement Parameters")]
    [SerializeField] private float jumpPower;
    private float gravityScaleDefault;
    [Header("Death SFX")]
    [SerializeField] private AudioClip deathSound;
    private float deathTimer = 0.752f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }
    void Start()
    {
        playerIsAlive = true;
        gameStarted = false;
        gamePaused = false;
        gravityScaleDefault = rigidBody.gravityScale;
        rigidBody.gravityScale = 0;
    }

    void Update()
    {
        if (!playerIsAlive)
        {
            if (deathTimer <= 0)
            {
                gamePaused = true;
                logic.Gameover();
            }
            else
            {
                deathTimer -= Time.deltaTime;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (logic.gameoverOn)
            {
                logic.GameoverOff();
            }

            else
            {
                if (playerIsAlive == true)
                {
                    rigidBody.velocity = Vector2.up * jumpPower;
                    playerrot.goesUpwards = true;
                    playerrot.rotationTime = 0f;
                }
                if (!gameStarted)
                {
                    anim.SetBool("GameActive", true);
                    gameStarted = true;
                    rigidBody.gravityScale = gravityScaleDefault;
                    logic.GameStart();
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 && playerIsAlive)
        {
            anim.SetBool("Dead", true);
            rigidBody.gravityScale = 0f;
            rigidBody.velocity = Vector2.up;
            playerIsAlive = false;
            SoundManager.instance.PlaySFX(deathSound);
        }
    }
}
