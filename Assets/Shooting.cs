using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform firePointUp;
    public Transform firePointDown;
    public Transform firePointLeft;
    public Transform firePointRight;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    public float lastMousePosX = 0f;
    public float lastMousePosY = 0f;

    public float swingRate = 0.5f;
    public float nextSwing = 0f;

    public Vector3 forceApplied = new Vector3(0, 0 , 0);

    void Start()
    {
        lastMousePosX = Input.mousePosition.x;
        lastMousePosY = Input.mousePosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSwing && Mathf.Abs(Input.mousePosition.x) > 20f + lastMousePosX ||
            Time.time > nextSwing && Mathf.Abs(Input.mousePosition.y) > 20f + lastMousePosY) 
        {
            nextSwing = Time.time + swingRate;
            ShootUp();
            ShootDown();
            ShootLeft();
            ShootRight();
        }
     
        lastMousePosX = Input.mousePosition.x;
        lastMousePosY = Input.mousePosition.y;
    }

    void ShootUp()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePointUp.position, firePointUp.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * bulletForce, ForceMode2D.Impulse);
    }

    void ShootDown()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePointDown.position, firePointDown.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.down * bulletForce, ForceMode2D.Impulse);
    }

    void ShootLeft()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePointLeft.position, firePointLeft.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.left * bulletForce, ForceMode2D.Impulse);
    }

    void ShootRight()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePointRight.position, firePointRight.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.right * bulletForce, ForceMode2D.Impulse);
    }
}
