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
    [SerializeField]
    private OVRGrabber leftGrabber;
    [SerializeField]
    private OVRGrabber rightGrabber;
    [SerializeField]
    private float shotsPerSecond;
    [SerializeField]
    private AudioClip pang;
    [SerializeField]
    private AudioClip pieuw;
    private AudioSource audio;
    private float cooldown;

    // Start is called before the first frame update
    void Start()
    {
        cooldown = 1;
        audio = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        if (cooldown >= 1 / shotsPerSecond)
        {
            if ((GetComponent<OVRGrabbable>().grabbedBy == leftGrabber && OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger)) || 
            (GetComponent<OVRGrabbable>().grabbedBy == rightGrabber && OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger)))
            fire();
        }
        else
        {
            cooldown += UnityEngine.Time.deltaTime;
        }
    }

    private void fire()
    {
        
            GameObject bullet = Instantiate<GameObject>(bulletPrefab);
            Physics.IgnoreCollision(bullet.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
            bullet.transform.position = bulletSpawn.position;
            bullet.transform.eulerAngles = bulletSpawn.transform.eulerAngles;
            bullet.GetComponent<Rigidbody>().AddForce(bulletSpawn.forward * bulletSpeed, ForceMode.Impulse);
            int rand = Random.Range(0, 2);
            if (rand == 0)
                audio.clip = pieuw;
            else
                audio.clip = pang;
            audio.Play();
            StartCoroutine(DestroyBulletAfterTime(bullet, lifeTime));
            cooldown = 0.0f;
        
    }

    public void setBulletSpeed(System.Single speed)
    {
        bulletSpeed = speed;
    }
    
    private IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
