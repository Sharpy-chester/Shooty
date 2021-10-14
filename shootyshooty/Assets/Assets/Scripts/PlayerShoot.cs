using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{

    [SerializeField] GameObject bulletPrefab;
    [SerializeField] float bulletSpeed;

    void Awake()
    {

    }


    void Update()
    {
        LookAtMouse();
        Shooting();
    }

    //this doesnt seem like a very optimised way to do this if im being honest. Thought of this way and implemented it so yeah, im not sure really
    void LookAtMouse()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            this.transform.LookAt(hit.point);
            this.transform.eulerAngles = new Vector3(0, this.transform.eulerAngles.y, this.transform.eulerAngles.z);
        }
    }

    void Shooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            GameObject bullet = Instantiate(bulletPrefab, this.transform);
            bullet.transform.parent = null;
            bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * bulletSpeed);
            Destroy(bullet, 5f);
        }
    }
}