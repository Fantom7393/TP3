using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class SpringJump : MonoBehaviour
{
    public PlayableDirector pd;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        RobotBoyController rbc = collision.collider.GetComponent<RobotBoyController>();
        if(rbc != null)
        {
            pd.Play();
        }
    }
}
