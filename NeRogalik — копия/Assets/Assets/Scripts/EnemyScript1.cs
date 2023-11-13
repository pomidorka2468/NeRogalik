using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript1 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject EnemyHeadObject;

    [SerializeField] private Transform coinPlace;

    [SerializeField] private float health;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (player.transform.position.x > this.transform.position.x)
        {
            this.transform.localScale = new Vector3 (1f, 1f, 1f);
        }
        else 
        {
            this.transform.localScale = new Vector3 (-1f, 1f, 1f);
        }

        if (health <= 0)
        {
            Instantiate(coinPrefab, coinPlace.position, coinPlace.rotation);
            Destroy(EnemyHeadObject);
        }

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }
}