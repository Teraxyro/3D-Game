using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class printMatrix
{

    public static StringBuilder print(float[,] matrix)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < matrix.GetLength(1); i++)
        {
            for (int j = 0; j < matrix.GetLength(0); j++)
            {
                sb.Append(matrix[i, j]);
                sb.Append(' ');
            }
            sb.AppendLine();
        }
        return sb;
    }
}
