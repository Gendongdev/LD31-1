using UnityEngine;
using System.Collections;

public class ThePrize : WorldObject  {

    public GameManager _GameManager;

	void Start () 
    {
        _GameManager = GameObject.Find("Managers").GetComponent<GameManager>();
        //instance = GameObject.FindGameObjectWithTag("ThePrize").GetComponent<ThePrize>();
        

        //instance = GameObject.FindObjectOfType(typeof(ThePrize)) as ThePrize;	
	}
	
	
	void Update () 
    {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            _GameManager.PrizeGot();              
            Destroy(gameObject);
        }       
       
    }
}
