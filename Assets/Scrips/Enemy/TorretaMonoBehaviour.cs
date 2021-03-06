﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorretaMonoBehaviour : MonoBehaviour {

    
    public Vector3 origin;
    public Vector3 direction;
    public float maxDistance;
    public LayerMask mask;
    public float distBtRay;
    public int numRay;
    int i;

    public GameObject bullet;
    public float bulletColdown;


    private void Update()
    {
        bulletColdown +=Time.deltaTime;
    }
    private void FixedUpdate()
    {
       

        Vector3 rayPos = transform.position + origin;
        int sing = 1;

        for (i = 0; i <= numRay; i++)
        {
            RaycastHit hit;
            Ray ray = new Ray(rayPos, direction);
            if (Physics.Raycast(ray, out hit, maxDistance, mask))
            {
                if (bulletColdown >= 2)
                {
                    bulletColdown = 0;
                    Instantiate(bullet, transform.position, Quaternion.identity);
                }
                
                
                break;
            }

            rayPos.x += sing * ((i + 1) * distBtRay);
            sing *= -1;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 rayPos = transform.position + origin;
        int sing = 1;

        for (i = 0; i <= numRay; i++)
        {

            Gizmos.DrawRay(rayPos, direction * maxDistance);
            rayPos.x += sing * ((i + 1) * distBtRay);
            sing *= -1;
        }
    }
}