﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
	public int amount = 3;

    // Update is called once per frame
    void Update()
    {
		if ((Input.GetKeyDown(KeyCode.LeftShift)) && amount > 0)
		{
			Vector3 ray = transform.TransformDirection(Vector3.forward);
			RaycastHit hit;
			if (Physics.Raycast(this.transform.position, ray, out hit, 10))
            {
				this.transform.position = hit.point -= this.transform.forward * 1;
			}
            else
			{
				this.transform.position = this.transform.forward * 10;
			}
			amount -= 1;

		}
		
    }
}
