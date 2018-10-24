﻿using UnityEngine;
using Cinemachine;
using System.Collections;
using System.Collections.Generic;

public class GunControl : MonoBehaviour {

    /* The script name is ironic, get it, 
	 because it's gun control, 
	 but it actually is just for programming gun mechanics, 
	 get it, uh whatever here's the script */

    public float damage = 10f;
    public CinemachineVirtualCamera FPSCam;
    public GameObject gunLight;
	
    void Update () {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
	}

    void Shoot () {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, FPSCam.transform.forward, out hit)){
            // Debug.DrawRay(transform.position, FPSCam.transform.forward * 100, Color.black, 10f, false);
            Debug.Log(hit.transform.name);

            EnemyDamage enemy = hit.transform.GetComponent<EnemyDamage>();
            if (enemy != null) {
                enemy.Damage(damage);
            }
        }
    }
}