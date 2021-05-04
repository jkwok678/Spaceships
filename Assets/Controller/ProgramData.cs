using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public static class ProgramData
{
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
}



