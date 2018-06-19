using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObjet : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;

    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }
    
    private GameObject collidingObject;
    
    private GameObject objectInHand;
    private FixedJoint joint;
    private bool jeter;
    private Rigidbody corps;
    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
    }

    // Update is called once per frame
    void Update () {
        if (Controller.GetHairTrigger())
        {
            if (collidingObject)
            {
                GrabObject();
            }
        }

        //
        else if (Controller.GetHairTriggerUp())
        {
            if (objectInHand)
            {
                ReleaseObject();
            }
        }
    }

  /*  void FixedUpdate()
    {
        Transform origin;
        if(trackedObj.origin != null)
        {
            origin = trackedObj.origin;
        }
        else
        {
            origin = trackedObj.transform.parent;
        }
         if(origin != null)
         {

             objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity*1000;
             objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
             //objectInHand.GetComponent<Rigidbody>().maxAngularVelocity = objectInHand.GetComponent<Rigidbody>().angularVelocity.magnitude;
         }
    }*/

    private void SetCollidingObject(Collider col)
    {
        // 
        if (collidingObject || !col.GetComponent<Rigidbody>())
        {
            return;
        }
        // 
        collidingObject = col.gameObject;
    }

    // 
    public void OnTriggerEnter(Collider other)
    {
        SetCollidingObject(other);
    }

    // 
    public void OnTriggerStay(Collider other)
    {
        SetCollidingObject(other);
    }

    // 
    public void OnTriggerExit(Collider other)
    {
        if (!collidingObject)
        {
            return;
        }

        collidingObject = null;
    }

    private void GrabObject()
    {
        // 
        objectInHand = collidingObject;
        collidingObject = null;
        // 
        joint = AddFixedJoint();
        joint.connectedBody = objectInHand.GetComponent<Rigidbody>();
        jeter = false;
        corps = null;
    }

    // 
    private FixedJoint AddFixedJoint()
    {
        FixedJoint fx = gameObject.AddComponent<FixedJoint>();
        fx.breakForce = 20000;
        fx.breakTorque = 20000;
        return fx;
    }

    private void ReleaseObject()
    {
        // 
        if (GetComponent<FixedJoint>())
        {
            GetComponent<FixedJoint>().connectedBody =null;
            // 
            Destroy(GetComponent<FixedJoint>());
            jeter = true;
            // 
            objectInHand.GetComponent<Rigidbody>().velocity = Controller.velocity;
            objectInHand.GetComponent<Rigidbody>().angularVelocity = Controller.angularVelocity;
        }
        // 
        objectInHand = null;
    }
}
