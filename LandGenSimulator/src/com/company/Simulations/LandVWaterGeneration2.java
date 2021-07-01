package com.company.Simulations;

import java.util.Arrays;
import java.util.Random;

public class LandVWaterGeneration2 {
    private static int sum = 1;
    private static int totCount = 0;
    private static Random r = new Random();
    public static int[][] runSim(int[][] world, int xC, int zC, int totSumX, int totSumZ)
    {
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

        if(xC > 0 && world[zC][xC-1] == 1)
        {
            if(waterChecker())
            {
                world[zC][xC-1] = 0;
                totSumX = totSumX - xC + 1;
                totSumZ-=zC;
                System.out.println(totSumZ);
                sum++;
                world = runSim(world, xC-1, zC, totSumX, totSumZ);
            }
        }
        if(xC < world[0].length-1 && world[zC][xC+1] == 1)
        {
            if(waterChecker())
            {
                world[zC][xC+1] = 0;
                totSumX = totSumX - xC - 1;
                totSumZ-=zC;
                System.out.println(totSumZ);
                sum++;
                world = runSim(world, xC+1, zC, totSumX, totSumZ);
            }
        }
        if(zC > 0 && world[zC-1][xC] == 1)
        {
            if(waterChecker())
            {
                world[zC-1][xC] = 0;
                totSumX-=xC;
                totSumZ = totSumZ - zC + 1;
                System.out.println(totSumZ);
                sum++;
                world = runSim(world, xC, zC-1, totSumX, totSumZ);
            }
        }
        if(zC < world.length-1 && world[zC+1][xC] == 1)
        {
            if(waterChecker())
            {
                world[zC+1][xC] = 0;
                totSumX-=xC;
                totSumZ = totSumZ - zC - 1;
                System.out.println(totSumZ);
                sum++;
                world = runSim(world, xC, zC+1, totSumX, totSumZ);
            }
        }
        double sumD = (double) sum;
        double tot = world.length*world[0].length;
        if(sumD/tot < 0.7)
        {/*
            totCount = world.length * world[0].length;
            totCount-=sum;
            int xCoord = totSumX / totCount;
            int zCoord = totSumZ / totCount;
            if(xCoord == world[0].length)
                xCoord--;
            if(zCoord == world.length)
                zCoord--;
                */
            int xCoord = 0;
            int zCoord = 0;
            while(world[zCoord][xCoord] == 0)
            {
                xCoord = r.nextInt(world[0].length);
                zCoord = r.nextInt(world.length);
            }
            if(world[zCoord][xCoord] == 1)
            {
                world[zCoord][xCoord] = 0;
                totSumX-=xCoord;
                totSumZ-=zCoord;
                sum++;
                world = runSim(world, xCoord, zCoord, totSumX, totSumZ);
            }
        }
        return world;
    }

    public static boolean waterChecker()
    {
        Random chance = new Random();
        int roll = chance.nextInt(100);
        if(roll < 1)
            return true;
        else
            return false;
    }
}
