using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Navigation : MonoBehaviour
{

    //Back to the Character Scene
    public void BackButton()
    {
        /*superChef.level = 0;
        superChef.actualNiveau = 1;
        //make default
        //default values to the infosNiveau
        for (int i = 0; i < 5; i++)
        {
            superChef.infosNiveau[i] = new Boolean[] { true, true, true, true, true };
        }
        //default Values level
        for (int i = 1; i < 5; i++)
        {
            superChef.pointsPerLevel[i] = new int[] { 0, 0, 0, 0, 0 };
        }*/
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
        TeacherInfo.fromWhere = "ScorePage";
        SceneManager.LoadScene("ChildScene");
    }

    public void BackButtonLogoutTeacher()
    {
        SceneManager.LoadScene("ChildScene");
        TeacherInfo.fromWhere = "Profil";
    }

    public void nextToScore()
    {

        SceneManager.LoadScene("ScorePage1");
    }

    public void backToLanguage()
    {

        SceneManager.LoadScene("Language");
    }

    public void nextNiveau()
    {   
        // at the moment just 3 niveaus are done -> change it to add the next niveau
        for (int i=1;i<4;i++)
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

                    SceneManager.LoadScene("Level" + i + "_1");
                    return;
                }
                levelNotDone++;
            }
            /*
            Debug.Log("niveau" + i);
            int tempScore = 0;
            foreach (int j in superChef.pointsPerLevel[i])
            {
                tempScore += j;
            }
            Debug.Log("tempScore: " + tempScore);
            //0  -> nothing is done in that level start
            if (tempScore == 0)
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
                    SceneManager.LoadScene("Tutorial2");
                    return;
                }

                SceneManager.LoadScene("Level" + i + "_1");
                return;
            }*/
        }

    }

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

    public void GoToLanguage()
    {

        SceneManager.LoadScene("Language");
    }

}
