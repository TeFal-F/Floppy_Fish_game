using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;

public class ParticlesScript : MonoBehaviour
{
    public Player player;
    public ParticleSystem particles;

    void Update()
    {
        if (player.playerIsAlive == false && particles.isPaused == false)
        {
            particles.Pause(true);
        }
    }
}
