using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LandMatrix : MonoBehaviour {

    public static int[,] createMatrix(int x, int z)
    {
        int[,] world = LandVWaterGeneration.runSim(x, z, 125, -1, -1);
        world = BiomeGenerator.createBiomes(world, 90);
        return world;
    }

    public static int[,] createMatrix(int x, int z, int[,,] surroundingMatrices, int[,] directionMatrix)
    {
        return null;
    }
}
