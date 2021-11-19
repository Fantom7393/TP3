using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    bool damageDealt = false; // �vite que la m�me explosion inflige deux fois des d�gats au joueur.

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
