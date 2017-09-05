using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersStats : MonoBehaviour {
    
    [System.Serializable]
    public class PlayerStatistics
    {
        public int Health = 1;              // health of game object
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

    public void DamagePlayer(int damage)         // kills if less than or equal to 0 health
    {
        playerStatistics.Health -= damage;
        if (playerStatistics.Health <= 0)
        {
            GameMaster.KillPlayer(this);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)          // player bat collision, player dies
    {
        if (collision.gameObject.tag == "bat")
        {
            DamagePlayer(1);
        }
    }
}
