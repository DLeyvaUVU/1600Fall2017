using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Krab : Aminal {
	
	void pinch () {
        print(this.name + " Pinched");
    }
	public override void Start(){
        pinch();
        base.Start();
    }
}
