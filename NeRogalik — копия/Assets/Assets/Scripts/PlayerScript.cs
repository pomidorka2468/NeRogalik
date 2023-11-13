using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerScript : MonoBehaviour
{
    public Joystick MoveJoystick;

    [SerializeField] private float speed;
    [SerializeField] private float maxHealth;
    [SerializeField] private float holyPoitionEffect;
    [SerializeField] private float poitionHealthEffect;
    [SerializeField] public float health;
    [SerializeField] public int coins;
    [SerializeField] public int keys;
    [SerializeField] private float cooldown;

    [SerializeField] public bool shieldIsOn;

    private Rigidbody2D rb;
    private MenuManager mm;
    private Vector2 moveInput;
    private Vector2 moveVelocity;

    void Start()
    {
        shieldIsOn = false;
        rb = GetComponent<Rigidbody2D>();
        mm = GameObject.FindGameObjectWithTag("MenuManager").GetComponent<MenuManager>();
    }

    void Update()
    {
        //move
        moveInput = new Vector2 (MoveJoystick.Horizontal, MoveJoystick.Vertical);
        moveVelocity = -moveInput.normalized * speed;

        if (shieldIsOn)
        {
            mm.fullShieldImage.fillAmount -= 1 / cooldown * Time.deltaTime;
            if (mm.fullShieldImage.fillAmount <= 0)
            {
                mm.fullShieldImage.fillAmount = 1;
                mm.HalfShield.SetActive(false);
                mm.FullShield.SetActive(false);
                shieldIsOn = false;
                Debug.Log("shieldDown");
            }
        }

        if (MoveJoystick.Horizontal != 0)
        {
            if (MoveJoystick.Horizontal > 0)
            {
                this.transform.localScale = new Vector3 (-1f, 1f, 1f);
            }    
            else 
            {
                this.transform.localScale = new Vector3 (1f, 1f, 1f);
            }
        }
    }

    void FixedUpdate()
    {
        //move
        rb.MovePosition(rb.position + moveVelocity * Time.fixedDeltaTime);
    }

    public void ChangeHealth(float healthValue)
    {
        health += healthValue;
        if (health <= 0)
        {
            Death();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins += 1;
        }
        else if (collision.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            keys ++;
        }
        else if (collision.CompareTag("HealPoition"))
        {
            Destroy(collision.gameObject);
            health += poitionHealthEffect;
        }
        else if (collision.CompareTag("HolyPoition"))
        {
            Destroy(collision.gameObject);
            maxHealth += holyPoitionEffect;
            health = maxHealth;
        }
        else if (collision.CompareTag("Portal"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if (collision.CompareTag("Shield"))
        {
            Destroy(collision.gameObject);
            Shield();
            shieldIsOn = true;
        }
    }

    public void OpenDoor(Collider2D collision)
    {
        if (collision.CompareTag("LockedDoor"))
        {
            
        }
    }

    private void Shield()
    {
        if (!shieldIsOn)
        {
            shieldIsOn = true;
            mm.HalfShield.SetActive(true);
            mm.FullShield.SetActive(true);
        }
        else
        {
            mm.fullShieldImage.fillAmount = 1;
        }
    }

    void Death()
    {
        mm.OpenWindow("deathWindow");
    }
}
