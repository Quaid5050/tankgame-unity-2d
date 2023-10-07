using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    [SerializeField] float bulletLife = 2f;
     Rigidbody2D rigitBody;
    [SerializeField] float bulletSpeed = 60f;
    

    void Awake() {
        Destroy(gameObject, bulletLife);  
    }
    // Start is called before the first frame update
    void Start()
    {
        rigitBody = GetComponent<Rigidbody2D>();
    }

     // Update is called once per frame
    void FixedUpdate()
    {
        rigitBody.AddRelativeForce(new Vector2(0, bulletSpeed));
        Debug.Log("Bullet Moving");
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag != "blocker"){
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
