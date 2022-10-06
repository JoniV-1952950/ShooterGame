using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullets : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform bulletSpawn;
    [SerializeField]
    private float bulletSpeed;
    [SerializeField]
    private float lifeTime;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonUp(0))
        {
            GameObject bullet = Instantiate<GameObject>(bulletPrefab);
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(),gameObject.GetComponent<Collider>());
            bullet.transform.position = bulletSpawn.position;
            bullet.transform.eulerAngles = bulletSpawn.transform.eulerAngles;
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);
            StartCoroutine(DestroyBulletAfterTime(bullet,lifeTime));
        }
    }
    
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
