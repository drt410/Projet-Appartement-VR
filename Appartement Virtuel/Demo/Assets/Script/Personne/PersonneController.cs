using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PersonneMouvement))]
public class PersonneController : MonoBehaviour {

    public float speed = 500.0f;
    public float sensitivity = 30.0f;
    
    private PersonneMouvement perso;

    // Use this for initialization
    void Start()
    {
        perso = GetComponent<PersonneMouvement>();
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        float deltaZ = Input.GetAxisRaw("Vertical");
        float deltaX = Input.GetAxisRaw("Horizontal");

        Vector3 moveHorizontal = transform.right * deltaX;
        Vector3 moveVertical = transform.forward * deltaZ;

        Vector3 velocity = (moveVertical).normalized * speed;

        perso.Move(velocity);

    }

    
}
