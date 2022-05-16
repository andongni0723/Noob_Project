using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public GameObject winPanel;

    public float speed;

    private Rigidbody2D rb;
    private Animator anim;
    private float movementX;

    private void Awake()
    {
        // Reset time
        Time.timeScale = 1;

        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Movement()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        // Player move
        rb.velocity = new Vector2(movementX * speed * Time.fixedDeltaTime, rb.velocity.y);

        // Player animator setting
        anim.SetFloat("Speed", Mathf.Abs(movementX));

        // Player flip
        if (movementX != 0)
        {
            transform.localScale = new Vector3(movementX, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.tag)
        {
            case "Coin":
                GameManager.instance.GetCoin();
                Destroy(other.gameObject); // Destroy coin gameobject
                break;
            case "Box":
                Win(); // Player win
                break;
        }
    }

    private void Win()
    {
        // Time Stop
        Time.timeScale = 0;

        // Set UI
        winPanel.SetActive(true);
    }

    public void OnPlayAgain()
    {
        SceneManager.LoadScene("Main");
    }
}