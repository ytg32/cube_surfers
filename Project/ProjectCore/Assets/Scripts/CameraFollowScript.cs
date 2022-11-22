using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowScript : MonoBehaviour
{
    public GameObject player;
    
    // Update is called once per frame
    private void FixedUpdate()
	{
        transform.position = new Vector3(player.transform.position.x + 0.107f , 0.287f, player.transform.position.z - 0.7f);
        transform.forward = player.transform.position - transform.position;
        transform.rotation = Quaternion.Euler(9, -7f, 0);
	}
}

	
