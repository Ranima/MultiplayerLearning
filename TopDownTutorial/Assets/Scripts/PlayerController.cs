using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerController : NetworkBehaviour {

    public float speed = 100;
    public float bulletTime = 2.0f;
    public int bulletSpeed = 6;
    public GameObject bulletPrefab;
    public Transform bulletSpawn;

    void Update()
    {
        //stop the program from recognizing non local players
        if (!isLocalPlayer)
        {
            return;
        }

        //moves the player (if the program recognizes non local players it will also try to move them.)// aaaaaaa
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        transform.Translate(x, 0, 0);
        transform.Translate(0, 0, z);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Fire();
        }
    }


    //paints the local player purple
        public override void OnStartLocalPlayer()
    {
        GetComponent<MeshRenderer>().material.color = Color.magenta;
    }

    void Fire()
    {
        var bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;
        Destroy(bullet, bulletTime);
    }
}
