using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FeetDetector : MonoBehaviour
{
#if false
	private CharacBehavior cB;
    // Start is called before the first frame update
    void Start()
    {
          cB = GameObject.Find("Personnage").GetComponent<CharacBehavior>(); 
    }

    // Update is called once per frame
    void Update()
    {
    	Debug.DrawRay(gameObject.transform.position, transform.TransformDirection(Vector3.down) *0.2f, Color.red);
    	RaycastHit2D hit = Physics2D.Raycast(gameObject.transform.position, transform.TransformDirection(Vector3.down), 0.2f);
    	if(hit.collider !=null && hit.collider.gameObject.CompareTag("Ground")){
    		cB.isGrounded = true;
    	}
        else{
        	cB.isGrounded = false;
        }
    }
#endif
}
