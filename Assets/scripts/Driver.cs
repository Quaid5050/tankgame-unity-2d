using System.Threading;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform bulletPoint;
    [SerializeField]
    float steerSpeed = 100f;
    [SerializeField]
    float moveSpeed = 10f;
    [SerializeField]
    float slowSpeed = 5f;
    [SerializeField]
    float boostSpeed = 20f;
    float timer = 0f;
    [SerializeField]
    float maxTime = 2f;
    float remainingValuables = 15;
    bool isValuablePicked = false;
    [SerializeField]
    Sprite originalSprite, updatedSprite;
    SpriteRenderer bodySpriteRenderer;

    
    // Start is called before the first frame update
    void Start()
    {
        bodySpriteRenderer = transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>();
        Debug.Log(bodySpriteRenderer.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {   
        EffectTimer();
        Move();
        Fire();
    }


    void Move()
    {
        //User Input Horizontal (left arrow OR A, right arrow OR D), Vertical (up arrow OR W, down arrow OR S)
        var vert = Input.GetAxis("Vertical");
        var hori = Input.GetAxis("Horizontal");

        //Movement
        transform.Translate(0,moveSpeed * Time.deltaTime * vert,0);
        //Steer
        transform.Rotate(0,0,steerSpeed * Time.deltaTime * -hori);
    }

    void Fire()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bullet, bulletPoint.position, bulletPoint.rotation);
        }
    }

    void EffectTimer()
    {
        timer += Time.deltaTime;
        if(timer >= maxTime && moveSpeed != 10)
        {
            moveSpeed = 10f;
            Debug.Log("Normal");
        }
    }

    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Collision Enter"); 
        moveSpeed = slowSpeed;
        timer = 0f;
    }

    void OnCollisionExit2D(Collision2D other) 
    {
        Debug.Log("Collision Exit");
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Enter Trigger");
        if(other.gameObject.tag == "Oil")
        {
            moveSpeed = slowSpeed;
        }
        else if(other.gameObject.tag == "Speedup")
        {
            moveSpeed = boostSpeed;
            timer = 0f;
        }
        else if(other.gameObject.tag == "Valuable")
        {
            if(!isValuablePicked)
            {
                Destroy(other.gameObject, 0.1f);
                isValuablePicked = true;
                bodySpriteRenderer.sprite = updatedSprite;
            }
            
        }
        else if(other.gameObject.tag == "Pit")
        {
            isValuablePicked = false;
            remainingValuables--;
            bodySpriteRenderer.sprite = originalSprite;
        }
    }

    void OnTriggerExit2D(Collider2D other) 
    {
        Debug.Log("Exit Trigger");
        if(other.gameObject.tag == "Oil")
        {
            moveSpeed = 10f;
        }
    } 
}
