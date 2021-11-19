using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Bombe : MonoBehaviour
{
    public PlayableDirector pd;
    public CircleCollider2D explosionCollider;
    bool litOrDetonated = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (litOrDetonated)
            return;
        litOrDetonated = true;
        pd.Play();
        StartCoroutine("ColliderAnimation");
    }

    private IEnumerator ColliderAnimation()
    {
        yield return new WaitForSeconds(3f);
        explosionCollider.enabled = true;
        yield return new WaitForSeconds(0.5f);
        explosionCollider.enabled = false;
        yield return new WaitForSeconds(0.3f);
        GetComponent<CircleCollider2D>().enabled = false;
    }

}
