using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBased {
    public class DefendAction : Action
    {

        public DefendAction(Entity self, Entity opponent) : base(self, opponent) {}

        public override void execute() {
            self.setDefend(true);
        }
    }
}
