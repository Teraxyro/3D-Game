package com.company.Simulations;

public class Beach {
    public static int[][] beachSetter(int[][] world)
    {
        for(int zC = 0; zC < world.length; zC++)
        {
            for(int xC = 0; xC < world[0].length; xC++)
            {
                if(xC > 0 && world[zC][xC-1] == 0 && world[zC][xC] == 1)
                {
                    world[zC][xC] = 2;
                }
                else if(xC < world[0].length-1 && world[zC][xC+1] == 0 && world[zC][xC] == 1)
                {
                    world[zC][xC] = 2;
                }
                else if(zC > 0 && world[zC-1][xC] == 0 && world[zC][xC] == 1)
                {
                    world[zC][xC] = 2;
                }
                else if(zC < world.length-1 && world[zC+1][xC] == 0 && world[zC][xC] == 1)
                {
                    world[zC][xC] = 2;
                }
            }
        }
        return world;
    }
}
