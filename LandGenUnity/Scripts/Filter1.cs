using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Filter1{

    public static int[,] runSim(int[,] world, int xC, int zC, int totSumX, int totSumZ, int sum, int f, int fO)
    {
        double tot = world.GetLength(0) * world.GetLength(1) - 1;
        if (totSumZ == -1 && totSumX == -1)
        {
            totSumZ = 0;
            totSumX = 0;
            for (int i = 0; i < world.GetLength(0); i++)
            {
                totSumZ += i;
            }
            for (int i = 0; i < world.GetLength(1); i++)
            {
                totSumX += i;
            }
            totSumZ *= world.GetLength(0);
            totSumX *= world.GetLength(1);
        }

        if (xC > 0 && world[zC,xC - 1] == 1)
        {
            if (waterChecker(f))
            {
                world[zC,xC - 1] = -1;
                totSumX = totSumX - xC + 1;
                totSumZ -= zC;
                sum++;
                world = runSim(world, xC - 1, zC, totSumX, totSumZ, sum, f - 1, fO);
            }
        }
        if (xC < world.GetLength(1) - 1 && world[zC,xC + 1] == 1)
        {
            if (waterChecker(f))
            {
                world[zC,xC + 1] = -1;
                totSumX = totSumX - xC - 1;
                totSumZ -= zC;
                sum++;
                world = runSim(world, xC + 1, zC, totSumX, totSumZ, sum, f - 1, fO);
            }
        }
        if (zC > 0 && world[zC - 1,xC] == 1)
        {
            if (waterChecker(f))
            {
                world[zC - 1,xC] = -1;
                totSumX -= xC;
                totSumZ = totSumZ - zC + 1;
                sum++;
                world = runSim(world, xC, zC - 1, totSumX, totSumZ, sum, f - 1, fO);
            }
        }
        if (zC < world.GetLength(1) - 1 && world[zC + 1,xC] == 1)
        {
            if (waterChecker(f))
            {
                world[zC + 1,xC] = -1;
                totSumX -= xC;
                totSumZ = totSumZ - zC - 1;
                sum++;
                world = runSim(world, xC, zC + 1, totSumX, totSumZ, sum, f - 1, fO);
            }
        }
        /*
        if (f == fO && sum / tot < 0.7)
        {
            int totCount = (int)tot - (int)sum;
            int xCoord = totSumX / totCount - 1;
            int zCoord = totSumZ / totCount - 1;

            if (world[zCoord,xCoord] >= 1)
            {
                world[zCoord,xCoord] = -1;
                totSumX -= xCoord;
                totSumZ -= zCoord;
                sum++;
                world = runSim(world, xCoord, zCoord, totSumX, totSumZ, sum, fO - 1, fO);
            }
        }4*/
        return world;
    }

    public static bool waterChecker(int f)
    {
        if (f > 100)
            return true;
        
        int roll = Random.Range(1,100);


        if (roll < f)
            return true;
        else
            return false;
    }
}
