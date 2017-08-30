using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hooman : Mamel {
	
	void conquer () {
        print(this.name + " Conquered");
    }
	public override void Start(){
        conquer();
        base.Start();
    }
}
