﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{
    //Back to the Character Scene
    public void BackButton()
    {
        //Niveau 2 Gender
        System.Random r = new System.Random();
        int random = r.Next(0, 2);
        Debug.Log("random: " + random);
        if (random == 1)
        {
            superChef.gender = "boy";
        }
        SceneManager.LoadScene("ScorePage1");
    }

    public void BackButtonScorePage()
    {
        Debug.Log("Offline?" + superChef.offline);
        if (!superChef.offline)
        {
            TeacherInfo.fromWhere = "ScorePage";
            SceneManager.LoadScene("ChildScene");

            /*//If we logged in correctly
            Main.Instance.TeacherProfile.SetActive(true);
            Main.Instance.Login.gameObject.SetActive(false);*/
        } else
        {
            TeacherInfo.fromWhere = "ScorePageOffline";
            SceneManager.LoadScene("ChildScene");
        }
    }

    //Play the game offline
    public void Offline()
    {
        superChef.offline = true;
        String[] strlist = { "Offline", "Offline", "0-0-0-0-0", "0-0-0-0-0", "0-0-0-0-0", "0-0-0-0-0", "0-0-0-0-0", "0", "0", "1" };
        //fill informations
        superChef.childname = strlist[0];
        superChef.childsurname = strlist[1];
        superChef.score[0] = strlist[2];
        superChef.score[1] = strlist[3];
        superChef.score[2] = strlist[4];
        superChef.score[3] = strlist[5];
        superChef.score[4] = strlist[6];
        superChef.levelDB = strlist[7];
        superChef.niveau = strlist[8];
        superChef.fk_Character = strlist[9];

        //new infos
        for (int i = 1; i < 5; i++)
        { 
            try
            {
                Debug.Log("Offline in try: " + i);
                superChef.pointsPerLevel.Add(i, new int[] { 0,0,0,0,0});
            }
            catch (Exception e)
            {
                Debug.Log("Offline begin of catch: " + i);
                superChef.pointsPerLevel[i] = new int[] { 0,0,0,0,0};
                Debug.Log("Offline end of catch: " + i);
            }
        }
        superChef.level = Int32.Parse(strlist[7]);
        superChef.actualNiveau = Int32.Parse(strlist[8]);
        //change to real version, this switch case is just to try
        System.Random r = new System.Random();
        int random = r.Next(0, 4);

        switch (random)
        {
            case 0:
                superChef.character = "Astronaut";
                break;
            case 1:
                superChef.character = "explorateur";
                break;
            case 2:
                superChef.character = "HuaYao_01";
                break;
            case 3:
                superChef.character = "trainChief";
                break;
            default:
                superChef.character = "Astronaut";
                break;
        }
        superChef.dataloaded = true;

        //go to the Score page directly
        SceneManager.LoadScene("ScorePage1");

    }

    //Logout -> go to Login
    public void BackButtonLogoutTeacher()
    {
        SceneManager.LoadScene("ChildScene");
        TeacherInfo.fromWhere = "Profil";
    }

    //Load the score of a child
    public void nextToScore()
    {

        SceneManager.LoadScene("ScorePage1");
    }

    //Select a language
    public void backToLanguage()
    {

        SceneManager.LoadScene("Language");
    }

    //start the next niveau
    public void nextNiveau()
    {   
        // at the moment just 4 niveaus are done -> change it to add the next niveau
        for (int i=1;i<5;i++)
        {
            Debug.Log("niveau" + i);
            int levelNotDone = 0;
            foreach (int j in superChef.pointsPerLevel[i])
            {
                //level in the niveau is not done 
                if (j==0)
                {
                    superChef.actualNiveau = i;
                    superChef.level = levelNotDone;

                    if (i == 1 && ScriptTuto1.tutoplayed == 0)
                    {
                        SceneManager.LoadScene("Tutorial1");
                        return;
                    }
                    if (i == 2 && Tuto2.tutoplayed == 0)
                    {
                        SceneManager.LoadScene("Tutorial2");
                        return;
                    }
                    if (i == 3 && tuto3.tutoplayed == 0)
                    {
                        SceneManager.LoadScene("Tutorial3");
                        return;
                    }
                    if (i == 4)
                    {
                        SceneManager.LoadScene("Level4_1");
                        return;
                    }

                    SceneManager.LoadScene("Level" + i + "_"+ levelNotDone);
                    return;
                }
                levelNotDone++;
            }
        }

    }

    //Start a new scene -> with scene id, start the tutorial yes / no
    public void goToScene(int i)
    {
        superChef.actualNiveau = i;
        superChef.level = 0;
        if (i == 1 && ScriptTuto1.tutoplayed == 0)
        {
            SceneManager.LoadScene("Tutorial1");
            return;
        }
        if (i == 2 && Tuto2.tutoplayed == 0)
        {
            SceneManager.LoadScene("Tutorial2");
            return;
        }
        if (i == 3 && tuto3.tutoplayed == 0)
        {
            SceneManager.LoadScene("Tutorial3");
            return;
        }
        SceneManager.LoadScene("Level"+i+"_1");
    }

    //select language
    public void GoToLanguage()
    {
        SceneManager.LoadScene("Language");
    }

    //go to a website
    public void OpenWebsite()
    {
        Application.OpenURL("https://fr.wikipedia.org/wiki/Attention_conjointe");
    }

}
