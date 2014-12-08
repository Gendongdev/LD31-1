using UnityEngine;
using System.Collections;

public class Level : MonoBehaviour {


    public SwitchTrigger[] TriggersInLevel;
    public ThePrize TheLevelsPrize;
    public int TriggersOn;
    

    void Awake()
    {
        TriggersInLevel = GetComponentsInChildren<SwitchTrigger>();
        TheLevelsPrize = GetComponentInChildren<ThePrize>();
        TheLevelsPrize.gameObject.SetActive(false);
        TriggersOn = 0;
        
    }



	void Start ()
    {
	
	}

	void Update () 
    {
        if (TriggersOn == TriggersInLevel.Length)
            TheLevelsPrize.gameObject.SetActive(true);        
	
	}
}
