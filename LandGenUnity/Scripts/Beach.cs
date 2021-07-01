using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beach{

    public static int[,] beachSetter(int[,] world)
    {
        for (int zC = 0; zC < world.GetLength(0); zC++)
        {
            for (int xC = 0; xC < world.GetLength(1); xC++)
            {
                if (xC > 0 && world[zC,xC - 1] == 0 && world[zC,xC] == 1)
                {
                    world[zC,xC] = 2;
                }
                else if (xC < world.GetLength(1) - 1 && world[zC,xC + 1] == 0 && world[zC,xC] == 1)
                {
                    world[zC,xC] = 2;
                }
                else if (zC > 0 && world[zC - 1,xC] == 0 && world[zC,xC] == 1)
                {
                    world[zC,xC] = 2;
                }
                else if (zC < world.GetLength(0) - 1 && world[zC + 1,xC] == 0 && world[zC,xC] == 1)
                {
                    world[zC,xC] = 2;
                }
            }
        }
        return world;
    }
}
