﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Evasion {

    public class Player : MonoBehaviour
    {

        [SerializeField][Range(0,1)] float leftLimit = 0.07f;
        [SerializeField][Range(0,1)] float rightLimit = 0.93f;
        [SerializeField] float moveSpeed = 5f;
        [SerializeField] private string[] steamGames;
        [SerializeField] private int[] prices;
        private int choice;

        void Start() {
            choice = Random.Range(0, prices.Length);
            GameObject.Find("FeaturedGame").GetComponent<TextMesh>().text = steamGames[choice] + "\n$" + prices[choice];
        }

        // Update is called once per frame
        void Update()
        {
            ProcessInput();
            ClampPosition();
        }

        void ProcessInput() {
            float horiz = Input.GetAxis("Horizontal");
            float move = horiz * moveSpeed * Time.deltaTime;
            transform.Translate(new Vector3(move, 0f, 0f));
        }

        void ClampPosition() {
            Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
            pos.x = Mathf.Clamp(pos.x, leftLimit, rightLimit);
            transform.position = Camera.main.ViewportToWorldPoint(pos);
        }

        void Die(int discount) {
            LevelManager levelManager = GameObject.FindObjectOfType<LevelManager>();
            GameState gameState = GameObject.FindObjectOfType<GameState>();

            string chosenGame = steamGames[choice];

            gameState.updateMoney(-Mathf.RoundToInt(prices[choice] * (100 - discount) / 100));
            gameState.addTransaction("Bought " + chosenGame +  " with a " + discount + "% discount", Minigame.EVASION);
            levelManager.loadGameRoom();
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if(other.transform.GetComponent<Projectile>()) {
                Die(other.GetComponent<SteamDiscount>().getDiscount());
            }
        }
    }
}
