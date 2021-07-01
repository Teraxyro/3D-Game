package com.company;

import com.company.Simulations.Beach;
import com.company.Simulations.BiomeGenerator;
import com.company.Simulations.ChunkInserter;
import com.company.Simulations.LandVWaterGeneration;

import java.util.Random;

public class Main {

    public static void main(String[] args) {
        int world[][] = LandVWaterGeneration.runSim(100, 100, false, true, 125);
        world = BiomeGenerator.createBiomes(world, true,false, 90);
       // ChunkInserter.setWorld(world, world.length, world[0].length, true, 10);
        //ChunkInserter.setWorld(world, 50, 50, false);
    }

}
