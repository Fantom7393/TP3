using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointsVies : MonoBehaviour
{ 
    private RawImage rawImage;

    void Awake()
    {
        rawImage = GetComponent<RawImage>();
    }

    public void UpdatePV(int pv)
    {
        rawImage.uvRect = new Rect(0, 0, pv, 1f);
        transform.localScale = new Vector3(pv, transform.localScale.y, transform.localScale.z);
    }
}
