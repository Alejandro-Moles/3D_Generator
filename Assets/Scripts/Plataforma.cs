using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public Rigidbody plataformaRB;
    public Transform[] platformPosition;
    public float speed;

    int posicionActual = 0;
    int nextPosition = 1;

    public bool moveTothenext = true;
    public float waittime;

    void Update()
    {
        MovePlatform();
    }

    private void MovePlatform()
    {
        if (moveTothenext)
        {
            StopCoroutine(WaitForMove(0));
            plataformaRB.MovePosition(Vector3.MoveTowards(plataformaRB.position, platformPosition[nextPosition].position, speed * Time.deltaTime));
        }

        if (Vector3.Distance(plataformaRB.position, platformPosition[nextPosition].position) <= 0)
        {
            StartCoroutine(WaitForMove(waittime));
            posicionActual = nextPosition;
            nextPosition = AddNextPosition();
        }

    }

    private int AddNextPosition()
    {
        if(nextPosition +1 >= platformPosition.Length) //si se sale del array devuelbe 0
        {
            return 0;
        }
        else
        {
            return nextPosition+1;
        }
    }

    private IEnumerator WaitForMove(float time)
    {
        moveTothenext = false;
        yield return new WaitForSeconds(time);
        moveTothenext = true;
    }
}
