using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]
    float steerSpeed = 5f;
    [SerializeField]
    float moveSpeed = 0.25f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        //User Input Horizontal (left arrow OR A, right arrow OR D), Vertical (up arrow OR W, down arrow OR S)
        var vert = Input.GetAxis("Vertical");
        var hori = Input.GetAxis("Horizontal");

        //Movement 
        transform.Translate(0,moveSpeed * Time.deltaTime * vert,0);
        //Steer
        transform.Rotate(0,0,steerSpeed * Time.deltaTime * -hori);
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Collision Enter");    
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        Debug.Log("Collision Exit");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Entered Oil Spil");    
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        Debug.Log("Exit Oil Spil");
    }

   
}
