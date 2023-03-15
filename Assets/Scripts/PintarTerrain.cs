using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintarTerrain : MonoBehaviour
{
    [System.Serializable]
    public class TexturaAltura
    {
        public int indiceTextura;
        public int alturaInicio;

    }

    public TexturaAltura[] texturaaltura;
    void Start()
    {
       
    }

    
    void Update()
    {
        
    }
    public void PintaTerrain()
    {
        TerrainData terreinData = Terrain.activeTerrain.terrainData;
        float[,,] datosMapa = new float[terreinData.alphamapWidth, terreinData.alphamapHeight, terreinData.alphamapLayers];

        for (int y = 0; y < terreinData.alphamapHeight; y++)
        {
            for (int x = 0; x < terreinData.alphamapWidth; x++)
            {
                float alturaTerreno = terreinData.GetHeight(y, x);

                float[] pinta = new float[texturaaltura.Length];

                for (int i = 0; i < texturaaltura.Length; i++)
                {
                    if (alturaTerreno >= texturaaltura[i].alturaInicio)
                    {
                        pinta[i] = 1;
                    }
                }
               

                for (int j = 0; j < texturaaltura.Length; j++)
                {
                    datosMapa[x, y, j] = pinta[j];
                }

            }
        }

        terreinData.SetAlphamaps(0, 0, datosMapa);
    }

   
}
