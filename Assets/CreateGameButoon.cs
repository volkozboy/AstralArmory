using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGameButoon : MonoBehaviour
{
    public GameObject createGame;
    public GameObject findGame;
    
    public void CreateMenu(){
        createGame.SetActive(true);
    }
    public void FindFalse(){
        findGame.SetActive(false);
    }
}
