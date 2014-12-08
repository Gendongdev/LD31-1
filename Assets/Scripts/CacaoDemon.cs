using UnityEngine;
using System.Collections;

public class CacaoDemon : MonoBehaviour 
{

     
    public float Speed { get; set; }
    public GameObject Target { get; set;}
    public Vector3 TargetPosition { get; set; }
    public Rigidbody CharacterRigidBody { get; set; }
    public Animator anim;
    public int StartClip;

    private Vector3 InitialPos;

    void Awake()
    {
        Speed = 0.03f;
        CharacterRigidBody = gameObject.transform.GetComponentInChildren<Rigidbody>();
        anim = gameObject.GetComponentInChildren<Animator>();
        StartClip = Animator.StringToHash("Base Layer.CacaoDemonEmerging");

    }

    void OnEnable()
    {
        InitialPos = transform.position;
    }

	void Start () 
    {

	}
	

	void Update ()
    {
        if (Target == null)
        {
            anim.Play(StartClip);
            transform.position = InitialPos;
            Target = GameObject.FindGameObjectWithTag("Player");
        }
        else
        {
            TargetPosition = Target.transform.position;
            MoveTo(TargetPosition);
        }


	}


    void MoveTo(Vector3 v3)
    {
        v3.y = 0;        
        CharacterRigidBody.position = Vector3.MoveTowards(transform.position, v3, Speed);
    }

}
