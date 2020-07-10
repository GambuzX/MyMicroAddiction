using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Entity
{

    private Player player;

    private ArrayList actions = new ArrayList();

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        actions.Add(new DefendAction(this, player));
        actions.Add(new AttackAction(this, player));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Action chooseAction() {
        int rand = Random.Range(0, actions.Count);
        return (Action) actions[rand];
    }
}
