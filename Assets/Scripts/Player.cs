using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

    public float Speed { get; set; }
    public Rigidbody CharacterRigidBody;

    public enum CharacterAnimState {idle, movingLeft, movingRight }
    public CharacterAnimState CurrentAnimState;
    public Animator anim;


    private Vector3 destination;



    void Awake ()
    {
        
    }

	void Start ()
    {
        InputManager.Instance.OnLMBClick += OnLMBClick;
        InputManager.Instance.Ability += Ability;
        InputManager.Instance.OnRMBClick += OnRMBClick;

        anim = gameObject.GetComponentInChildren<Animator>();

        destination = transform.position;
        Speed = 0.05f;
        CharacterRigidBody = gameObject.transform.GetComponentInChildren<Rigidbody>();
	}

    void Update()
    {
        anim.SetInteger("state", (int)CurrentAnimState);

    }
    

	void FixedUpdate () 
    {
        if (transform.position != destination)
            MoveTo(destination);
        else
            Idle();
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

    void Idle()
    {
        CurrentAnimState = CharacterAnimState.idle;
    }

    void MoveTo(Vector3 v3)
    {
        if (destination.x < transform.position.x)
            CurrentAnimState = CharacterAnimState.movingLeft;
        else
            CurrentAnimState = CharacterAnimState.movingRight;

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
