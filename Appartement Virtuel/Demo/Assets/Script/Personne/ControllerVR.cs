using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[RequireComponent(typeof(PersonneMouvement))]
public class ControllerVR : MonoBehaviour
{
    public float sensitivity;
    public Transform body;
    public float amount = 1.0f;
    private GameObject[] supports;

    public float speed = 0.001f;
    public float distanceVue;

    public KeyCode moveDown;
    public KeyCode moveUp;
    public KeyCode deplacer;
    public PlayableDirector director;
    public PlayableDirector director2;
    public PlayableDirector director3;

    private bool ranger = true;
    private bool on = true;
    private float countdown;
    private float current = 0.0f;

    RaycastHit hit;

    private GameObject[] lits;
    private Light lum;

    private PersonneMouvement perso;
    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    void Start()
    {
        perso = GetComponent<PersonneMouvement>();
       // Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {


            Vector2 touchpad = (Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));
            Debug.DrawRay(this.transform.position, this.transform.forward * distanceVue, Color.magenta);

            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceVue))
            {
                Animator anim = hit.collider.gameObject.GetComponent<Animator>();
                director = hit.collider.gameObject.GetComponent<PlayableDirector>();

               /* if (hit.collider.gameObject.tag == "interactible_store")
                {
                    Debug.Log("store " + hit.collider.gameObject.name);
                    if (touchpad.y > 0.7f)
                    {
                        anim.Play("ouvrir");
                        print("store ouvert" + hit.collider.gameObject.name);
                        anim.SetBool("fermer", false);

                    }
                    else if (touchpad.y < -0.7f)
                    {
                        anim.SetBool("fermer", true);
                    }

                }*/

                if (touchpad.y > 0.5f)
                {
                    //this.transform.GetChild(1).gameObject.SetActive(true);
                    if (hit.collider.gameObject.tag == "boutonSejourL")
                    {
                        lits = GameObject.FindGameObjectsWithTag("sejourL");
                        if (!on)
                            foreach (GameObject lit in lits)
                            {
                                lum = lit.GetComponent<Light>();
                                Debug.Log(lum.name);
                                //lit.SetActive(false);

                                lum.enabled = true;
                                on = true;
                            }
                    }
                    if (hit.collider.gameObject.tag == "boutonDoucheL")
                    {
                        lits = GameObject.FindGameObjectsWithTag("SdeL");
                        if (!on)
                            foreach (GameObject lit in lits)
                            {
                                lum = lit.GetComponent<Light>();
                                Debug.Log(lum.name);
                                //lit.SetActive(false);

                                lum.enabled = true;
                                on = true;
                            }
                    }
                    if (hit.collider.gameObject.tag == "boutonChambreL")
                    {
                        lits = GameObject.FindGameObjectsWithTag("chambreL");
                        if (!on)
                            foreach (GameObject lit in lits)
                            {
                                lum = lit.GetComponent<Light>();
                                Debug.Log(lum.name);
                                //lit.SetActive(false);

                                lum.enabled = true;
                                on = true;
                            }
                    }


                    if (hit.collider.gameObject.tag == "leve_personne")
                    {

                        director3.Play();
                        print("Toilette");

                    }

                if (hit.collider.gameObject.tag == "interactible")
                    {
           
                        anim.Play("ouvrir");
                        anim.SetBool("ranger", false);
                  
                    }

                if (hit.collider.gameObject.tag == "interactible_store")
                    {
                        Debug.Log("store " + hit.collider.gameObject.name);
                        anim.Play("ouvrir");
                        print("store ouvert" + hit.collider.gameObject.name);
                        anim.SetBool("fermer", false);

                    }
                

                if (hit.collider.gameObject.tag == "interactible_store2")
                    {
                        Debug.Log("store " + hit.collider.gameObject.name);

                        anim.Play("ouvrir_storeC");
                        Debug.Log("store ouvert" + hit.collider.gameObject.name);
                        anim.SetBool("fermer", false);

                    }

               /* if (hit.collider.gameObject.tag == "interactible_porte")
                {
                    //  Debug.Log("porte " + hit.collider.gameObject.name);
                    if (Input.GetKeyDown(deplacer) && anim.GetBool("fermer") == true)
                    {

                        anim.Play("porte1");
                        anim.SetBool("fermer", false);
                        print(anim.GetBool("fermer"));
                    }
                    else if (Input.GetKeyDown(deplacer) && anim.GetBool("fermer") == false)
                    {
                        anim.SetBool("fermer", true);
                    }
                }

                if (hit.collider.gameObject.tag == "interactible_porte2")
                {
                    director2 = hit.collider.gameObject.GetComponent<PlayableDirector>();
                    print("portedouche");

                    if (Input.GetKeyDown(deplacer))
                    {
                        director2.Play();
                    }
                }*/

               /* if (hit.collider.gameObject.tag == "interactible_rgt")
                {
                    //StartCoroutine (Timer (anima));
                    if (Input.GetKeyDown(deplacer))
                    {
                        anim.Play("deplacer");
                        anim.SetBool("ranger", false);
                    }
                    else if (Input.GetKeyDown(deplacer))
                    {
                        anim.SetBool("ranger", true);
                    }
                }
                //StopCoroutine (Timer (anim));*/

                if (hit.collider.gameObject.tag == "interactible_plt")
                    {
                    //Debug.Log("plan de travail "+hit.collider.gameObject.name);
                        Transform corps = hit.collider.gameObject.transform;

              
                        corps.Translate(0, 0, speed);
                
                    }

                if (hit.collider.gameObject.tag == "interactible_plt2")
                    {
                    //Debug.Log("plan de travail "+hit.collider.gameObject.name);
                        Transform corps = hit.collider.gameObject.transform;


                        corps.Translate(0, speed, 0);
                    
                    }

                if (hit.collider.gameObject.tag == "meuble_haut")
                    {
                    //Debug.Log("plan de travail "+hit.collider.gameObject.name);
                        Transform corps = hit.collider.gameObject.transform;
                        supports = GameObject.FindGameObjectsWithTag("support_meuble");


                        foreach (GameObject support in supports)
                        {
                            if (support.transform.localScale.z > 6.0f)
                            {
                                support.transform.localScale -= new Vector3(0, 0, speed);
                                corps.Translate(0, -speed, speed);
                            }
                        }
                    
                    }

                if (hit.collider.gameObject.tag == "interactible_lit_douche")
                    {
                        Debug.Log(hit.collider.gameObject.name);

                        anim.SetBool("ranger", true);

                    
                    }
                    }

                else if(touchpad.y < -0.5f)
                    {

                    if (hit.collider.gameObject.tag == "boutonSejourL")
                    {
                        lits = GameObject.FindGameObjectsWithTag("sejourL");
                        if (on)
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
                    }
                    if (hit.collider.gameObject.tag == "boutonDoucheL")
                    {
                        lits = GameObject.FindGameObjectsWithTag("SdeL");
                        if (on)
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
                    }
                    if (hit.collider.gameObject.tag == "boutonChambreL")
                    {
                        lits = GameObject.FindGameObjectsWithTag("chambreL");
                        if (on)
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
                    }

                    if (hit.collider.gameObject.tag == "leve_personne")
                    {

                        director.Play();
                        print("douche");

                    }

                    if (hit.collider.gameObject.tag == "interactible_lit_douche")
                            {
                                Debug.Log(hit.collider.gameObject.name);
                                anim.Play("descendre");
                                anim.SetBool("ranger", false);

                            }
                    if (hit.collider.gameObject.tag == "interactible")
                        {

                            anim.SetBool("ranger", true);

                        }

                    if (hit.collider.gameObject.tag == "interactible_plt")
                        {
                        //Debug.Log("plan de travail "+hit.collider.gameObject.name);
                            Transform corps = hit.collider.gameObject.transform;
       
                            corps.Translate(0, 0, -speed);

                        }

                    if (hit.collider.gameObject.tag == "interactible_plt2")
                        {
                        //Debug.Log("plan de travail "+hit.collider.gameObject.name);
                            Transform corps = hit.collider.gameObject.transform;

                            corps.Translate(0, -speed, 0);
                        

                        }

                    if (hit.collider.gameObject.tag == "meuble_haut")
                        {
                        //Debug.Log("meuble_haut " + hit.collider.gameObject.name);
                            Transform corps = hit.collider.gameObject.transform;
                            supports = GameObject.FindGameObjectsWithTag("support_meuble");
              
                            foreach (GameObject support in supports)
                                {
                                    if (support.transform.localScale.z < 60.0f)
                                        {
                                            support.transform.localScale += new Vector3(0, 0, speed);
                                            corps.Translate(0, speed, -speed);
                                            Debug.Log("meuble_haut descend " + hit.collider.gameObject.name);
                                        }
                                }
                        


                        }
                    if (hit.collider.gameObject.tag == "interactible_store")
                        {
                            anim.SetBool("fermer", true);
                        }


                    if (hit.collider.gameObject.tag == "interactible_store2")
                        {
                            Debug.Log("store " + hit.collider.gameObject.name);

                            anim.SetBool("fermer", true);
                        
                        }

                    if (hit.collider.gameObject.tag == "interactible")
                        {

                        anim.SetBool("ranger", true);

                        }

                }

            }
        }
        if (Controller.GetHairTriggerDown())
        {

            Debug.DrawRay(this.transform.position, this.transform.forward * distanceVue, Color.magenta);

            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceVue))
            {
                Animator anim = hit.collider.gameObject.GetComponent<Animator>();
                if (hit.collider.gameObject.tag == "interactible_porte")
                {
                      Debug.Log("porte " + hit.collider.gameObject.name);
                    if (anim.GetBool("fermer") == true)
                    {

                        anim.Play("porte1");
                        anim.SetBool("fermer", false);
                        print(anim.GetBool("fermer"));
                    }
                    else if (anim.GetBool("fermer") == false)
                    {
                        anim.SetBool("fermer", true);
                    }
                }

                if (hit.collider.gameObject.tag == "interactible_porte2")
                {
                    director2 = hit.collider.gameObject.GetComponent<PlayableDirector>();
                    print("portedouche");            
                    director2.Play();
                }
            }

        }
        //this.transform.GetChild(1).gameObject.SetActive(false);
    }

    void RotationCl()
    {

        float deltaX = Input.GetAxisRaw("Horizontal");
        float rotatAmountX = deltaX * sensitivity;

        Vector3 targetRot = transform.rotation.eulerAngles;
        Vector3 targetRotBody = body.rotation.eulerAngles;

        targetRotBody.y += rotatAmountX;

        transform.rotation = Quaternion.Euler(targetRot);
        body.rotation = Quaternion.Euler(targetRotBody);
        // print("ok");

        if (Input.GetKeyDown("u"))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            //  float rotatAmountX = deltaX + mouseX * sensitivity;
            //float rotatAmountX = deltaX * sensitivity;
            float rotatAmountY = amount * sensitivity;

            targetRot = transform.rotation.eulerAngles;
            targetRotBody = body.rotation.eulerAngles;

            targetRot.x -= rotatAmountY;
            //targetRot.y = 0;
            targetRot.z = 0;
            targetRotBody.y += rotatAmountX;

            transform.rotation = Quaternion.Euler(targetRot);
            body.rotation = Quaternion.Euler(targetRotBody);
        }

        if (Input.GetKeyDown("p"))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            // float deltaX = Input.GetAxisRaw("Horizontal");
            // float rotatAmountX = deltaX + mouseX * sensitivity;
            //float rotatAmountX = deltaX * sensitivity;
            float rotatAmountY = amount * sensitivity;

            targetRot = transform.rotation.eulerAngles;
            targetRotBody = body.rotation.eulerAngles;

            targetRot.x += rotatAmountY;
            // targetRot.y = 0;
            targetRot.z = 0;
            targetRotBody.y += rotatAmountX;

            transform.rotation = Quaternion.Euler(targetRot);
            body.rotation = Quaternion.Euler(targetRotBody);
        }
    }

    //rotation avec souris
    void Rotation()
    {


        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float deltaX = Input.GetAxisRaw("Horizontal");
        float rotatAmountX = deltaX + mouseX * sensitivity;
        //float rotatAmountX = deltaX * sensitivity;
        float rotatAmountY = mouseY * sensitivity;

        Vector3 targetRot = transform.rotation.eulerAngles;
        Vector3 targetRotBody = body.rotation.eulerAngles;

        targetRot.x -= rotatAmountY;
        targetRot.z = 0;
        targetRotBody.y += rotatAmountX;

        transform.rotation = Quaternion.Euler(targetRot);
        body.rotation = Quaternion.Euler(targetRotBody);
    }
}