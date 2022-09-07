using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoting : MonoBehaviour
{
    public Camera cam;
    public ParticleSystem flash;
    //public Light light;
    public float range = 20f;
    public GameObject hitEffect;
    public ScriptableObjectLogic EHP;


    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            flash.Play();
            Shoot();
            
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Instantiate(hitEffect, hit.point, Quaternion.LookRotation(hit.normal));
            EnemyLogic target = hit.transform.GetComponent<EnemyLogic>();
            if (target != null)
            {
                target.Hurt(1);
            }
        }
    }
}
