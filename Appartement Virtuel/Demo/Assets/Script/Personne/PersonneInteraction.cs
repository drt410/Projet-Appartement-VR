using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System;
public class PersonneInteraction : MonoBehaviour {

    private GameObject[] supports;

    public float speed = 0.001f;
    public float distanceVue;

    public KeyCode moveDown;
    public KeyCode moveUp;
    public KeyCode deplacer;
    public KeyCode douche;
    public PlayableDirector director;
    public PlayableDirector director2;

    private bool ranger = true;
    private float countdown;
    private float current = 0.0f;

    private Animator anim;

    RaycastHit hit;

    void Start()
    {
        supports = GameObject.FindGameObjectsWithTag("support_meuble");
    }

    // Update is called once per frame
    void Update () {

        Debug.DrawRay(this.transform.position, this.transform.forward * distanceVue, Color.magenta);

        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceVue))
        {
            anim = hit.collider.gameObject.GetComponent<Animator>();
            director = hit.collider.gameObject.GetComponent<PlayableDirector>();
            Transform corps = hit.collider.gameObject.transform;
            GameObject meuble;
            meuble = hit.collider.gameObject;

            switch (meuble.tag)
            {
                case "interactible":
                    AnimInteract(hit, deplacer, "ranger", "ouvrir");
                    break;
                case "interactible_store":
                    AnimInteractStore(hit, moveUp, moveDown, "fermer", "ouvrir");
                    break;
                case "interactible_store2":
                    AnimInteractStore(hit, moveUp, moveDown, "fermer", "ouvrir_storeC");
                    break;
                case "interactible_porte":
                    AnimInteract(hit, deplacer, "ranger", "ouvrir");
                    break;
                case "interactible_porte2":
                    AnimInteractPorte(hit, deplacer);
                    break;
                case "interactible_plt":
                    AnimInteractPLT(hit, moveUp, moveDown, corps);
                    break;
                case "interactible_plt2":
                    AnimInteractPLT(hit, moveUp, moveDown, corps);
                    break;
                case "meuble_haut":
                    AnimInteractMeubleHaut(hit, moveDown, moveUp, corps);
                    break;
                case "leve_personne":
                    AnimInteractLevePers(hit,KeyCode.L);
                    break;
            }

            //AnimInteract(hit, deplacer, "fermer", "porte1");
            //AnimInteractStore(hit, moveUp, moveDown, "fermer", "ouvrir");
            //AnimInteractStore(hit, moveUp, moveDown, "fermer", "ouvrir_storeC");
            //AnimInteractPorte(hit, deplacer);
            //AnimInteractPLT(hit, moveUp, moveDown, corps);
            //AnimInteractMeubleHaut(hit, moveDown, moveUp, corps);

        }
    }

    void AnimInteract(RaycastHit hit,KeyCode key,string animBool, string animTrigger)
    {
        if(anim != null)
        {
            if (hit.collider.gameObject.tag != null)
            {
                if (Input.GetKeyDown(key) && anim.GetBool(animBool) == true)
                {
                    anim.Play(animTrigger);
                    anim.SetBool(animBool, false);
                }
                else if (Input.GetKeyDown(deplacer) && anim.GetBool(animBool) == false)
                {
                    anim.SetBool(animBool, true);
                }
            }
        }

    }

    void AnimInteractStore(RaycastHit hit, KeyCode key1, KeyCode key2, string animBool, string animTrigger)
    {
        if (anim != null)
        {
            if (hit.collider.gameObject.tag != null)
            {
                
                if (Input.GetKeyDown(key1))
                {
                    anim.Play(animTrigger);
                    anim.SetBool(animBool, false);
                }
                else if (Input.GetKeyDown(key2))
                {
                    anim.SetBool(animBool, true);
                }
            }
        }
    }

    void AnimInteractPorte(RaycastHit hit, KeyCode key)
    {
           
            if (hit.collider.gameObject.tag != null)
            {
            director2 = hit.collider.gameObject.GetComponent<PlayableDirector>();

            if (Input.GetKeyDown(key))
                {
                    director2.Play();
                }
            }
        
    }

    void AnimInteractPLT(RaycastHit hit, KeyCode key1, KeyCode key2, Transform t)
    {
 
            if (hit.collider.gameObject.tag == "interactible_plt")
            {

                if (Input.GetKey(key2))
                {
                    t.Translate(0, 0, -speed);
                }

                if (Input.GetKey(key1))
                {
                    t.Translate(0, 0, speed);
                }
            }

            else if (hit.collider.gameObject.tag == "interactible_plt2")
            {

                if (Input.GetKey(moveDown))
                {
                    t.Translate(0, -speed, 0);
                }

                if (Input.GetKey(moveUp))
                {
                    t.Translate(0, speed, 0);
                }
            }
        
    }

    void AnimInteractMeubleHaut(RaycastHit hit, KeyCode key1, KeyCode key2, Transform t)
    {
            if (hit.collider.gameObject.tag == "meuble_haut")
            {                      
                if (Input.GetKey(key1))
                {
                    foreach (GameObject support in supports)
                    {
                        if (support.transform.localScale.z < 60.0f)
                        {
                            support.transform.localScale += new Vector3(0, 0, speed);
                            t.Translate(0, speed, -speed);
                        }
                    }
                }

                if (Input.GetKey(key2))
                {
                    foreach (GameObject support in supports)
                    {
                        if (support.transform.localScale.z > 6.0f)
                        {
                            support.transform.localScale -= new Vector3(0, 0, speed);
                            t.Translate(0, -speed, speed);
                        }
                    }
                }
            }
    }

    void AnimInteractLevePers(RaycastHit hit, KeyCode key)
    {
        if (Input.GetKeyDown(key))
        {
            director.Play();
        }
    }

    //if (hit.collider.gameObject.tag == "interactible_porte2")
    //{
    //    director2 = hit.collider.gameObject.GetComponent<PlayableDirector>();
    //    print("portedouche");

    //    if (Input.GetKeyDown(deplacer))
    //    {
    //        director2.Play();
    //    }
    //}

    //if (hit.collider.gameObject.tag == "interactible_rgt")
    //{
    //    if (Input.GetKeyDown(deplacer))
    //    {
    //        anim.Play("deplacer");
    //        anim.SetBool("ranger", false);
    //    }
    //    else if (Input.GetKeyDown(deplacer))
    //    {
    //        anim.SetBool("ranger", true);
    //    }
    //}
}
