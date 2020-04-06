using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildInfo : MonoBehaviour
{
    public string PK_Child { get; private set; }
    string Name;
    string Surname;
    string Score1;
    string Score2;
    string Score3;
    string Score4;
    string Score5;
    string Level;
    string Niveau;
    string FK_Character;

    public void SetChildInfo(string name, string surname, string score1, string score2, string score3, string score4, string score5, string level, string niveau, string fK_Character)
    {
        Name = name;
        Surname = surname;
        Score1 = score1;
        Score2 = score2;
        Score3 = score3;
        Score4 = score4;
        Score5 = score5;
        Level = level;
        Niveau = niveau;
        FK_Character = fK_Character;
    }

    public void SetChildID(string id)
    {
        PK_Child = id;
    }
}
