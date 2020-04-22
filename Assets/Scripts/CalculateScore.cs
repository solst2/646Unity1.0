using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateScore 
{

    public int CalculateTotalPoints(int nbMax, int nbMedium, int nbMin)
    {
        int maxPoint = 10;
        int medium = 5;
        int min = 2;

        

        int points = maxPoint*nbMax + medium*nbMedium + min*nbMin;

        return points;
    }
}
