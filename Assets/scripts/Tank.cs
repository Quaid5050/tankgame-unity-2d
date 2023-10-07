using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    //tank heriarchy
    /*
    0- Tank:
        -tankBody
        0 -moveHandler
                -gunner
        1 -guns
                -leftGun
                -rightGun
        2 -lights
                -leftLight
                -rightLight
    1- BulletSpawnPoint  
    */
   
    //tank stuff
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 20f;

    //gunner stuff
    [SerializeField] private GameObject gunner;
    

    //bullet stuff
    [SerializeField] private Transform bulletSpawnPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float bulletSpeed = 10f;

    [SerializeField] private float bulletSpawnDistance = 1f; // Adjust this distance as needed



    

    // Start is called before the first frame update 
    void Start()
    {  
        //get the gunner reference
         gunner = transform.GetChild(1).gameObject;
         Debug.Log("Gunner ref name: "+ gunner.name);

        //get the reference of the bullet spawn point
         bulletSpawnPoint = transform.GetChild(1).GetChild(0).GetChild(0).gameObject.transform;
         Debug.Log("bulletSpawnPoint ref name: "+bulletSpawnPoint.name);
    }

    // Update is called once per frame
    void Update()
    {
        TankMovement();
        GunnerRotation();
        shooting();
       
    }
   

    
   void TankMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Move the tank
        Vector3 movement = new Vector3(horizontalInput, verticalInput, 0f) * moveSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Rotate the tank
        float rotation = -horizontalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.forward * rotation);
    }

   
   void GunnerRotation()
    {
        float rotationSpeed = 100f; // Adjust this value to control the rotation speed

        // Rotate forward when left mouse button is held
        if (Input.GetMouseButton(0)) // 0 represents the left mouse button
        {
            gunner.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }

        // Rotate backward when right mouse button is held
        if (Input.GetMouseButton(1)) // 1 represents the right mouse button
        {
            gunner.transform.Rotate(Vector3.forward * -rotationSpeed * Time.deltaTime);
        }
    }

    void shooting(){
         if(Input.GetKeyDown(KeyCode.Space)){
              Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
         }
    }

     


    void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.tag == "tank")
        // {
        //     Debug.Log("Tank collided with tank");
        // }
        Debug.Log("Tank collided with " + collision.gameObject.name);
    }

}
