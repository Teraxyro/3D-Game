package com.company.Simulations;

import javax.swing.*;
import java.awt.*;
import java.util.Arrays;
import java.util.Random;

public class ChunkInserter {

    public static void setWorld(int preChunkInsertion[][], int zLimit, int xLimit, boolean color, int chunkDim)
    {
        Random r = new Random();
        int world[][] = new int[chunkDim*zLimit][chunkDim*xLimit];
        for(int z = 0; z < zLimit; z++)
        {
            for(int x = 0; x < xLimit; x++)
            {
                int cD = r.nextInt(chunkDim);
                for(int cz = 0; cz <cD;cz++)
                {
                    for(int cx = 0; cx < cD; cx++)
                    {
                        int scx = x * cD;
                        int scz = z * cD;
                        world[scz+cz][scx+cx] = preChunkInsertion[z][x];
                    }
                }
            }
        }

        if(!color)
        {
            for(int z = 0; z < zLimit*chunkDim; z++)
            {
                System.out.println(z);
                System.out.println(Arrays.toString(world[z]));
            }
        }
        else
        {
            JFrame frame = new JFrame();
            frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
            frame.setSize(1000, 1000);
            frame.setLayout(new GridLayout(xLimit*chunkDim, zLimit*chunkDim));

            for(int z = 0; z < zLimit*chunkDim; z++)
            {
                for(int x = 0; x < xLimit*chunkDim; x++)
                {
                    if(world[z][x] == 0)
                    {
                        JPanel jp = new JPanel();
                        jp.setBackground(Color.BLUE);
                        jp.setBorder(BorderFactory.createLineBorder(Color.black));
                        frame.add(jp);
                    }
                    if(world[z][x] == 1)
                    {
                        JPanel jp = new JPanel();
                        jp.setBackground(Color.GREEN);
                        jp.setBorder(BorderFactory.createLineBorder(Color.black));
                        frame.add(jp);
                    }
                    if(world[z][x] == -1)
                    {
                        JPanel jp = new JPanel();
                        jp.setBackground(Color.ORANGE);
                        jp.setBorder(BorderFactory.createLineBorder(Color.black));
                        frame.add(jp);
                    }
                }
            }

            frame.setVisible(true);
        }

    }
}
