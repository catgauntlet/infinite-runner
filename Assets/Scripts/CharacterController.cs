using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    public Transform rayStart;
    public GameObject crystalEffect;

    private Rigidbody rb;
    private Animator anim;

    public int movementSpeed = 2;
  
    private bool walkingRight = true;
    private GameManager gameManager;
    
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    private void FixedUpdate()
    {
        if (!gameManager.gameStarted)
        {
            return;
        } else
        {
            anim.SetTrigger("isRunning");
        }

        this.rb.transform.position = this.transform.position + this.transform.forward * this.movementSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            this.SwitchCharacterDirection();
        }

        RaycastHit hit;

        if (!Physics.Raycast(rayStart.position, -transform.up, out hit, Mathf.Infinity))
        {
            anim.SetTrigger("isFalling");
        } else
        {
            anim.SetTrigger("isBackOnTheRoad");
        }

        if (transform.position.y < -2)
        {
            gameManager.EndGame();
        }
    }

    private void SwitchCharacterDirection()
    {
        if (gameManager.gameStarted)
        {
            this.walkingRight = !this.walkingRight;

            if (this.walkingRight)
            {
                this.transform.rotation = Quaternion.Euler(0, 45, 0);
            }
            else
            {
                this.transform.rotation = Quaternion.Euler(0, -45, 0);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Crystal")
        {
            gameManager.IncreaseScore();

            GameObject g = Instantiate(crystalEffect, rayStart.transform.position, Quaternion.identity);
            Destroy(g, 2);
            Destroy(other.gameObject);
        }
    }
}
