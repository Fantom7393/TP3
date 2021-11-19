using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AccessoiresManager : MonoBehaviour
{
    public GameObject bombe;
    public GameObject coeur;
    public float[] pointsApparition =
    {
        -34, -30, -26, -22, -18, -14, -10, -6, -2, 2, 6, 10, 14,
        18, 22, 26, 30
    };
    // Start is called before the first frame update
    void Start()
    {
        SpawnAccessories();
        InvokeRepeating("SpawnAccessories", 10, 10);
    }

    private void SpawnAccessories()
    {
        float[] randomPoints = pointsApparition.OrderBy(x => Random.value).Take(8).ToArray();
        Instantiate(bombe, new Vector2(randomPoints[0], 24), Quaternion.identity, transform);
    }
}
