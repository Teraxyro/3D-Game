using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    public int chunkX =250;
    public int chunkZ = 250;
    public int tileSize = 250;
    private static int LOD = 0;
    public static int[,] worldMatrix;
    private static AnimationCurve mapCurve = new AnimationCurve(new Keyframe(0, 0), new Keyframe(0.1f, 0.05f), new Keyframe(0.2f, 0.2f), new Keyframe(0.4f, 0.8f), new Keyframe(1, 5));
    private GameObject[,] World;
    private float[,] noiseMap;
    private static float oX = 0;
    private static float oY = 0;
    private static Vector2 offset = new Vector2(oX, oY);

    // Use this for initialization
    void Start()
    {
        GenerateMap();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GenerateMap()
    {
        World = new GameObject[tileSize, tileSize];
        worldMatrix = LandMatrix.createMatrix(tileSize, tileSize);
        /*
        int seedVal = Random.Range(1, 100);
        int noiseScale = 85;
        float[,] noiseMap = Noise.GenerateNoiseMap(worldMatrix, tileSize*chunkX, tileSize*chunkZ, seedVal, noiseScale, 1, 0, 1, new Vector2(Random.Range(1, 500), Random.Range(1, 500)));
        */
        GameObject mesh = new GameObject("bruh");
        mesh.AddComponent<MeshFilter>();
        mesh.AddComponent<MeshRenderer>();
        mesh.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Specular"));
        int seedVal = Random.Range(1, 100);
        float[,] noiseMap = Noise.GenerateNoiseMap(worldMatrix, tileSize, tileSize, seedVal, 40, 1, 0, 1, offset);
        mesh.GetComponent<MeshRenderer>().material.color = Color.gray;
        MeshData meshData = MeshGenerator.GenerateTerrainMesh(noiseMap, 20, mapCurve, LOD);
        mesh.GetComponent<MeshFilter>().sharedMesh = meshData.CreateMesh();
        /*
        for (int i = 0; i < 1; i++)
        {
            for (int j = 0; j < 1; j++)
            {

                GameObject mesh = new GameObject(j + " " + i);
                mesh.AddComponent<MeshFilter>();
                mesh.AddComponent<MeshRenderer>();
                mesh.GetComponent<MeshRenderer>().material = new Material(Shader.Find("Specular"));

                int seedVal = Random.Range(1, 100);
                int noiseScale;
                int meshHeightMultiplier;
                noiseScale = 70;
                meshHeightMultiplier = 5;

                if (worldMatrix[i, j] == 1 || worldMatrix[i, j] == 0)
                {
                    noiseScale = 70;
                    meshHeightMultiplier = 5;
                    if (worldMatrix[i, j] == 1)
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
                offset.x += 2.5f;

                float[,] noiseMap = Noise.GenerateNoiseMap(tileSize, tileSize, 0, 50, 1, 0, 1, offset);
                Debug.Log(noiseMap.GetLength(0));
                MeshData meshData = MeshGenerator.GenerateTerrainMesh(noiseMap, meshHeightMultiplier, mapCurve, LOD);
                mesh.GetComponent<MeshFilter>().sharedMesh = meshData.CreateMesh();


                World[i, j] = mesh;

            }
            offset.y += 2.5f;
            offset.x = 0;
        }
        */
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
