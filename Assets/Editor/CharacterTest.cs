using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
using System;
using NUnit.Framework;

public class CharacterTest 
{
   [Test]
   public void characterChosen()
    {
        var chooseCharacter = new CharacterUnitTestChoose();

        string personnage = chooseCharacter.getCharacter(1);

        string resultat = "fairy";

        Assert.That(resultat, Is.EqualTo(personnage));
    }

}
