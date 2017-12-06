﻿using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI; 
 
public class uiIntModifiers : MonoBehaviour { 
  public Text CoinUI; 
  public static int TotalCoins = 0; 
  public int coinMod, burstMod; 
  private int tempCoins; 
  public enum ModType { 
    coin, 
    burst, 
    key 
  } 
  public ModType powerUp; 
  void OnTriggerEnter(Collider other) 
  { 
    StopAllCoroutines(); 
    switch (powerUp) { 
      case ModType.coin: 
        TotalCoins += coinMod; 
        StartCoroutine(collectCoin()); 
        break; 
      case ModType.burst: 
        CharControl.burstNum += burstMod; 
        break; 
    } 
  } 
  IEnumerator collectCoin () { 
    tempCoins = int.Parse(CoinUI.text); 
    while (tempCoins < TotalCoins) { 
      tempCoins++; 
      CoinUI.text = tempCoins.ToString(); 
      yield return 0; 
    } 
  } 
} 