using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Coin : MonoBehaviour
{
    private AudioSource monAS;
    private SpriteRenderer spr;
    private BoxCollider2D col;
    private PlayableDirector pd;
    private Animator anim;

    void Start()
    {
        monAS = GetComponent<AudioSource>();
        spr = GetComponent<SpriteRenderer>();
        col = GetComponent<BoxCollider2D>();
        pd = GetComponent<PlayableDirector>();
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RobotBoyController rbc = collision.GetComponent<RobotBoyController>();
        if(rbc != null)
        {
            ++rbc.Score;
            DisableComponents();
            monAS.Play();
        }
    }

    private void DisableComponents()
    {
        spr.enabled = col.enabled = false;
        Invoke("EnableComponents", 30f);
    }

    private void EnableComponents()
    {
        spr.enabled = col.enabled = true;
    }
}
