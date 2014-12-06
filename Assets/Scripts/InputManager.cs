using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour 
{
    // Event handler
    public delegate void OnLMBClickEvent(Vector3 LclickPoint);
    public event OnLMBClickEvent OnLMBClick;

    public delegate void OnRMBClickEvent(Vector3 RclickPoint);
    public event OnRMBClickEvent OnRMBClick;

    public delegate void AbilityKeypressedEvent(char a);
    public event AbilityKeypressedEvent Ability;


    //singleton
    private static InputManager instance;

    //constuctor
    private InputManager() { }

    //instance
    public static InputManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType(typeof(InputManager)) as InputManager;

            return instance;
        }
    }




	void Start () 
    {
	
	}
	

	void Update () 
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100))
        {
            if (Input.GetMouseButtonUp(0))
                OnLMBClick(hit.point);

            if (Input.GetMouseButtonDown(1))
                OnRMBClick(hit.point);
        }
	
	}
}