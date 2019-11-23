using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
	public int amount = 10;

    // Update is called once per frame
    void Update()
    {
		//checks for shift key input, and sees if player has any dashes left.
        if ((Input.GetKeyDown(KeyCode.LeftShift)) && amount > 0)
		{
			//shoots a ray forward the direction and distance of the dash to see if something is there.
            Vector3 ray = transform.TransformDirection(Vector3.forward);
			RaycastHit hit;
			//if it hits something before getting to the distance, it teleports a set distance before the point.
            if (Physics.Raycast(this.transform.position, ray, out hit, 5))
            {
				this.transform.position = hit.point -= this.transform.forward * 1;
			}
            //If it doesn't hit anything, it teleports the set distance. 
            else
			{
				this.transform.position = this.transform.forward * 5;
			}
			//each time it teleports, it takes away a set number of charges.
            amount -= 1;

		}
		
    }
}
