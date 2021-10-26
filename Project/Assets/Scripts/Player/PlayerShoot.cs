using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [HideInInspector] public bool CanFire = false;
    
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void StartFire()
    {
        CanFire = true;
    }
    public void StopFire()
    {
        CanFire = false;
    }

}
