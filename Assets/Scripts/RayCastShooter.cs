using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShooter : MonoBehaviour
{
    [SerializeField]
    LayerMask layermask;

    [SerializeField]
    private GameObject playerbulletspawner;

    public bool Rayhit;

    public float damage = 10f;
    public float range = 100f;
    public float fireRate = 15f;
    public Camera fpscam;

    private float NextTimeToFire = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitinfo, 100f, layermask))
        {
            Debug.Log("Hit Something");
            Debug.DrawRay(transform.position, transform.forward * hitinfo.distance, Color.red);
            Rayhit = true;
        }
        else
        {
            Debug.Log("Hit Nothing");
            Debug.DrawRay(transform.position, transform.forward * 100f, Color.green);
            Rayhit = false;
        }
        //gör så att den skjuter från raycasten
        if (Input.GetButtonDown("Fire1") && Time.time >= NextTimeToFire)
        {
            NextTimeToFire = Time.time + 1f / fireRate;
            shoot();
            Instantiate(playerbulletspawner, transform.position, transform.rotation);
        }

        void shoot()
        {
            RaycastHit hit;
            if(Physics.Raycast(fpscam.transform.position, fpscam.transform.forward , out hit, range))
            {
                Debug.Log(hit.transform.name);
                Target target = hit.transform.GetComponent<Target>();
                if(target != null)
                {
                    target.TakeDamage(damage);
                }
            }
        }

    }

}
