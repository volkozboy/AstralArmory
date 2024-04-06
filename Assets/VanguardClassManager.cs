using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spawner;
using UnityEngine.UI;
using TMPro;

public class VanguardClassManager : MonoBehaviour
{
    public GameObject Vanguardclasses;
    public GameObject ALAYTeams;
    public GameObject VanguardTeams;

    public void VangaurdClassView(){
        Vanguardclasses.SetActive(true);
    }

    public void TeamVisibilityfalse(){
        ALAYTeams.SetActive(false);
        VanguardTeams.SetActive(false);
    }
}