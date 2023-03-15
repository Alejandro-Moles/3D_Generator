using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    public Vector3 offset; // distancia al jugador
    private Transform target;
    [Range(0,1)] public float lerpValue; // velociada camara
    public float sensibilidad;
    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate() // se actualiza al final de cada frame
    {
        transform.position = Vector3.Lerp(transform.position,target.position + offset, lerpValue);

        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * sensibilidad, Vector3.up) * offset;

        transform.LookAt(target);
    }
}
