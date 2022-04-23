using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public uint m_MaxHP = 0;
    public float m_Speed = 0.0F;

    private uint m_CurrentHP;

    private Transform m_playerTransform;
    private Rigidbody m_rigidBody;

    private Vector3 m_lastTarget;
    private Color debugColor;
    private void getNewTargetPoint(){

        Vector3 m_playerPosition = m_playerTransform.position; 
        Vector3 selfPosition = transform.position;

        var sphereCenter = Vector3.Lerp(selfPosition, m_playerPosition, 0.5f);
        var sphereRadius = Vector3.Distance(sphereCenter, selfPosition) * 0.5f;

        m_lastTarget = sphereCenter + Random.insideUnitSphere * sphereRadius;
        m_lastTarget.y = m_playerPosition.y; 

    }

    private void Start()
    {
        if (m_MaxHP == 0 || m_Speed == 0)
        {
            Debug.LogError("Failed to initialize enemy");
        }
        m_CurrentHP = m_MaxHP;
        m_rigidBody = GetComponent<Rigidbody>();
        m_playerTransform = FindObjectOfType<Player>().gameObject.transform;
        m_lastTarget = m_playerTransform.position;
        debugColor = Random.ColorHSV();
        getNewTargetPoint();
    }

    

    private void Update()
    {
        Vector3 m_playerPosition = m_playerTransform.position;        
        Vector3 selfPosition = transform.position;

        float distanceToPlayer = Vector3.Distance(selfPosition, m_playerPosition);
        float distanceToTarget = Vector3.Distance(selfPosition, m_lastTarget);

        if( distanceToPlayer > 2.0f){

            if(distanceToTarget <= 0.5f){

                getNewTargetPoint();
            }
                  
        }

        Debug.DrawLine(selfPosition, m_lastTarget, debugColor, Time.deltaTime);      
        var targetRotation = Quaternion.LookRotation(m_lastTarget - selfPosition);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * distanceToTarget ); 
        //transform.position = Vector3.MoveTowards(selfPosition, m_lastTarget, Time.deltaTime * m_Speed);
        m_rigidBody.velocity = transform.forward * m_Speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent<Bullet>(out Bullet bullet))
        {
            Debug.Log("HE COLISIONADO");
            Destroy(this.gameObject);
        }
    }



}
