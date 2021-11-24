using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Ce script sert à placer la plateforme mouvante sur laquelle le robot saute comme son parent tant qu'il est dessus.
 * Cela fera en sorte que le robot suivra la plateforme lorsqu'elle bouge.
 */
public class MovingPlatform : MonoBehaviour
{
    public Transform robot;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name == "Pieds")
            robot.SetParent(transform);
    }
}
