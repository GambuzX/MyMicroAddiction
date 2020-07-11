using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Evasion {

    public class Player : MonoBehaviour
    {

        [SerializeField][Range(0,1)] float leftLimit = 0.07f;
        [SerializeField][Range(0,1)] float rightLimit = 0.93f;
        [SerializeField] float moveSpeed = 5f;

        // Start is called before the first frame update
        void Start()
        {
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

        void Die() {
            print("gg wp gaben");
            // trigger gameover
        }

        private void OnTriggerEnter2D(Collider2D other) {
            if(other.transform.GetComponent<Projectile>()) {
                Die();
            }
        }
    }
}
