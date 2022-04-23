using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [HideInInspector]
    public uint m_MaxHP = 0;
    [HideInInspector]
    public float m_Speed = 0.0F;

    private uint m_CurrentHP;
    

    private void Start(){
        if(m_MaxHP == 0 || m_Speed == 0){
            Debug.LogError("Failed to initialize enemy");
        }
        m_CurrentHP = m_MaxHP;
    }


}
