using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personneStore : MonoBehaviour {

    private bool on = true;
    private Light lum;
    public KeyCode ouvrir;
    public KeyCode fermer;

    RaycastHit hit;
    // Use this for initialization

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, 150.0f))
        {
            Animator anim = hit.collider.gameObject.GetComponent<Animator>();


            if (hit.collider.gameObject.tag == "interactible_store")
            {
                Debug.Log("store " + hit.collider.gameObject.name);
                if (Input.GetKeyDown("e"))
                {
                    anim.Play("ouvrir");
                    Debug.Log("store ouvert" + hit.collider.gameObject.name);
                    anim.SetBool("fermer", false);
                }
                else if (Input.GetKeyDown(fermer))
                {
                    anim.SetBool("fermer", true);
                }
            }
        }
        }
}
