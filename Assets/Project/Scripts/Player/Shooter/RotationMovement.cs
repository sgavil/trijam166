using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMovement : MonoBehaviour
{

    [SerializeField]
    private float rotationBaseSpeed = 0.3f;   
    
    [SerializeField] 
    private float currentRotationSpeed = 0.0f;

    [SerializeField]
    private Transform transformToRotate;

    public void modifyRotationSpeed(float percentageModifier){

        this.currentRotationSpeed = this.rotationBaseSpeed * (1.0f + percentageModifier);

    }
    
    void Start()
    {
        modifyRotationSpeed(0.0f);      
    }

    // Update is called once per frame
    void Update()
    {
        transformToRotate.rotation *= Quaternion.Euler(0,currentRotationSpeed,0);
    }
}
