using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class DeathSkull : MonoBehaviour
{
    private AudioSource monAS;
    private BoxCollider2D col;
    private PlayableDirector pd;

    private void Awake()
    {
        monAS = GetComponent<AudioSource>();
        col = GetComponent<BoxCollider2D>();
        pd = GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RobotBoyController rbc = collision.GetComponent<RobotBoyController>();
        if (rbc != null)
        {
            rbc.Die();
            monAS.Play();
            col.enabled = false;
            pd.Play();
        }
    }
}
