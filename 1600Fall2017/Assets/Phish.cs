using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phish : Aminal {
	void swim () {
        print(this.name + " Swims");
    }
	void Start() {
        swim();
    }
}
