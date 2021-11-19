using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    bool damageDealt = false; // Évite que la même explosion inflige deux fois des dégats au joueur.

    private void OnTriggerEnter2D(Collider2D collision)
    {
        RobotBoyController rbc = collision.GetComponent<RobotBoyController>();
        if(rbc != null && !damageDealt)
        {
            --rbc.PV;
            damageDealt = true;
        }
    }
}
