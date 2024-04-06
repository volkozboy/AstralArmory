using UnityEngine.Audio;
using System;
using UnityEngine;
using Play;
using Photon.Pun;
public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    PhotonView photonView;
    public static AudioManager Instance;

    void Start(){
        photonView = GetComponent<PhotonView>();
    }
    void Awake()
    {
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.Volume;
            s.source.pitch = s.Pitch;
        }

    }

    
   public void Play(string name)
{
    Sound s = Array.Find(sounds, sound => sound.name == name);
    photonView.RPC("PlayAudioRPC", RpcTarget.All, s.name);
}

[PunRPC]
private void PlayAudioRPC(string soundName)
{
    Sound s = Array.Find(sounds, sound => sound.name == soundName);
    if (s != null)
    {
        s.source.Play();
    }
}
}
