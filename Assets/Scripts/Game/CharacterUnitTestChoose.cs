using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterUnitTestChoose 
{
    //For the unittest, which chrachter is selected
    public string getCharacter(int number)
    {
        string character = "";

        switch (number)
        {
            case 1:
                character = "fairy";
                break;
            case 2:
                character = "astronaut";
                break;
            case 3:
                character = "explorator";
                break;
            case 4:
                character = "train";
                break;

        }

        return character;
    }
}
