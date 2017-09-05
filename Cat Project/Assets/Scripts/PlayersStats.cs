using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersStats : MonoBehaviour {
    
    [System.Serializable]
    public class PlayerStatistics
    {
        public int Health = 1;
    }

    public PlayerStatistics playerStatistics = new PlayerStatistics();

    public int fallBoundry = -20;

    void Update()
    {
        if (transform.position.y <= fallBoundry)
        {
            DamagePlayer(9999);
        }
    }

    public void DamagePlayer(int damage)
    {
        playerStatistics.Health -= damage;
        if (playerStatistics.Health <= 0)
        {
            GameMaster.KillPlayer(this);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "bat")
        {
            DamagePlayer(1);
        }
    }
}
