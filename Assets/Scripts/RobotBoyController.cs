using UnityEngine;
using UnityEngine.SceneManagement;

public class RobotBoyController : MonoBehaviour
{
    public float vitesse;
    public float impulsion;
    public int maxPV = 5;
    public PointsVies pvManager;
    public AudioClip marcheMortuaire;
    public Transform jeu; // Va servir à déparenter la plateforme du robot lorsque celui-ci saute.
    public int PV { get => GetPV(); set => SetPV(value); }
    public uint Score { get; set; }


    private float deplacement = 0;
    private bool saute = false;
    private bool accroupi = false;
    private int nbSauts = 0;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Animator anim;
    private AudioSource monAS;
    private int pv = 1;
    private bool dead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        monAS = GetComponent<AudioSource>();
        PV = maxPV;
    }

    void Update()
    {
        if (dead)
            return;

        if (transform.position.y < -25)
        {
            Die();
            return;
        }

        deplacement = Input.GetAxis("Horizontal");
        anim.SetFloat("Etat", Mathf.Abs(deplacement));
        if(deplacement != 0)
            sr.flipX = deplacement < 0;
        if (Input.GetKeyDown("w") && nbSauts < 2)
        {
            saute = true;
            transform.SetParent(jeu);
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

    public void ResetJumps()
    {
        nbSauts = 0;
    }

    public void Die()
    {
        dead = true;
        anim.SetTrigger("Mort");
        monAS.Stop();
        monAS.PlayOneShot(marcheMortuaire);
        if (pv > 0)
            pvManager.UpdatePV(0);
        Invoke("Recommencer", 7f);
    }

    public bool IsDead()
    {
        return dead;
    }

    private void SetPV(int value)
    {
        if (dead)
            return;
        pv = Mathf.Min(value, maxPV);
        pvManager.UpdatePV(pv);
        if (pv < 1)
            Die();
    }

    private int GetPV()
    {
        return pv;
    }

    private void Recommencer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
