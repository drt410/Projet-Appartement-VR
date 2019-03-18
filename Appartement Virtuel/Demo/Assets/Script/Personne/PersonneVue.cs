using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.Playables;

public class PersonneVue : MonoBehaviour {

    public float sensitivity;
    public Transform body;
    public float amount = 1.0f;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
		
       // Cursor.lockState = CursorLockMode.Locked;
        //Rotation();
        RotationCl();

    }

    // Rotation avec clavier seulement
    void RotationCl()
    {

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float deltaX = Input.GetAxisRaw("Horizontal");
        float rotatAmountX = mouseX + deltaX * sensitivity;
        float rotatAmountY = mouseY * sensitivity;
        //float rotatAmountX = deltaX * sensitivity;

        Vector3 targetRot = transform.rotation.eulerAngles;
        Vector3 targetRotBody = body.rotation.eulerAngles;

        targetRot.x -= rotatAmountY;
        targetRotBody.y += rotatAmountX;

        transform.rotation = Quaternion.Euler(targetRot);
        body.rotation = Quaternion.Euler(targetRotBody);
       // print("ok");

        if (Input.GetKeyDown("u") || Input.GetKey("u"))
        {
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
           
            //float rotatAmountX = deltaX + mouseX * sensitivity;
            //float rotatAmountX = deltaX * sensitivity;
             rotatAmountY = amount * sensitivity;

             targetRot = transform.rotation.eulerAngles;
             targetRotBody = body.rotation.eulerAngles;

            targetRot.x -= rotatAmountY;
            //targetRot.y = 0;
            targetRot.z = 0;
            targetRotBody.y += rotatAmountX;

            transform.rotation = Quaternion.Euler(targetRot);
            body.rotation = Quaternion.Euler(targetRotBody);
        }

        if (Input.GetKeyDown("p") || Input.GetKey("p"))
        {
            mouseX = Input.GetAxis("Mouse X");
            mouseY = Input.GetAxis("Mouse Y");
            // float deltaX = Input.GetAxisRaw("Horizontal");
            // float rotatAmountX = deltaX + mouseX * sensitivity;
            //float rotatAmountX = deltaX * sensitivity;
             rotatAmountY = amount * sensitivity;

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
        float rotatAmountX = mouseX + deltaX * sensitivity;
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
