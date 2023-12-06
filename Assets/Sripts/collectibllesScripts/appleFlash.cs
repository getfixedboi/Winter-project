using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class appleFlash : MonoBehaviour
{
    [Header("materials references")]
    [SerializeField] Material darkness;
    [SerializeField] Material defaultSprite;

    [Header("apples references")]
    [SerializeField] private GameObject apple1;
    [SerializeField] private GameObject apple2;
    [SerializeField] private GameObject apple3;
    [SerializeField] private GameObject apple4;

    [SerializeField] private GameObject apple5;
    [SerializeField] private GameObject apple6;
    [SerializeField] private GameObject apple7;
    [SerializeField] private GameObject apple8;
    [SerializeField] private GameObject apple9;
    [SerializeField] private GameObject apple10;
    [SerializeField] private GameObject apple11;

    private List<GameObject> flashingApples;

    public void Start()
    {
        CreateList();
        StartCoroutine(Flashing());
    }

    private void CreateList()
    {
        flashingApples = new List<GameObject>() { apple1, apple2, apple3, apple4,apple5,apple6,apple7,apple8,apple9,apple10,apple11};
    }
    private IEnumerator Flashing()
    {
        while (true)
        {
            if(flashingApples==null)
            {
                    break;
            }
                
            for (int i = 0; i < flashingApples.Count; i++)
            {
                if (flashingApples[i].gameObject != null)
                {
                    Light appleLight = flashingApples[i].GetComponent<Light>();
                    SpriteRenderer flashingRenderer = flashingApples[i].GetComponent<SpriteRenderer>();

                    if (appleLight != null)
                    {
                        appleLight.enabled = false;
                        flashingRenderer.material = darkness;
                    }
                }
            }

            yield return new WaitForSeconds(1f);

            for (int i = 0; i < flashingApples.Count; i++)
            {
                

                if (flashingApples[i].gameObject != null)
                {
                    yield return new WaitForSeconds(0.5f);
                    Light appleLight = flashingApples[i].GetComponent<Light>();
                    SpriteRenderer flashingRenderer = flashingApples[i].GetComponent<SpriteRenderer>();

                    if (appleLight != null)
                    {
                        appleLight.enabled = true;
                        flashingRenderer.material = defaultSprite;
                    }
                }
            }
            yield return new WaitForSeconds(0.5f);
        }
    }
}