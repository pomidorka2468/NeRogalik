using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public float damage;
    public float distane;

    public LayerMask solidForBullets;

    public void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distane, solidForBullets);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyScript1>().TakeDamage(damage);
                Destroy(gameObject);
            }
            if (hitInfo.collider.CompareTag("Player"))
            {
                hitInfo.collider.GetComponent<PlayerScript>().ChangeHealth(-damage);
                Destroy(gameObject);
            }
            else if (hitInfo.collider.CompareTag("Wall"))
            {
                Destroy(gameObject);
            }
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        lifeTime -= Time.deltaTime;

        if (lifeTime <= 0)
        {
            Destroy(gameObject);
        } 
    }
}

