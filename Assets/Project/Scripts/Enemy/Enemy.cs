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


    private void Start()
    {
        if (m_MaxHP == 0 || m_Speed == 0)
        {
            Debug.LogError("Failed to initialize enemy");
        }
        m_CurrentHP = m_MaxHP;
        m_rigidBody = GetComponent<Rigidbody>();
        m_playerTransform = FindObjectOfType<Player>().gameObject.transform;
    }

    private void Update()
    {
        transform.LookAt(m_playerTransform.position);
        transform.position = Vector3.MoveTowards(transform.position, m_playerTransform.position, Time.deltaTime * m_Speed);
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
