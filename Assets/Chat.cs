using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Chat : MonoBehaviour
{

    public GameObject Chatmessage;
    public Transform ContentObj;
    void Start(){

    }

    void Update(){

    }

    public void SendChatMessage(){
        Instantiate(Chatmessage, ContentObj);
    }
}






