using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabableitem : MonoBehaviour
{
    public bool isPickable = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("coger"))
        {
            other.GetComponent<PickUpObject>().ObjectToPickup = this.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("coger"))
        {
            other.GetComponent<PickUpObject>().ObjectToPickup = null;
        }


    }
}
