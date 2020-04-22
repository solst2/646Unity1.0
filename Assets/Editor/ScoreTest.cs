using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;
using NUnit.Framework;

public class ScoreTest 
{
    [Test]
    public void calculate()
    {
        var calculateScore = new CalculateScore();

        var resultat = calculateScore.CalculateTotalPoints(5,0,0);

        

        var scoreAttendu = 50;

        Assert.That(resultat, Is.EqualTo(scoreAttendu));


    }

}
