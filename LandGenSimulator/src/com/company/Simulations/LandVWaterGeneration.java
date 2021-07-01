package com.company.Simulations;

import javax.swing.*;
import java.awt.*;
import java.util.Arrays;
import java.util.Random;

public class LandVWaterGeneration {
    public static int[][] runSim(int xDim, int zDim, boolean show, boolean color, int f)
    {
        int world[][] = new int[zDim][xDim];
        for(int z = 0; z < zDim; z++)
        {
            for(int x = 0; x < xDim; x++)
            {
                world[z][x] = 0;
            }
        }
        Random rand = new Random();
        int xx = rand.nextInt(xDim);
        int zz = rand.nextInt(zDim);
        world[zz][xx] = 1;
        world = LandVWaterGeneration3.runSim(world, xx, zz, -1, -1, 0, f, f);
        world = Beach.beachSetter(world);
        if(show)
        {
            if(!color)
            {
                for(int z = 0; z < zDim; z++)
                {
                    System.out.println(Arrays.toString(world[z]));
                }
            }
            else
            {
                JFrame frame = new JFrame();
                frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
                frame.setSize(1000, 1000);
                frame.setLayout(new GridLayout(xDim, zDim));

                for(int z = 0; z < zDim; z++)
                {
                    for(int x = 0; x < xDim; x++)
                    {
                            if(world[z][x] == 0)
                            {
                                JPanel jp = new JPanel();
                                jp.setBackground(Color.BLUE);
                                frame.add(jp);
                            }
                            if(world[z][x] == 1)
                            {
                                JPanel jp = new JPanel();
                                jp.setBackground(Color.GREEN.darker().darker());
                                frame.add(jp);
                            }
                            if(world[z][x] == 2)
                            {
                                JPanel jp = new JPanel();
                                jp.setBackground(Color.GREEN.darker());
                                frame.add(jp);
                            }
                    }
                }

                frame.setVisible(true);
            }
        }

        return world;
    }


}
