using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace UnityStandardAssets._2D
{
    public class MoveTrail : MonoBehaviour
    { 
        public int moveSpeed;
        SpriteRenderer sr;
        GameObject player;
        bool side;
        

        private void Awake()
        {
            if (GameObject.Find("Player") != null)
            {
                player = GameObject.Find("Player");
            }
            else
            {
                player = GameObject.Find("Player(Clone)");
            }

            sr = GetComponent<SpriteRenderer>();

            if (player == null)
            {
                Debug.LogError("NO PLAYER");
            }
        }

        private void Start()
        {
            if (player.GetComponent<SpriteRenderer>().transform.localScale.x > 0)
            {
                side = true;
            }
            else
            {
                sr.flipX = true;
                side = false;
                
            }
        }

        private void Update()
        {

            if (side)
            {
                transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
            }
            else if (!side)
            {
                transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            }

        }

      

    }
}
