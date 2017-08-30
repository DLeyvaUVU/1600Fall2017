using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burd : Aminal {
	void fly () {
        print(this.name + " Flew");
    }
	public override void Start(){
        fly();
        base.Start();
    }

}
