﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public Rigidbody rigidBody;
	public int speed;
	
	private Vector3 direction;
	
	public void CreateBullet(Vector3 direction)
	{
		this.direction = direction;
	}
	
	private void Update ()
	{
		Vector3 newRot = new Vector3(0, direction.y, 0);
		if (newRot != Vector3.zero)
		{
			this.transform.rotation = Quaternion.LookRotation(newRot);	
		}
;		//this.transform.Translate(new Vector3(this.direction.x, 0, this.direction.z));
		this.rigidBody.velocity = direction * speed * Time.deltaTime;
	}
}
