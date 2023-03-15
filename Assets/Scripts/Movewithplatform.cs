using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movewithplatform : MonoBehaviour
{
    CharacterController player;
    public Vector3 groundPosition;
    Vector3 lastgroundPosition;
    public string groundName;
    public string LastGroundName;
  
    public float ancho;
    public Vector3 originOffset;


    Quaternion actualRot;
    Quaternion lastRot;
    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.isGrounded)
        {

            RaycastHit hit;
            if(Physics.SphereCast(transform.position+ originOffset, player.radius / ancho, -transform.up, out hit))
            {
                GameObject groundedIN = hit.collider.gameObject;
                groundName = groundedIN.name;
                groundPosition = groundedIN.transform.position;

                actualRot = groundedIN.transform.rotation;

                if(groundPosition != lastgroundPosition && groundName == LastGroundName) //si se mueve el suelo pero el suelo es el mismo ---
                {
                    this.transform.position += groundPosition - lastgroundPosition;
                    player.enabled = false;
                    player.transform.position = this.transform.position;
                    player.enabled = true;

                }

                if(actualRot != lastRot && groundName == LastGroundName)
                {
                    var newRot = this.transform.rotation * (actualRot.eulerAngles - lastRot.eulerAngles);
                    this.transform.RotateAround(groundedIN.transform.position, Vector3.up, newRot.y);
                }

                lastRot = actualRot;
                LastGroundName = groundName;
                lastgroundPosition = groundPosition;
            }
            //poner todo a 0
            //lastgroundPosition = Vector3.zero;
            //LastGroundName = null;
            //lastRot = Quaternion.Euler(0, 0, 0);
        }
    }

    private void OnDrawGizmos()
    {
        player = this.GetComponent<CharacterController>();
        Gizmos.DrawSphere(transform.position + originOffset, player.radius / ancho);
    }
}
