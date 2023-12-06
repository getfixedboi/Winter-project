using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class collectiblesScript : MonoBehaviour
{
    [Header ("Scripts references")]
    [SerializeField] levelGoalManagerScript levelGoalManagerScript;

    [Header ("Text for apple counter (taken from canvas)")]
    [SerializeField] Text appleCounter;

    internal ContactFilter2D filter;
    private BoxCollider2D boxcol;
    private Animator anim;
    private Collider2D[] hits = new Collider2D[10];
    private bool collected=false;

    private void Start()
    {
        anim = GetComponent<Animator>();
        Create();
    }

    private void Update()
    {
        OnAppleCollideCheck();
    }

    private void Create()
    {
        boxcol = GetComponent<BoxCollider2D>();
        filter = new ContactFilter2D();

        filter.layerMask = LayerMask.GetMask("Player");
        filter.useLayerMask = true;
    }

    private void OnAppleCollideCheck()
    {
        boxcol.Overlap(filter, hits);
        for (int i = 0; i < hits.Length; i++)
        {
            if (hits[i] == null)
                continue;
            OnCollide(hits[i]);
                hits[i] = null;
        }
    }

    private IEnumerator animationAfterCollect()
    {
        collected = true;
        colliderScript.appleCount++;
        appleCounter.text = colliderScript.appleCount.ToString();
        anim.Play("appleCollected");

        yield return new WaitForSeconds(0.5f);
        
        Destroy(gameObject);
        levelGoalManagerScript.PassArgument();
    }

    private void OnCollide(Collider2D coll)
    {
        if (coll.name == "player" && !collected)
        {
            StartCoroutine(animationAfterCollect());
        }
    }
}