using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Evasion {
    public class Projectile : MonoBehaviour
    {

        private Vector3 moveDir;
        private float speed = 0f;

        // Update is called once per frame
        void Update()
        {
            transform.position += moveDir * speed * Time.deltaTime;
        }

        public void setTarget(Vector3 t) {
            Vector3 diff = t - transform.position;
            diff = diff.normalized;

            float angle = Vector3.Angle(Vector2.down, new Vector2(diff.x, diff.y));

            moveDir = Quaternion.Euler(0, angle, 0) * Vector3.down;

        }

        public void setSpeed(float s) {
            speed = s;
        }
    }
}