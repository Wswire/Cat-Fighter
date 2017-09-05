using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour {

    public Transform playerPrefab;
    public Transform batPrefab;
    public Transform spawnPoint;
    public Transform spawnPointBat;
    public Transform spawnPointBat1;
    public Transform spawnPointBat2;
    public Transform spawnPointBat3;
    public Transform spawnPointBat4;
    public Transform spawnPointBat5;
    public Transform spawnPointBat6;

    public float spawnDelay = 3;
    public float spawnDelayBat = 0.1f;
    public static GameMaster gm;


    void Start()
    {
        if (gm == null)
        {
            gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        }
    }

    public IEnumerator RespawnPlayer()         // respwn player with delay
    {
        yield return new WaitForSeconds(spawnDelay);
        if (GameObject.Find("Player(Clone)") == null)
        {
            Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }

    public static void KillPlayer(PlayersStats player)          // kill player, resets score
    {
        Destroy(player.gameObject);
        Score.scoreValue = 0;
        gm.StartCoroutine(gm.RespawnPlayer());
        
    }


    public IEnumerator RespawnBat()           // respawns bats, every 5 bats killled a new spawn point is made......this ramps up really fast
    {
        yield return new WaitForSeconds(spawnDelayBat);
        switch (Score.scoreValue/5)
        {
            case 0:
                Instantiate(batPrefab, spawnPointBat.position, spawnPointBat.rotation);
                break;
            case 1:
                Instantiate(batPrefab, spawnPointBat.position, spawnPointBat.rotation);
                Instantiate(batPrefab, spawnPointBat1.position, spawnPointBat.rotation);
                break;
            case 2:
                Instantiate(batPrefab, spawnPointBat.position, spawnPointBat.rotation);
                Instantiate(batPrefab, spawnPointBat1.position, spawnPointBat.rotation);
                Instantiate(batPrefab, spawnPointBat2.position, spawnPointBat.rotation);
                break;
            case 3:
                Instantiate(batPrefab, spawnPointBat.position, spawnPointBat.rotation);
                Instantiate(batPrefab, spawnPointBat1.position, spawnPointBat.rotation);
                Instantiate(batPrefab, spawnPointBat2.position, spawnPointBat.rotation);
                Instantiate(batPrefab, spawnPointBat3.position, spawnPointBat.rotation);
                break;
            case 4:
                Instantiate(batPrefab, spawnPointBat.position, spawnPointBat.rotation);
                Instantiate(batPrefab, spawnPointBat1.position, spawnPointBat.rotation);
                Instantiate(batPrefab, spawnPointBat2.position, spawnPointBat.rotation);
                Instantiate(batPrefab, spawnPointBat3.position, spawnPointBat.rotation);
                Instantiate(batPrefab, spawnPointBat4.position, spawnPointBat.rotation);
                break;
        }
    }

    public static void KillPlayer(BatControl player)         // kill bat (bad naming tbh) 
    {
        Destroy(player.gameObject);
        gm.StartCoroutine(gm.RespawnBat());
    }

    public void bossMode()            // for future
    {
       
    }
}
