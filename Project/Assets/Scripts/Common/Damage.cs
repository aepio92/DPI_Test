using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private float Health;
    public void ApplyDamage(float Damage)
    {
        Health = Health - Damage;

        if(Health<=0)
        {
            Destroy(gameObject);
        }
    }
}
