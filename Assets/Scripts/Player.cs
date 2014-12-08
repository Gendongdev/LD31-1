using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{

    public float Speed { get; set; }
    public Rigidbody CharacterRigidBody;

    public GameObject Projectile;
    public Quaternion rotation;
    public enum CharacterAnimState {idle, movingLeft, movingRight }
    public CharacterAnimState CurrentAnimState;
    public Animator anim;
    public bool CanThrowMagic;

    private Vector3 destination;
    private Vector3 castPoint;


    void Awake ()
    {
        
    }

	void Start ()
    {
        InputManager.Instance.OnLMBClick += OnLMBClick;
        InputManager.Instance.Ability += Ability;
        InputManager.Instance.OnRMBClick += OnRMBClick;

        anim = gameObject.GetComponentInChildren<Animator>();
        Projectile = (GameObject)Resources.Load("Projectile");
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
        if (CanThrowMagic)
        {
            castPoint = LclickPoint;
            CastAtPoint(castPoint);        
        }
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

    void CastAtPoint(Vector3 v3)
    {

        float xDif = v3.x - transform.position.x;
        float zDif = v3.z - transform.position.z;

        if (zDif < 0)
            rotation.eulerAngles = new Vector3(0, ((Mathf.Atan(xDif / zDif)) * Mathf.Rad2Deg) - 180, 0);
        else
            rotation.eulerAngles = new Vector3(0, (Mathf.Atan(xDif / zDif)) * Mathf.Rad2Deg, 0);
        
        
        
        //rotation.eulerAngles = new Vector3(0, (Mathf.Atan(xDif / zDif)) * Mathf.Rad2Deg, 0);
        Vector3 offset = new Vector3(0,0.5f,0);
        Instantiate(Projectile, transform.position + offset, rotation);
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
