using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{

	void Start () 
    {
        gameObject.rigidbody.AddRelativeForce(Vector3.forward * 200);
        gameObject.rigidbody.AddRelativeTorque(new Vector3(0, 0, 1) * 5);
	
	}
	
	void Update () 
    {
        
	
	}
}
