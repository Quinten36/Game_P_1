using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    private Transform target;
    public GameObject impactEffect;
    //public GameObject barrelSmoke;
    //public Transform effectPoint;

    public int damage = 50;

    public float speed = 70f;
    public float explosionRadius = 0f;
    //private Turret turret;

    public void Seek (Transform _target)
    {
        target = _target;
    }

    // Start is called before the first frame update
    void Start()
    {
        //turret = GameObject.Find("Turret").GetComponent<Turret>();
        //effectPoint = turret.firePoint;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
        {
            //Vector3 dir2 = transform.position;
            //dir2.y -= Time.deltaTime * 10;
            //Quaternion down = Quaternion.LookRotation(dir2,dir2);
            //transform.rotation = down;
           // Debug.Log("werkt");
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);


    }

    void HitTarget ()
    {
      //  Debug.Log("SDF");
        GameObject effetctIns = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
        //GameObject smokeIns = (GameObject)Instantiate(barrelSmoke, effectPoint.position, effectPoint.rotation);
        //Destroy(smokeIns, 1f);
        Destroy(effetctIns, 5f);

        if (explosionRadius > 0f)
        {
            Explode();
        } else
        {
            Damage(target);
        }

        Destroy(gameObject);

    }

    void Explode ()
    {
        Collider[] hitObjects = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach (Collider hitObject in hitObjects)
        {
            if (hitObject.tag == "Enemy")
            {
                Damage(hitObject.transform);
            }
        }
    }

    void Damage (Transform enemy)
    {
       Enemy e = enemy.GetComponent<Enemy>();

        if (e != null)
        {
            e.TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
