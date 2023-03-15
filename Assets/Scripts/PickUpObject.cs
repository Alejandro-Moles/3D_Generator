using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    public GameObject ObjectToPickup;
    public GameObject PicketObject;
    
    public Transform mochila;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ObjectToPickup != null && ObjectToPickup.GetComponent<Grabableitem>().isPickable && PicketObject == null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PicketObject = ObjectToPickup;
                PicketObject.GetComponent<Grabableitem>().isPickable = false;
                PicketObject.transform.SetParent(mochila); //que sea hijo
                PicketObject.transform.position = mochila.position; // ponga en la posicion
                PicketObject.GetComponent<Rigidbody>().useGravity = false;
                PicketObject.GetComponent<Rigidbody>().isKinematic = true;

            }
        }
        else if(PicketObject != null)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                PicketObject.GetComponent<Grabableitem>().isPickable = true;
                PicketObject.transform.SetParent(null);
                PicketObject.GetComponent<Rigidbody>().useGravity = true;
                PicketObject.GetComponent<Rigidbody>().isKinematic = false;
                PicketObject = null;
            }

        }
    }
}
