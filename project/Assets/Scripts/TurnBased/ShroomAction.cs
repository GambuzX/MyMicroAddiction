using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace TurnBased {
    public class ShroomAction : RitoAction
    {

        public ShroomAction(Entity self, Entity opponent, string trigger) : base(self, opponent, trigger) {}

        public override void execute() {
            string quote = quotes[Random.Range(0, quotes.Length)];
            msgBox.text = quote;
            opponent.GetComponent<Animator>().SetTrigger("damage");
            opponent.hit(self.getSpecialDamage());
        }
    }
}
