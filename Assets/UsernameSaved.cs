using TMPro;
using UnityEngine;
using Photon.Pun;

public class UsernameSaved : MonoBehaviourPunCallbacks
{
    public TMP_InputField userName;


    public void SavingName()
    {
        
        
            string enteredText = userName.text;
            if (!string.IsNullOrEmpty(enteredText))
            {
                PlayerPrefs.SetString("PlayerUsername", enteredText); // Save the username with the key "PlayerUsername"
                Debug.Log(enteredText);
            }
            else
            {
                Debug.Log("Username is empty!");
            }
        
    }
}