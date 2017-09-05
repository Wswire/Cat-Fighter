using UnityEngine;
using System.Collections;

public class projectile : MonoBehaviour
{

    public GameObject projectile1;
    public Vector2 velocity;
    bool canShoot = true;
    public Vector2 offset = new Vector2(0.4f, 0.1f);
    public float cooldown = 1f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftControl) && canShoot)          // flame projectile size, speed etc.
        {

            GameObject go = (GameObject)Instantiate(projectile1, (Vector2)transform.position + offset * transform.localScale.x, Quaternion.identity);

            go.GetComponent<Rigidbody2D>().velocity = new Vector2(velocity.x * transform.localScale.x, velocity.y);


            StartCoroutine(CanShoot());


        }
    }


    IEnumerator CanShoot()           // cooldown between shots
    {
        canShoot = false;
        yield return new WaitForSeconds(cooldown);
        canShoot = true;


    }
}