using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBased {
    public class SpecialAction : Action
    {

        public SpecialAction(Entity self, Entity opponent) : base(self, opponent) {}

        public override void execute() {
            opponent.hit(self.getSpecialDamage());
        }
    }
}
