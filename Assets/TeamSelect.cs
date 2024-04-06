using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spawner;
using UnityEngine.UI;
using TMPro;

public class TeamSelect : MonoBehaviour
{

    public GameObject ALAYClasses;
    public GameObject VanguardClasses;
    
    public Button ALAYButton;
    public Button VanguardButton;

    
    
    public void TeamView(){
        
    }

    public void ClassView(){
        ALAYClasses.SetActive(false);
        VanguardClasses.SetActive(false);
        
    }

}
