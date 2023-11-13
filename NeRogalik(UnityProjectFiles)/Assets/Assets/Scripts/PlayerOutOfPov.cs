using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOutOfPov : MonoBehaviour
{
    [SerializeField] private float playerPovX;
    [SerializeField] private float playerPovY;
    [SerializeField] GameObject player;
    [SerializeField] GameObject thisEnemy;

    private void Update()
    {
        if (thisEnemy.transform.position.x >= player.transform.position.x + playerPovX || thisEnemy.transform.position.x <= player.transform.position.x - playerPovX || thisEnemy.transform.position.y >= player.transform.position.y + playerPovY || thisEnemy.transform.position.y <= player.transform.position.y - playerPovY)
        {
            thisEnemy.SetActive(false);
        }
        else 
        {
            thisEnemy.SetActive(true);
        }
    }
}
