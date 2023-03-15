using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    public int alto, largo, ancho;
    public GameObject cubo;
    public int detalle;
    public int seed;

    public Material materailAgua, materialmontaña, materialHierva, materialnieve;
    void Start()
    {
        seed = Random.Range(10000, 90000);
        GenerarMapa();
    }

    public void GenerarMapa()
    {
        for (int i = 0; i < largo; i++)
        {
            for (int j = 0; j < ancho; j ++)
            {

                 alto = (int)(Mathf.PerlinNoise(((float)i/1.5f + seed)/detalle, ((float)j/1.5f+seed)/detalle) * detalle);
                Debug.Log(alto);
                for (int k = 0; k < alto; k++)
                {
                    GameObject newCube = Instantiate(cubo, new Vector3(i,k,j), Quaternion.identity);


                    AplicarTextura(newCube, k);

                }
            }
        }
    }

    public void AplicarTextura(GameObject cubo, int altura)
    {
        if (altura < 7 ) {
            cubo.GetComponent<MeshRenderer>().material = materailAgua;
        }
        else if (altura <15)
        {
            cubo.GetComponent<MeshRenderer>().material = materialHierva;
        }
        else if(altura < 25)
        {
            cubo.GetComponent<MeshRenderer>().material = materialmontaña;
        }

        else if (altura < 50)
        {
            cubo.GetComponent<MeshRenderer>().material = materialnieve;
        }
    }
}

