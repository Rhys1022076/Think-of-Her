using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClamp : MonoBehaviour
{
    //Place this on a camera which will be following an object
	
	//assign target game object to follow in inspector
	[SerializeField]
    private Transform followTarget;

	private void Start()
	{
		//set camera starting position
		transform.position = new Vector3(0f, 0f, -1f);
	}

	void Update()
    {
        //set x,y,z boundaries of camera movement
		transform.position = new Vector3
			(Mathf.Clamp(followTarget.position.x, 0f, 35f), 
			 Mathf.Clamp(followTarget.position.y, 0f, 0f), 
			 Mathf.Clamp(followTarget.position.z, -1f, -1f));
    }
}
