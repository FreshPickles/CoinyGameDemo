using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHandler : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public TMP_Text coinText;
    public TMP_Text scoreText;
    public Slider healthBar;

    Vector2 movement;

    int coins;
    int score;

    public float maxHealth = 50f;
    float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        coins = 0;
        score = 0;

        currentHealth = maxHealth;
        healthBar.value = maxHealth;
        healthBar.maxValue = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        // Movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // checking if colliding with coin
        if(collision.gameObject.tag == "Coin")
        {
            coins++;
            Destroy(collision.gameObject);
            coinText.text = "Coins: " + coins;
        }

        // checking if colliding with enemy
        if(collision.gameObject.tag == "Enemy")
        {
            TakeDamage(10f);
            Destroy(collision.gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // checking if we stay inside the scorezone
        if(collision.gameObject.tag == "ScoreZone")
        {
            if(coins > 0)
            {
                coins--;
                score++;
                coinText.text = "Coins: " + coins;
                scoreText.text = "Score: " + score;
            }
            Heal(1f);
        }
    }

    // subtracting from healthbar
    void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            currentHealth = 0;
            return;
        }
        healthBar.value = currentHealth;
    }

    // adding to our healthbar
    void Heal(float health)
    {
        if (currentHealth >= healthBar.maxValue)
        {
            currentHealth = maxHealth;
            healthBar.value = maxHealth;
            return;
        }
        currentHealth += health;
        healthBar.value = currentHealth;
    }
}
