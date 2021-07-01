using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {
    private static int chunkX = 20;
    private static int chunkZ = 20;
    private static int tileSize = 250;
    private static int LOD = 0;
    public static int[,] worldMatrix;
    private static AnimationCurve mapCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(1, 5));
    GameObject[,] World = new GameObject[chunkZ, chunkX];

	// Use this for initialization
	void Start () {
        worldMatrix = LandMatrix.createMatrix(chunkX, chunkZ);
        for(int i = 0; i < worldMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < worldMatrix.GetLength(1); j++)
            {
                GameObject mesh = new GameObject(j + " " + i);
                mesh.AddComponent<MeshFilter>();
                mesh.AddComponent<MeshRenderer>();
                mesh.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Specular"));
                
                int seedVal = Random.Range(1, 100);
                int noiseScale;
                int meshHeightMultiplier;

                if(worldMatrix[i,j] == 1 || worldMatrix[i,j] == 0)
                {
                    noiseScale = 70;
                    meshHeightMultiplier = 5;
                    if(worldMatrix[i,j]==1)
                    {
                        mesh.GetComponent<MeshRenderer>().material.color = Color.green;
                        mesh.transform.position = new Vector3(j * tileSize, 1, i * tileSize);
                    }
                    else
                    {
                        mesh.GetComponent<MeshRenderer>().material.color = Color.blue;
                        mesh.transform.position = new Vector3(j * tileSize, -150, i * tileSize);
                    }
                }
                else
                {
                    noiseScale = 100;
                    meshHeightMultiplier = 30;
                    if (worldMatrix[i, j] == -1)
                    {
                        mesh.GetComponent<MeshRenderer>().material.color = Color.gray;
                        mesh.transform.position = new Vector3(j * tileSize, 1, i * tileSize);
                    }
                    else
                    {
                        mesh.GetComponent<MeshRenderer>().material.color = Color.cyan;
                        mesh.transform.position = new Vector3(j * tileSize, -150, i * tileSize);
                    }
                }
                float[,] noiseMap = Noise.GenerateNoiseMap(tileSize, tileSize, seedVal, noiseScale, 1, 0, 1, new Vector2(Random.Range(1,500), Random.Range(1,500)));
                MeshData meshData = MeshGenerator.GenerateTerrainMesh(noiseMap, meshHeightMultiplier, mapCurve, LOD);
                mesh.GetComponent<MeshFilter>().sharedMesh = meshData.CreateMesh();

                
                World[i, j] = mesh;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent blue cube at the transforms position


        for (int z = 0; z < worldMatrix.GetLength(0); z++)
        {
            for (int x = 0; x < worldMatrix.GetLength(1); x++)
            {
                if (worldMatrix[z, x] == 0)
                {
                    Gizmos.color = Color.blue;
                }
                else if (worldMatrix[z, x] == 2)
                {
                    Gizmos.color = Color.cyan;
                }
                else if (worldMatrix[z, x] == 1)
                {
                    Gizmos.color = Color.green;
                }
                else if (worldMatrix[z, x] == -1)
                {
                    Gizmos.color = Color.gray;
                }

                Gizmos.DrawCube(new Vector3(x, 1, z), new Vector3(1, 1, 1));
            }
        }

    }
}
