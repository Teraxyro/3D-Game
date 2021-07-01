package com.company.Simulations;

import java.util.Random;

public class LandVWaterGeneration3 {
    public static int[][] runSim(int[][] world, int xC, int zC, int totSumX, int totSumZ, int sum, int f, int fO)
    {
        double tot = world.length*world[0].length - 1;
        if(totSumZ == -1 && totSumX == -1)
        {
            totSumZ=0;
            totSumX=0;
            for(int i = 0; i < world.length; i++)
            {
                totSumZ+=i;
            }
            for(int i = 0; i < world[0].length; i++)
            {
                totSumX+=i;
            }
            totSumZ*= world[0].length;
            totSumX*= world.length;
        }

        if(xC > 0 && world[zC][xC-1] == 0)
        {
            if(waterChecker(f))
            {
                world[zC][xC-1] = 1;
                totSumX = totSumX - xC + 1;
                totSumZ-=zC;
                sum++;
                world = runSim(world, xC-1, zC, totSumX, totSumZ, sum, f-1, fO);
            }
        }
        if(xC < world[0].length-1 && world[zC][xC+1] == 0)
        {
            if(waterChecker(f))
            {
                world[zC][xC+1] = 1;
                totSumX = totSumX - xC - 1;
                totSumZ-=zC;
                sum++;
                world = runSim(world, xC+1, zC, totSumX, totSumZ, sum, f-1, fO);
            }
        }
        if(zC > 0 && world[zC-1][xC] == 0)
        {
            if(waterChecker(f))
            {

                world[zC-1][xC] = 1;
                totSumX-=xC;
                totSumZ = totSumZ - zC + 1;
                sum++;
                world = runSim(world, xC, zC-1, totSumX, totSumZ, sum, f-1, fO);
            }
        }
        if(zC < world.length-1 && world[zC+1][xC] == 0)
        {
            if(waterChecker(f))
            {
                world[zC+1][xC] = 1;
                totSumX-=xC;
                totSumZ = totSumZ - zC - 1;
                sum++;
                world = runSim(world, xC, zC+1, totSumX, totSumZ, sum, f-1, fO);
            }
        }

        if(f == fO && sum/tot < 0.7)
        {
            int totCount = (int) tot - (int) sum;
            int xCoord = totSumX / totCount - 1;
            int zCoord = totSumZ / totCount - 1;

            if(world[zCoord][xCoord] == 0)
            {
                world[zCoord][xCoord] = 1;
                totSumX-=xCoord;
                totSumZ-=zCoord;
                sum++;
                world = runSim(world, xCoord, zCoord, totSumX, totSumZ, sum, fO-1, fO);
            }
        }
        return world;
    }

    public static boolean waterChecker(int f)
    {
        if(f > 100)
            return true;

        Random chance = new Random();
        int roll = chance.nextInt(100);


        if(roll < f)
            return true;
        else
            return false;
    }
}
