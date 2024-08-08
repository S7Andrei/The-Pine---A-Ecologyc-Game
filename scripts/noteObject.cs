using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noteObject : MonoBehaviour
{
    public bool canBePressed;

    public KeyCode KeyToPress;
    public GameObject hitEffect, goodEffect, perfectEffect, missEffect;

    void Update()
    {
        if(Input.GetKeyDown(KeyToPress))
        {
            if(canBePressed)
            {
                gameObject.SetActive(false);

                if(Mathf.Abs(transform.position.y) < 0.25f)
                {
                    Debug.Log("Hit");
                    GameManager.instance.NormalHit();
                    Instantiate(hitEffect, transform.position, hitEffect.transform.rotation);
                }
                else if(Mathf.Abs(transform.position.y) > 0.15f)
                {
                    Debug.Log("Good");
                    GameManager.instance.GoodHit();
                    Instantiate(goodEffect, transform.position, goodEffect.transform.rotation);
                }
                else
                {
                    Debug.Log("Perfect");
                    GameManager.instance.PerfectHit();

                    // Carregar e instanciar o prefab do efeito "Perfect" da pasta "Resources/effects"
                    GameObject perfectEffectPrefab = Resources.Load<GameObject>("effects/" + perfectEffect.name);
                    Instantiate(perfectEffectPrefab, transform.position, perfectEffectPrefab.transform.rotation);
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.tag == "Activator")
        {
            canBePressed = false;
        }
    }
}
