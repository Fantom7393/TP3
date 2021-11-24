using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotFeet : MonoBehaviour
{
    public RobotBoyController rbc;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        rbc.ResetJumps();
    }
}
