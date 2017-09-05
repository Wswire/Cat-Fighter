using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BatControl : MonoBehaviour {


    public float moveSpeed;
    GameObject player;
    public int spawnDelay;
    SpriteRenderer sr;
    public int range;
    public Transform relayPoint;

    [System.Serializable]
    public class PlayerStatistics
    {
        public int Health = 1;

    }

    public PlayerStatistics batStatistics = new PlayerStatistics();

    public int fallBoundry = -20;        // Destroys things that fall out of screen

    private void Awake()
    {
        sr = transform.GetComponent<SpriteRenderer>();
    }


    // Use this for initialization
    void Start () {
        if (GameObject.Find("Player") != null)
            player = GameObject.Find("Player");
        else
            player = GameObject.Find("Player(Clone)");       // after the original 'player' dies it comes back as player(clone), this is to find it with the new name

        if (relayPoint == null)
        {
            relayPoint = GameObject.Find("SpawnPoint (bat)").transform;       // bat spawn point
        }
        
    }
	
	// Update is called once per frame
	void Update () {

        if (transform.position.y <= fallBoundry)
        {
            DamagePlayer(999999999);             // to make sure the game object dies when out of bounds
        }

        if (player != null)
        {
            if (player.transform.position.x > transform.position.x)
            {
                sr.flipX = true;
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * moveSpeed);
            }
            else
            {
                sr.flipX = false;
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * moveSpeed);       // this if...then statement to make the bat face in the direction it is moving
            }
        }else
        {
            transform.position = Vector3.MoveTowards(transform.position, relayPoint.position, Time.deltaTime * moveSpeed);              // if the player dies they go back to spawnpoint 1
        }

        Start();

        if(Score.scoreValue == 100)
        {
            OnBossInstance();                // for future, in case of a boss
        }
    }

    public void DamagePlayer(int damage)      // damages bat, destroys it and adds to game score counter
    {
        Debug.Log("damage");
        batStatistics.Health -= damage;
        if (batStatistics.Health <= 0)
        {
            Destroy(this);
            Score.scoreValue += 1;
            do
            {
                GameMaster.KillPlayer(this);
            }
            while (GameObject.FindGameObjectWithTag("bat") == null);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)          // collision of flame projectile and bat
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.tag == "flame")
        {
            Debug.Log(collision.gameObject.name);
            DamagePlayer(9999);
        }
    }

    public void OnBossInstance()
    {
        for (int i =0 ; i< GameObject.FindGameObjectsWithTag("bat").Length; i++)           //  for future... destroy all bats when boss encounter starts
        {
            Destroy(GameObject.FindGameObjectsWithTag("bat")[i]);
        }
    }
}
