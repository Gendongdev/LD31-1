using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour 
{
    


    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(6.0f);
        Destroy(gameObject);
    }

    IEnumerator SetAsColliderAfterTime()
    {
        yield return new WaitForSeconds(0.1f);
        gameObject.collider.isTrigger = false;
    }

    void Awake()
    {
        

    }

	void Start () 
    {
        gameObject.rigidbody.AddRelativeForce(Vector3.forward * 200);
        //gameObject.rigidbody.AddRelativeTorque(new Vector3(0, 0, 1) * 5);
        StartCoroutine(DestroyAfterTime());
        	
	}



}
