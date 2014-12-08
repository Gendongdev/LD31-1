using UnityEngine;
using System.Collections;

public class SwitchTrigger : MonoBehaviour {

    public bool SwitchOn;
    public Color initialColor;
    public SpriteRenderer SpriteRenderer;
    public Sprite OffSprite;
    public Sprite OnSprite;

    public GameObject Player;

	void Start () 
    {
        SwitchOn = false;
        initialColor = renderer.material.color;
	    SpriteRenderer = GetComponentInChildren<SpriteRenderer>();
	}
	
	void Update () 
    {
        if (SwitchOn)
            SpriteRenderer.sprite = OnSprite;
        else
            SpriteRenderer.sprite = OffSprite;

        if(Player == null)
        {
            SwitchOn = false;
            gameObject.GetComponentInParent<Level>().TriggersOn = 0;
            Player = GameObject.FindGameObjectWithTag("Player");
        }
            
	
	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Projectile")
        {
            if (SwitchOn == false)
            {
                SwitchOn = true;
                gameObject.GetComponentInParent<Level>().TriggersOn++;
            }
            Destroy(col.gameObject);
        }
            
    }
}
