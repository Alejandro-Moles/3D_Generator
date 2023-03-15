using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorTerrenos : MonoBehaviour
{

    
    public TerrainData terrenoData;
    public Terrain terreno;
    private float[,] matriz;

    public int detalle = 50;
    public int seed = 0;

    public PintarTerrain pinta;


    void Start()
    {

        pinta.GetComponent<PintarTerrain>();

        matriz = new float[513, 513];
        GeneradorAltura();


        
        //aplicar la matriz al terreno

        terrenoData.SetHeights(0, 0, matriz);

        pinta.PintaTerrain();
        PintaArboles();
    }

    public void GeneradorAltura()
    {
        for (int i = 0; i < terrenoData.heightmapResolution; i++)
        {
            for (int j = 0; j < terrenoData.heightmapResolution; j++)
            {

                matriz[i, j] = Mathf.PerlinNoise(((float)i + seed)/detalle , ((float)j + seed) / detalle);
                
                
            }
        }
    }

    void PintaArboles()
    {
       

        float minX = 0f;
        float maxX = 100;
        float minZ = 0f;
        float maxZ = 100f;

        for (int i = 0; i < 50; i++) //50 arboles
        {
            float x = Random.Range(minX, maxX);
            float z = Random.Range(minZ, maxZ);
            float y = terreno.terrainData.GetInterpolatedHeight(x, z);

            TreeInstance arboles = new TreeInstance();
            arboles.position = new Vector3(x, y, z); //y tiene que ser la altura del terreno
            arboles.prototypeIndex = Random.Range(0, 3);
            arboles.widthScale = 20;
            arboles.heightScale = 20;
            arboles.color = Color.white;
            arboles.lightmapColor = Color.white;

            Debug.Log("Árbol agregado en posición: " + arboles.position);
            terreno.AddTreeInstance(arboles);
        }

    }
}
