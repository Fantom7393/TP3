using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Coeur : MonoBehaviour
{
    public PlayableAsset deuxiemeAnimation;

    private PlayableDirector pd;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        pd = GetComponent<PlayableDirector>();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RobotBoyController rbc = collision.GetComponent<RobotBoyController>();

        if(rbc != null)
        {
            ++rbc.PV;
            rb.simulated = false;
            pd.Play(deuxiemeAnimation, DirectorWrapMode.Hold);
        }
    }
}
