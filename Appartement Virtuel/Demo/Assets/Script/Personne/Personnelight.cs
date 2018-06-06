using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personnelight : MonoBehaviour {
        
    private GameObject[] lits;
    private bool on = true;
    private Light lum;
    public KeyCode allumer;
    public KeyCode eteindre;

    void Update() { }

    // Update is called once per frame
    void OnTriggerStay() {

        lits = GameObject.FindGameObjectsWithTag("sejourL");
        
        Debug.Log("lits "+lits.Length);
        Debug.Log(on);
        if (Input.GetKeyDown(eteindre) && on)
       {
            Debug.Log(on);
            foreach (GameObject lit in lits)
        {
            lum = lit.GetComponent<Light>();
                Debug.Log(lum.name);
                //lit.SetActive(false);
                
              lum.enabled = false;
                on = false;
        }
        }
      else if (Input.GetKeyDown(allumer) && !on)
        {
            foreach (GameObject lit in lits)
            {
                lum = lit.GetComponent<Light>();
                Debug.Log(lum.name);
                //lit.SetActive(false);

                lum.enabled = true;
                on = true;
            }
        }
    }
}
