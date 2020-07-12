using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Evasion {
    public class Gaben : MonoBehaviour
    {

        [SerializeField] float spawnRate = 2f;
        [SerializeField] float minSpawnRate = .1f;

        [SerializeField] float shootSpeed = 1f;

        [SerializeField] Projectile projectilePrefab;
        private Player player;

        // Start is called before the first frame update
        void Start()
        {
            player = GameObject.FindObjectOfType<Player>();
            StartCoroutine("spawnDiscounts");
        }

        IEnumerator spawnDiscounts() {
            while(true) {
                spawnDiscount();
                yield return new WaitForSeconds(spawnRate);
            }
        }

        private void spawnDiscount() {
            Projectile projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            projectile.setTarget(player.transform.position);
            projectile.setSpeed(shootSpeed);
        }

        public void setSpawnRate(float newSpawnRate) {
            spawnRate = Mathf.Max(newSpawnRate, minSpawnRate);
        }
    }
}