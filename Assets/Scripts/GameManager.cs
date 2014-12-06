using UnityEngine;
using System.Collections;
using GMnameSpace;
using System.Collections.Generic;


public class GameManager : MonoBehaviour 
{
    public GameObject Player { get; set; }
    public GameObject PlayerPrefab { get; set; }
    public CheckPoint CurrentCheckPoint = new CheckPoint();
    public GUIStyle MainGUIStyle;

    #region Awake,Start and Update
    void Awake ()
    {
        ThePrize.Instance.PrizeGot += PrizeGot;
        CurrentCheckPoint.nextCheckPoint();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        PlayerPrefab = (GameObject)Resources.Load("Player");
    }

    void Update()
    {
        if (Player == null)
        {
            Instantiate(PlayerPrefab, CurrentCheckPoint.PlayerPosition, Quaternion.identity);
            Player = GameObject.FindGameObjectWithTag("Player");
        }
            
    }
    #endregion

    void PrizeGot()
    {
        CurrentCheckPoint.nextCheckPoint();
    }

    void OnGUI ()
    {
        GUI.BeginGroup(new Rect(10, 10, 200, 60));
        GUI.Label(new Rect(0, 00, 200, 20), "CP" + CurrentCheckPoint.CheckPointNum, MainGUIStyle);
        GUI.Label(new Rect(0, 20, 200, 20), "PPos" + CurrentCheckPoint.PlayerPosition, MainGUIStyle);
        GUI.EndGroup();
    }
}
