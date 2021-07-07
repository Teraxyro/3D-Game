using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandVWaterGeneration{

    public static int[,] runSim(int xDim, int zDim, int f, int xv, int zv)
    {
        int[,] world = new int[zDim,xDim];
        for(int z = 0; z<zDim; z++)
        {
            for(int x = 0; x<xDim; x++)
            {
                world[z,x] = 0;
            }
        }
        int xx = xv;
        int zz = zv;

        if(xx == -1 && zz == -1)
        {
            xx = Random.Range(1, xDim);
            zz = Random.Range(1, zDim);
        }
        world[zz,xx] = 1;
        world = LandVWaterGeneration3.runSim(world, xx, zz, -1, -1, 0, f, f);
        world = Beach.beachSetter(world);
       
        return world;
    }
}
