using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Teleporter : MonoBehaviour
{
    public Teleporter otherEnd;
    public Transform robotBoy;

    private PlayableDirector pd;
    private bool usable = true;

    private void Start()
    {
        pd = GetComponentInChildren<PlayableDirector>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "RobotBoy" && usable)
        {
            otherEnd.TeleportTo();
        }
    }

    private void TeleportTo()
    {
        usable = false;
        robotBoy.position = transform.position;
        pd.Play();
        Invoke("ReEnable", 3f);
    }

    private void ReEnable() 
    {
        usable = true;
    }
}
