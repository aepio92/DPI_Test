using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponFire : MonoBehaviour
{
    [SerializeField] private float Range;
    [SerializeField] private ParticleSystem[] MuzzleFlash;
    [SerializeField] private float ShootForce;
    [SerializeField] private PlayerShoot Shoot;
    [SerializeField] private float FireRate = 10;
    [SerializeField] private GameObject AiImpact, OtherImpact;

    private AudioSource FireSound;
    private float NextTimetoFire;

    void Start()
    {
        FireSound = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        if(Shoot.CanFire==true)
        {
            //checking next time to fire for semi automatic gun
            if(Time.time>=NextTimetoFire)
            {
                NextTimetoFire = Time.time + 1 / FireRate;
                Fire();
            }
        }
    }

    void Fire()
    {
        //Gathering Hit Info with raycast
        RaycastHit hit;
        Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward,out hit, Range);

        //FX
        foreach(var MF in MuzzleFlash)
        {
            if (!MF.gameObject.activeInHierarchy)
            {
                MF.gameObject.SetActive(true);
            }
            MF.Play();
        }
        FireSound.Play();

        //Checking collision
        if(hit.collider!=null)
        {
            //comparing with AI tag

            if(hit.collider.tag=="AI")
            {
                hit.collider.GetComponent<Damage>().ApplyDamage(20);
                Instantiate(AiImpact, hit.point, Quaternion.LookRotation(-hit.normal));
            }
            else
            {
                Instantiate(OtherImpact, hit.point, Quaternion.LookRotation(-hit.normal));
            }
        }
    }
}
