using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public GameObject spherePrefab;
    public List<GameObject> spawnLocs;
    public float spawnInterval;
    private float timer;
    int ran; //random
    public bool IsMoving;
    public bool IsSpawning;
    public float speed;
    public float turnSpeed;
    public float horizontalInput;
    public float forwardInput;
    public GameObject Lose;
    public GameObject Win;
    public int winamt;

    // Start is called before the first frame update
    void Start()
    {
        winamt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (IsMoving)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            transform.position = transform.position + transform.right * speed * Time.deltaTime * horizontalInput; //(0,0,0) + ((0,0,1)*5)
        }



        timer += Time.deltaTime;
        if (IsSpawning)
        {
            if (timer >= spawnInterval)
            {
                ran = Random.Range(0, 5);

                //we wanna spawn a thing;
                timer = 0;


                //Instantiate(cubePrefab, spawnLocs[ran].transform.position, spawnLocs[ran].transform.rotation);
                GameObject spawnedcube = Instantiate(spherePrefab, spawnLocs[ran].transform);
                spawnedcube.transform.parent = null;
                winamt++;
                Debug.Log("You have dodged " + winamt + " obstacles.");
                if (winamt == 23)
                {
                    Win.SetActive(true);
                    IsMoving = false;
                    IsSpawning = false;
                }
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CarCube")
        {
            Lose.SetActive(true);
            IsMoving = false;
            IsSpawning = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("This object has stopped colliding with " + collision.gameObject.name);
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("This object " + collision.gameObject.name + " is currently colliding.");
    }
}