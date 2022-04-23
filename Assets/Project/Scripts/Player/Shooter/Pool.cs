using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    private static Pool _instance;

    public static Pool Instance { get { return _instance; } }

    [SerializeField]
    private GameObject objectPrefab;

    [SerializeField]
    private int basePoolSize = 20;

    [SerializeField]
    private int currentPoolSize = 0;

    public List<GameObject> objects;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

    }

    private void incrementPoolSize(){

        this.currentPoolSize += basePoolSize;
        var objectsCount = objects.Count;
        
        GameObject aux;

        while (objectsCount < this.currentPoolSize)
        {
            aux = Instantiate(objectPrefab);
            aux.SetActive(false);
            objects.Add(aux);
            objectsCount++;    
        }

    }

    void Start(){

        objects = new List<GameObject>();        
        incrementPoolSize();

    }

    private GameObject findInactiveInPool(){

        var it = 0;
        int itEnd = objects.Count;

        while(it < itEnd){

            GameObject i = objects[it];
            if(!i.activeInHierarchy){
                return i;
            }

            it++;

        }

        incrementPoolSize();
        return null;

    }

    public GameObject getFromPool(){

        GameObject objectFromPool = null;

        while(!objectFromPool){
            objectFromPool = findInactiveInPool();
        }

        return objectFromPool;
    }



}