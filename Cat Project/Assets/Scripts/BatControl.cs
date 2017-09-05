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

    public int fallBoundry = -20;

    private void Awake()
    {
        sr = transform.GetComponent<SpriteRenderer>();
    }


    // Use this for initialization
    void Start () {
        if (GameObject.Find("Player") != null)
            player = GameObject.Find("Player");
        else
            player = GameObject.Find("Player(Clone)");

        if (relayPoint == null)
        {
            relayPoint = GameObject.Find("SpawnPoint (bat)").transform;
        }
        
    }
	
	// Update is called once per frame
	void Update () {

        if (transform.position.y <= fallBoundry)
        {
            DamagePlayer(999999999);
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
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, Time.deltaTime * moveSpeed);
            }
        }else
        {
            transform.position = Vector3.MoveTowards(transform.position, relayPoint.position, Time.deltaTime * moveSpeed);
        }

        Start();

        if(Score.scoreValue == 100)
        {
            OnBossInstance();
        }
    }

    public void DamagePlayer(int damage)
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

    void OnCollisionEnter2D(Collision2D collision)
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
        for (int i =0 ; i< GameObject.FindGameObjectsWithTag("bat").Length; i++)
        {
            Destroy(GameObject.FindGameObjectsWithTag("bat")[i]);
        }
    }
}
