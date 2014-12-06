using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

    public float Speed { get; set; }
    public Rigidbody CharacterRigidBody;

    private Vector3 destination;

    void Awake ()
    {
        
    }

	void Start ()
    {
        InputManager.Instance.OnLMBClick += OnLMBClick;
        InputManager.Instance.Ability += Ability;
        InputManager.Instance.OnRMBClick += OnRMBClick;


        destination = transform.position;
        Speed = 0.05f;
        CharacterRigidBody = gameObject.transform.GetComponentInChildren<Rigidbody>();
	}
	

	void FixedUpdate () 
    {
        if(transform.position != destination)
            MoveTo(destination);	
	}

    private void OnLMBClick(Vector3 LclickPoint)
    {
                      
    }

    private void OnRMBClick(Vector3 RclickPoint)
    {
        CharacterRigidBody.velocity = Vector3.zero;
        destination = RclickPoint; 
    }

    private void Ability(char c)
    {

    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Hurter")
            OnDeath();
            
    }

    void MoveTo(Vector3 v3)
    {
        v3.y = 0;        
        CharacterRigidBody.position = Vector3.MoveTowards(transform.position, v3, Speed);
    }

    void OnDeath()
    {
        InputManager.Instance.OnLMBClick -= OnLMBClick;
        InputManager.Instance.Ability -= Ability;
        InputManager.Instance.OnRMBClick -= OnRMBClick;
        Destroy(gameObject);
    }
}
