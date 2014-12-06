using UnityEngine;
using System.Collections;

public class ThePrize : WorldObject  {

    public delegate void PrizeGotEvent();
    public event PrizeGotEvent PrizeGot; 

    public GameManager _GameManager;

    //singleton
    private static ThePrize instance;


    public static ThePrize Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType(typeof(ThePrize)) as ThePrize;

            return instance;
        }
    }

	void Start () 
    {
        _GameManager = GameObject.Find("Managers").GetComponent<GameManager>();
	
	}
	
	
	void Update () 
    {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            PrizeGot();              
            Destroy(gameObject);
        }       
       
    }
}
