using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    private static int[,] matrix;
	// Use this for initialization
	void Start () {
        matrix = LandMatrix.createMatrix(4, 4);
    }
	
    void OnDrawGizmosSelected()
    {
        // Draw a semitransparent blue cube at the transforms position
        

        for (int z = 0; z < matrix.GetLength(0); z++)
        {
            for (int x = 0; x < matrix.GetLength(1); x++)
            {
                if (matrix[z, x] == 0)
                {
                    Gizmos.color = Color.blue;
                }
                else if (matrix[z, x] == 2)
                {
                    Gizmos.color = Color.cyan;
                }
                else if (matrix[z, x] == 1)
                {
                    Gizmos.color = Color.green;
                }
                else if (matrix[z, x] == -1)
                {
                    Gizmos.color = Color.gray;
                }

                Gizmos.DrawCube(new Vector3(x, 1, z), new Vector3(1, 1, 1));
            }
        }

    }
}
