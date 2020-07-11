using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Evasion {
    public class Gutter : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other) {
            Destroy(other.gameObject);
        }
    }
}