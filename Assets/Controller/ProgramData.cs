using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;


public static class ProgramData
{
    public static string fullPath = Application.persistentDataPath + "/profile.txt";
    private static int id;

    private static string[] names;
    private static int[] highestLevels;
    private static int[] shots;
    private static int[] shotsHit;

    public static int Id 
    {
        get 
        {
            return id;
        }
        set 
        {
            id = value;
        }
    }

    public static string[] Names 
    {
        get 
        {
            return names;
        }
        set 
        {
            names = value;
        }
    }

    public static int[] HighestLevels 
    {
        get 
        {
            return highestLevels;
        }
        set 
        {
            highestLevels = value;
        }
    }

    public static int[] Shots 
    {
        get 
        {
            return shots;
        }
        set 
        {
            shots = value;
        }
    }

    public static int[] ShotsHit 
    {
        get 
        {
            return shotsHit;
        }
        set 
        {
            shotsHit = value;
        }
    }

    public static void WriteFile()
    {
        string toWrite="";
        for (int i=0;i<3;i++)
        {
            toWrite+=names[i];
            toWrite+=",";
        }
        for (int i=0;i<3;i++)
        {
            toWrite+=highestLevels[i];
            toWrite+=",";
        }
        for (int i=0;i<3;i++)
        {
            toWrite+=shots[i];
            toWrite+=",";
        }
        for (int i=0;i<3;i++)
        {
            toWrite+=shotsHit[i];
            toWrite+=",";
        }
        File.WriteAllText(fullPath, toWrite);
    }

    public static void fillInfoFromFile()
    {
        string fileContent = File.ReadAllText(fullPath);
        string[] infoFromFile = fileContent.Split(',');

        string[] namesFromFile = new string[3];
        namesFromFile[0] = infoFromFile[0];
        namesFromFile[1] = infoFromFile[1];
        namesFromFile[2] = infoFromFile[2];
        names = namesFromFile;
        int[] highScoresFromFile = new int[3];
        highScoresFromFile[0] = Int32.Parse(infoFromFile[3]);
        highScoresFromFile[1] = Int32.Parse(infoFromFile[4]);
        highScoresFromFile[2] = Int32.Parse(infoFromFile[5]);
        highestLevels = highScoresFromFile;
        int[] shotsFromFile = new int[3];
        shotsFromFile[0] = Int32.Parse(infoFromFile[6]);
        shotsFromFile[1] = Int32.Parse(infoFromFile[7]);
        shotsFromFile[2] = Int32.Parse(infoFromFile[8]);
        shots = shotsFromFile;
        int[] shotsHitFromFile = new int[3];
        shotsHitFromFile[0] = Int32.Parse(infoFromFile[9]);
        shotsHitFromFile[1] = Int32.Parse(infoFromFile[10]);
        shotsHitFromFile[2] = Int32.Parse(infoFromFile[11]);
        shotsHit = shotsHitFromFile;
    }
}



