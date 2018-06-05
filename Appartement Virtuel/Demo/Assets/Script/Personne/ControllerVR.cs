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

    private bool ranger = true;
    private float countdown;
    private float current = 0.0f;

    RaycastHit hit;

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
        if (Controller.GetHairTrigger())
        {
            //Vector2 touchpad = (Controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0));
             // print("Pressing Touchpad");





            Debug.DrawRay(this.transform.position, this.transform.forward * distanceVue, Color.magenta);

            if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, distanceVue))
            {
                Animator anim = hit.collider.gameObject.GetComponent<Animator>();
                director = hit.collider.gameObject.GetComponent<PlayableDirector>();

                if (hit.collider.gameObject.tag == "leve_personne")
                {
                    print("douche");

                    if (Input.GetKeyDown("l"))
                    {
                        director.Play();
                    }
                }
                if (hit.collider.gameObject.tag == "interactible")
                {
                    if (Input.GetKeyDown(deplacer))
                    {
                        anim.Play("ouvrir");
                        anim.SetBool("ranger", false);
                    }
                    else if (Input.GetKeyDown(deplacer))
                    {
                        anim.SetBool("ranger", true);
                    }
                }

                if (hit.collider.gameObject.tag == "interactible_store")
                {
                    // Debug.Log("store " + hit.collider.gameObject.name);
                    // if (Controller.GetAxis() != new Vector2(0.0f, 1.0f))
                    // {
                    anim.Play("ouvrir");
                    print("store ouvert" + hit.collider.gameObject.name);
                    anim.SetBool("fermer", false);
                }
                else if (anim.GetBool("fermer") == false)
                {
                    anim.SetBool("fermer", true);
                }
                


                if (hit.collider.gameObject.tag == "interactible_store2")
                {
                    Debug.Log("store " + hit.collider.gameObject.name);
                    if (Input.GetKeyDown(moveUp))
                    {
                        anim.Play("ouvrir_storeC");
                        Debug.Log("store ouvert" + hit.collider.gameObject.name);
                        anim.SetBool("fermer", false);
                    }
                    else if (Input.GetKeyDown(moveDown))
                    {
                        anim.SetBool("fermer", true);
                    }
                }

                if (hit.collider.gameObject.tag == "interactible_porte")
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
                }

                if (hit.collider.gameObject.tag == "interactible_rgt")
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
                //StopCoroutine (Timer (anim));

                if (hit.collider.gameObject.tag == "interactible_plt")
                {
                    //Debug.Log("plan de travail "+hit.collider.gameObject.name);
                    Transform corps = hit.collider.gameObject.transform;

                    if (Input.GetKey(moveDown))
                    {
                        corps.Translate(0, 0, -speed);
                    }

                    if (Input.GetKey(moveUp))
                    {
                        corps.Translate(0, 0, speed);
                    }
                }

                if (hit.collider.gameObject.tag == "interactible_plt2")
                {
                    //Debug.Log("plan de travail "+hit.collider.gameObject.name);
                    Transform corps = hit.collider.gameObject.transform;

                    if (Input.GetKey(moveDown))
                    {
                        corps.Translate(0, -speed, 0);
                    }

                    if (Input.GetKey(moveUp))
                    {
                        corps.Translate(0, speed, 0);
                    }
                }

                if (hit.collider.gameObject.tag == "meuble_haut")
                {
                    //Debug.Log("plan de travail "+hit.collider.gameObject.name);
                    Transform corps = hit.collider.gameObject.transform;
                    supports = GameObject.FindGameObjectsWithTag("support_meuble");
                    if (Input.GetKey(moveDown))
                    {
                        foreach (GameObject support in supports)
                        {
                            if (support.transform.localScale.z < 60.0f)
                            {
                                support.transform.localScale += new Vector3(0, 0, speed);
                                corps.Translate(0, speed, -speed);
                            }
                        }
                    }

                    if (Input.GetKey(moveUp))
                    {
                        foreach (GameObject support in supports)
                        {
                            if (support.transform.localScale.z > 6.0f)
                            {
                                support.transform.localScale -= new Vector3(0, 0, speed);
                                corps.Translate(0, -speed, speed);
                            }
                        }
                    }
                }

                if (hit.collider.gameObject.tag == "interactible_lit_douche")
                {
                    Debug.Log(hit.collider.gameObject.name);
                    if (Input.GetKeyDown(moveDown))
                    {
                        anim.Play("descendre");
                        anim.SetBool("ranger", false);
                    }
                    else if (Input.GetKeyDown(moveUp))
                    {
                        anim.SetBool("ranger", true);
                    }
                }


            }
        }
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