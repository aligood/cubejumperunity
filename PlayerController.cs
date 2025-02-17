using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float jumpForce;
    bool canJump;

    
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetMouseButtonDown(0) && canJump)
        {
            //sound of jumping
            GameObject.Find("JumpSound").GetComponent<AudioSource>().Play();
            //jump 
            rb.AddForce(Vector3.up * jumpForce , ForceMode.Impulse);
        }


    }
    private void OnCollisionEnter(Collision collision) 
    {
        if(collision.gameObject.tag == "Ground")
        {
            canJump = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            canJump = false;
        }
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Obstacle")
        {
            Handheld.Vibrate();
            // sound of lose play when collid with obstacle
            GameObject.Find("LoseSound").GetComponent<AudioSource>().Play();
            // betone bemoone sound e lose zamani ke bazi az awal omad (raft ro halat play az awal)
            DontDestroyOnLoad(GameObject.Find("LoseSound").gameObject);
            // play it again now 
            SceneManager.LoadScene("Game");
        }
    }

}
