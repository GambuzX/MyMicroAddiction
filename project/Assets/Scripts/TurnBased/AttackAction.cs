using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAction : Action
{

    public AttackAction(Entity self, Entity opponent) : base(self, opponent) {}

    public override void execute() {
        opponent.hit(self.getAttackDamage());
    }
}
