using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebSiteLink : MonoBehaviour
{
    public void OpenWebsite()
    {
        Application.OpenURL("https://fr.wikipedia.org/wiki/Attention_conjointe");
    }
}
