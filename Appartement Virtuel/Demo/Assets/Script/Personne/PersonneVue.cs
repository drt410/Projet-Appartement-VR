using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Playables;

public class PersonneVue : MonoBehaviour {

    public float sensitivity;
    public Transform body;
    public float amount = 1.0f;


	/*public float speed = 0.001f;
    public float distanceVue;

    private Animator anim;

	public KeyCode moveDown;
	public KeyCode moveUp;
	public KeyCode monter;
	public KeyCode deplacer;
	public PlayableDirector director;
    public PlayableDirector director2;

    private bool ranger = true;
	private float countdown;
	private float current = 0.0f;

    RaycastHit hit;*/

    void Start()
    {
       

       
    }

    // Update is called once per frame
    void Update()
    {
		
       // Cursor.lockState = CursorLockMode.Locked;
       // Rotation();
        RotationCl();

    }

    // Rotation avec clavier seulement
    void RotationCl()
    {

        float deltaX = Input.GetAxisRaw("Horizontal");
        float rotatAmountX = deltaX * sensitivity;

        Vector3 targetRot = transform.rotation.eulerAngles;
        Vector3 targetRotBody = body.rotation.eulerAngles;

        targetRotBody.y += rotatAmountX;

        transform.rotation = Quaternion.Euler(targetRot);
        body.rotation = Quaternion.Euler(targetRotBody);

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


    /*
        IEnumerator Timer(Animator animator)
        {
            countdown = 5.0f * Time.deltaTime;

            while (countdown >= current) {
                //countdown+= Time.deltaTime*countdown;
                countdown--;
            }
                //countdown = count;
                //Debug.Log (countdown);
            if (countdown <= current && ranger == true) {
                    //Debug.Log ("rangement " + hit.collider.gameObject.name);

                    ranger = false;
                    countdown = 5.0f * Time.deltaTime;;
                    yield return new WaitForSeconds(3);
                    animator.SetBool ("ranger", ranger);
                    animator.Play ("deplacer");
                    Debug.Log (ranger);
                StopCoroutine (Timer (animator));

                    //countdown = 5.0f;
                    //animator.Play ("deplacer");
                    //StopCoroutine (Timer (animator));

                }
            if (countdown <= current && ranger == false) {
                    //StopCoroutine (Timer ());
                    //yield return new WaitForSeconds (2);
                ranger = true;
                Debug.Log(ranger);
                countdown = 5.0f * Time.deltaTime;;
                yield return new WaitForSeconds (3);
                animator.SetBool ("ranger", ranger);
                Debug.Log (ranger);
                StopCoroutine (Timer (animator));

                }


        }*/


}

/*Transform camera = Camera.main.transform;
        Ray ray = new Ray(this.transform.position, this.transform.forward*distanceVue);
        RaycastHit hit;
        PointerEventData data = new PointerEventData(EventSystem.current);
        GameObject obj = null;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "interactible")
            {
                obj = hit.transform.parent.gameObject;
            }
        }
        if (currentObj != obj)
        {
            if (currentObj != null)
            {
                ExecuteEvents.Execute<IPointerExitHandler>(currentObj, data, ExecuteEvents.pointerExitHandler);
            }
            currentObj = obj;
            if (currentObj != null)
            {
                ExecuteEvents.Execute<IPointerEnterHandler>(currentObj, data, ExecuteEvents.pointerEnterHandler);
            }
        }*/