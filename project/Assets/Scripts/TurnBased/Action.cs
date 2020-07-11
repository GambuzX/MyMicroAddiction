using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TurnBased {
    public abstract class Action
    {
        protected Entity self;
        protected Entity opponent;
        protected string trigger;
        protected Text msgBox;

        public Action(Entity self, Entity opponent, string trigger) {
            this.self = self;
            this.opponent = opponent;
            this.trigger = trigger;
            msgBox = GameObject.Find("MessageBox").GetComponent<Text>();
        }

        public abstract void execute();
        public abstract void executeAnimation();
    }
}
