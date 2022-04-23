using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  
    private static Player _instance;

    public static Player Instance { get { return _instance; } }

    List<Fire> shooters;

    [SerializeField]
    Transform shootersPivot;

    [SerializeField]
    GameObject shooterPrefab;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }

    }

    public void incrementShooter(){

        GameObject shooter = Instantiate(shooterPrefab); 
        shooter.transform.parent = shootersPivot;
        shooter.transform.position = Vector3.zero;

        shooters.Add(shooter.GetComponent<Fire>());            

    }

    public void incrementBulletsPerShot(){
        
        var it = 0;
        int itEnd = shooters.Count;

        while(it < itEnd){

            shooters[it].BulletsPerShot++;
            it++;
        }

    }

    public void incrementShooterRotationSpeed(float speed){

        var it = 0;
        int itEnd = shooters.Count;

        while(it < itEnd){

            shooters[it].transform.GetComponent<RotationMovement>().modifyRotationSpeed(speed);
            it++;
        }

    }

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
