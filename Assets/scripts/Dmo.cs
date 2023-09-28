using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dmo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]  
    private float stearSpeed = 5f;
    
    void Start()
    {
        Debug.Log("Game is started");
        



    }

    // Update is called once per frame
    void Update()
    {

         transform.Rotate(0, 0, 1 * Time.deltaTime);
         var vertical =   Input.GetAxis("Vertical");
         var horizontal = Input.GetAxis("Horizontal");

         transform.Rotate(0,0,stearSpeed* Time.deltaTime * -horizontal);
         transform.Translate(0,stearSpeed * Time.deltaTime * vertical,0);
         
    
    }
}
