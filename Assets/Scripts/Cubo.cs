using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cubo : MonoBehaviour
{
   
    void Start()
    {
        if(Physics.Raycast(transform.position, transform.up) && Physics.Raycast(transform.position, transform.right))
        {
            Destroy(gameObject);
            GetComponent<MeshRenderer>().enabled = false; 
            GetComponent<BoxCollider>().enabled = false; 
        }
    }


    
}
