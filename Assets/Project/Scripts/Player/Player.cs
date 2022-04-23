using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  
    List<Fire> shooters;

    // Start is called before the first frame update
    void Start()
    {
        shooters = new List<Fire>(); 

        var childrenShooters = GetComponentsInChildren<Fire>();

        foreach(Fire f in childrenShooters){

            shooters.Add(f);

        }

    }

    void fireAll(){

        var it = 0;
        int itEnd = shooters.Count;

        while(it < itEnd){

            shooters[it].fire();
            it++;
        }

    }

    // Update is called once per frame
    void Update()
    {

      if (Input.GetMouseButtonDown(0)){
                    
          fireAll();

      }

    }
}
