using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BiomeGenerator
{

    public static int[,] createBiomes(int[,] preWorld, int f)
    {
        int zDim = preWorld.GetLength(0);
        int xDim = preWorld.GetLength(1);
        int[,] world = new int[zDim, xDim];
        for (int z = 0; z < zDim; z++)
        {
            for (int x = 0; x < xDim; x++)
            {
                world[z, x] = 1;
            }
        }

        int xx = Random.Range(1, xDim);
        int zz = Random.Range(1, zDim);
        world[zz, xx] = -1;
        world = Filter1.runSim(world, xx, zz, -1, -1, 0, f, f);

        for (int z = 0; z < zDim; z++)
        {
            for (int x = 0; x < xDim; x++)
            {
                if (world[z, x] == -1 && preWorld[z, x] == 1)
                {
                    preWorld[z, x] = -1;
                }
                else if (world[z, x] == -1 && preWorld[z, x] == 2)
                {
                    preWorld[z, x] = -1;
                }
            }
        }

        return preWorld;
    }
}
