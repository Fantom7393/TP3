using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AccessoiresManager : MonoBehaviour
{
    public GameObject bombe;
    public GameObject coeur;
    public RobotBoyController rbc;
    public float[] pointsApparition =
    {
        -34, -30, -26, -22, -18, -14, -10, -6, -2, 2, 6, 10, 14,
        18, 22, 26, 30
    };

    void Start()
    {
        SpawnAccessories();
        InvokeRepeating("SpawnAccessories", 10, 10);
    }

    private void SpawnAccessories()
    {
        if (rbc.IsDead())
            return;

        float[] randomPoints = pointsApparition.OrderBy(x => Random.value).Take(8).ToArray();
        Instantiate(bombe, new Vector2(randomPoints[0], 24), Quaternion.identity, transform);
        for(int i = 1; i < 8; ++i)
            Instantiate(coeur, new Vector2(randomPoints[i], 24), Quaternion.identity, transform);
    }
}
