using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phish : Aminal {
	void swim () {
        print(this.name + " Swam");
    }
	public override void Start() {
        swim();
        base.Start();
    }
}
