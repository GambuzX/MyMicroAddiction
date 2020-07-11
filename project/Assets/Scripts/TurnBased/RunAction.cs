using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBased {
    public class RunAction : Action
    {

        private float runChance = 0.3f;

        public RunAction(Entity self, Entity opponent) : base(self, opponent) {}

        public override void execute() {
            float choice = Random.Range(0, 1);
            if (choice <= runChance) {
                // run
            }
            else {
                // do not run
            }
        }
    }
}
