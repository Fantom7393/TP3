using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public RobotBoyController rbc;
    public Transform pointHG;
    public Transform pointBD;
    public Vector2 offset;
    public float maxCounterYOffset;
    public float offsetAnimationSpeed;

    private float cameraDemiLargeur;
    private float cameraDemiHauteur;
    private float currentOffsetY;

    void Start()
    {
        Camera cam = GetComponent<Camera>();

        cameraDemiHauteur = cam.orthographicSize;
        cameraDemiLargeur = cam.aspect * cameraDemiHauteur;
        currentOffsetY = offset.y;
    }

    // Update is called once per frame
    void Update()
    {
        float posHoriz, posVert;
        bool sPressed;


        sPressed = Input.GetKey("s") && !rbc.IsDead();
        currentOffsetY += offsetAnimationSpeed * Time.deltaTime * (sPressed ? -1 : 1);

        currentOffsetY = Mathf.Clamp(currentOffsetY, maxCounterYOffset, offset.y);

        posHoriz = Mathf.Clamp(player.position.x + offset.x, pointHG.position.x + cameraDemiLargeur, pointBD.position.x - cameraDemiLargeur);
        posVert = Mathf.Clamp(player.position.y + currentOffsetY, pointBD.position.y + cameraDemiHauteur, pointHG.position.y - cameraDemiHauteur);
        transform.position = new Vector3(
            posHoriz,
            posVert,
            transform.position.z
        );
    }
}
