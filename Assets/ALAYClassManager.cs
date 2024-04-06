using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spawner;
using UnityEngine.UI;
using TMPro;

public class ALAYClassManager : MonoBehaviour
{
    public GameObject ALAYclasses;
    public GameObject ALAYTeams;
    public GameObject VanguardTeams;

    public void ALAYClassView(){
        ALAYclasses.SetActive(true);
    }

    public void TeamVisibilityfalse(){
        ALAYTeams.SetActive(false);
        VanguardTeams.SetActive(false);
    }
}