﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    // Start is called before the first frame update
    void Start ()
    {
        InvokeRepeating("SpawnDog", 1, 8f);
        InvokeRepeating("SpawnCat", 5, 8f);
    }
	
    // Update is called once per frame
    void Update () {
		
    }

    void SpawnDog()
    {
        GameObject newFollower = Instantiate(Resources.Load<GameObject>("Prefabs/dog"));
        newFollower.transform.position = new Vector3(Random.Range(-2.13f, 8.7f), 0, Random.Range(-3.09f,8.15f));
  
       Quaternion rotation = Quaternion.Euler(0, Random.Range(-180,180), 0);
       newFollower.transform.rotation = rotation;
    }
    
    void SpawnCat()
    {
        GameObject newFollower = Instantiate(Resources.Load<GameObject>("Prefabs/cat"));
        newFollower.transform.position = new Vector3(Random.Range(-2.13f, 8.7f), 0, Random.Range(-3.09f,8.15f));
        
        Quaternion rotation = Quaternion.Euler(0, Random.Range(-180,180), 0);

        
        /*Vector3 randomRot = new Vector3(Random.Range(-2.13f, 8.7f), 0, Random.Range(-3.09f,8.15f));
        Quaternion rotation = Quaternion.LookRotation(randomRot, Vector3.up);*/
        newFollower.transform.rotation = rotation;
       // newFollower.transform.rotation = new Quaternion(0,Random.Range(-180,180),0,0);
    }
}
