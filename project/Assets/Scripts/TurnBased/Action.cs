using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TurnBased {
    public abstract class Action
    {
        protected Entity self;
        protected Entity opponent;

        public Action(Entity self, Entity opponent) {
            this.self = self;
            this.opponent = opponent;
        }

        public abstract void execute();
    }
}
