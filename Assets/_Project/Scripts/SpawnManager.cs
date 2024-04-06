using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Play;
using UnityEngine.UI;

namespace Spawner
{
    public class SpawnManager : MonoBehaviour
    {
        public GameObject SupportPrefab;
        public GameObject AssaultPrefab;
        public GameObject TankPrefab;

        public GameObject VanguardSupportPrefab;
        public GameObject VanguardAssaultPrefab;
        public GameObject VanguardTankPrefab;

        public Transform ALAYSpawnPoint;
        public Transform VanguardSpawnPoint;

        public GameObject TeamrViewAlay;
        public GameObject TeamrViewVan;

        public GameObject[] Spawns;
        
        public bool classSelected = false;


        void Start(){
        ALAYSpawnPoint = GameObject.FindGameObjectWithTag("ALAYTag").transform;
        VanguardSpawnPoint = GameObject.FindGameObjectWithTag("VanguardTag").transform;

        TeamrViewAlay = GameObject.FindGameObjectWithTag("ALAYTagTeam");
        TeamrViewVan = GameObject.FindGameObjectWithTag("VanTagTeam");

        }
        public void SupportSpawning()
        {
            if (!classSelected && PhotonNetwork.IsConnected)
            {
                classSelected = true;
                int randomIndex = Random.Range(0, Spawns.Length);
                PhotonNetwork.Instantiate(SupportPrefab.name, Spawns[randomIndex].transform.position, Quaternion.identity);
                FindObjectOfType<TeamSelect>().ClassView();
                FindObjectOfType<TeamSelect>().TeamView();
                FindObjectOfType<CURSORMode>().Camactive = false;
                FindObjectOfType<CameraMove>().MouseSense = FindObjectOfType<Sensitivity>().sense;
                StartCoroutine(ClassDelay());
                TeamrViewAlay.SetActive(true);
                TeamrViewVan.SetActive(true);
            }
        }

        public void AssaultSpawning()
        {
            if (!classSelected && PhotonNetwork.IsConnected)
            {
                classSelected = true;
                int randomIndex = Random.Range(0, Spawns.Length);
                PhotonNetwork.Instantiate(AssaultPrefab.name, Spawns[randomIndex].transform.position, Quaternion.identity);
                FindObjectOfType<TeamSelect>().ClassView();
                FindObjectOfType<TeamSelect>().TeamView();
                FindObjectOfType<CURSORMode>().Camactive = false;
                FindObjectOfType<CameraMove>().MouseSense = FindObjectOfType<Sensitivity>().sense;
                StartCoroutine(ClassDelay());
                TeamrViewAlay.SetActive(true);
                TeamrViewVan.SetActive(true);
            }
        }

        public void TankSpawning()
        {
            if (!classSelected && PhotonNetwork.IsConnected)
            {
                classSelected = true;
                int randomIndex = Random.Range(0, Spawns.Length);
                PhotonNetwork.Instantiate(TankPrefab.name, Spawns[randomIndex].transform.position, Quaternion.identity);
                FindObjectOfType<TeamSelect>().ClassView();
                FindObjectOfType<TeamSelect>().TeamView();
                FindObjectOfType<CURSORMode>().Camactive = false;
                FindObjectOfType<CameraMove>().MouseSense = FindObjectOfType<Sensitivity>().sense;
                StartCoroutine(ClassDelay());
                TeamrViewAlay.SetActive(true);
                TeamrViewVan.SetActive(true);
            }
        }






        
        public void VanguardSupportSpawning()
        {
            if (!classSelected && PhotonNetwork.IsConnected)
            {
                classSelected = true;
                int randomIndex = Random.Range(0, Spawns.Length);
                PhotonNetwork.Instantiate(VanguardSupportPrefab.name, Spawns[randomIndex].transform.position, Quaternion.identity);
                FindObjectOfType<TeamSelect>().ClassView();
                FindObjectOfType<TeamSelect>().TeamView();
                FindObjectOfType<CURSORMode>().Camactive = false;
                FindObjectOfType<CameraMove>().MouseSense = FindObjectOfType<Sensitivity>().sense;
                StartCoroutine(ClassDelay());
                TeamrViewVan.SetActive(true);
                TeamrViewAlay.SetActive(true);
            }
        }

        public void VanguardAssaultSpawning()
        {
            if (!classSelected && PhotonNetwork.IsConnected)
            {
                classSelected = true;
                int randomIndex = Random.Range(0, Spawns.Length);
                PhotonNetwork.Instantiate(VanguardAssaultPrefab.name, Spawns[randomIndex].transform.position, Quaternion.identity);
                FindObjectOfType<TeamSelect>().ClassView();
                FindObjectOfType<TeamSelect>().TeamView();
                FindObjectOfType<CURSORMode>().Camactive = false;
                FindObjectOfType<CameraMove>().MouseSense = FindObjectOfType<Sensitivity>().sense;
                StartCoroutine(ClassDelay());
                TeamrViewVan.SetActive(true);
                TeamrViewAlay.SetActive(true);
            }
        }

        public void VanguardTankSpawning()
        {
            if (!classSelected && PhotonNetwork.IsConnected)
            {
                classSelected = true;
                int randomIndex = Random.Range(0, Spawns.Length);
                PhotonNetwork.Instantiate(VanguardTankPrefab.name, Spawns[randomIndex].transform.position, Quaternion.identity);
                FindObjectOfType<TeamSelect>().ClassView();
                FindObjectOfType<TeamSelect>().TeamView();
                FindObjectOfType<CURSORMode>().Camactive = false;
                FindObjectOfType<CameraMove>().MouseSense = FindObjectOfType<Sensitivity>().sense;
                StartCoroutine(ClassDelay());
                TeamrViewVan.SetActive(true);
                TeamrViewAlay.SetActive(true);
            }
        }

        IEnumerator ClassDelay(){
            yield return new WaitForSeconds(2);
            classSelected = false;
        }
    }
}