using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotBoyController : MonoBehaviour
{
    public float vitesse;
    public float impulsion;
    public int maxPV = 5;
    public int PV { get => GetPV(); set => SetPV(value); }


    private float deplacement = 0;
    private bool saute = false;
    private bool accroupi = false;
    private int nbSauts = 0;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private int pv = 1;
    private bool dead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        PV = maxPV;
    }

    void Update()
    {
        if (dead)
            return;

        deplacement = Input.GetAxis("Horizontal");
        anim.SetFloat("Etat", Mathf.Abs(deplacement));
        if(deplacement != 0)
            sr.flipX = deplacement < 0;
        if (Input.GetKeyDown("w") && nbSauts < 2)
        {
            saute = true;
            anim.SetTrigger("Saut");
            ++nbSauts;
        }
        else if (nbSauts == 0)
        {
            accroupi = Input.GetKey("s");
            anim.SetBool("Accroupi", accroupi);
            if (Input.GetKeyDown("x"))
                anim.SetTrigger("Roule");
        }
    }

    private void FixedUpdate()
    {
        if (dead)
            return;

        rb.AddRelativeForce(Vector2.right * vitesse * deplacement * (accroupi ? 0.5f : 1));

        if (saute)
        {
            rb.AddRelativeForce(Vector2.up * impulsion, ForceMode2D.Impulse);
            saute = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        nbSauts = 0;
    }

    public void Die()
    {
        dead = true;
        anim.SetTrigger("Mort");
    }

    public bool IsDead()
    {
        return dead;
    }

    private void SetPV(int value)
    {
        pv = Mathf.Min(value, maxPV);
        if (pv < 1)
            Die();
    }

    private int GetPV()
    {
        return pv;
    }
}
