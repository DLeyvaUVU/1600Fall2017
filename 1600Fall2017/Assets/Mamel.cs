using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mamel : Aminal {
	
	void liveBirth () {
        print(this.name + " Birthed Live Child");
    }
	public override void Start(){
        liveBirth();
        base.Start();
    }
}
