using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindGameButoon : MonoBehaviour
{
    public GameObject findGame;
    public GameObject createGame;
    
    public void FindMenu(){
        findGame.SetActive(true);
    }
    public void CreateFalse(){
        createGame.SetActive(false);
    }
}
