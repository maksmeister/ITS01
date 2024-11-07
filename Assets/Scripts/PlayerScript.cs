using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

  [SerializeField] int min;
  [SerializeField] int max;
  [SerializeField] int guess;
  [SerializeField] int money = 1000;
  int moneyWin;
  [SerializeField] int moneyLoose = 20;
  int face;
  float timeOffset = 0;
  int sleepTime = 1;


  // Start is called before the first frame update
  void Start()
  {
    moneyWin = (max - min) * moneyLoose;
  }

  // Update is called once per frame
  void Update()
  {

    if (Time.fixedTime > timeOffset)
    {
      face = ComputeDiceThrow();

      if (face == guess)
      {
        money += moneyWin;
        Debug.Log("faccia: " + face + " vinto; soldi: " + money);
      }
      else
      {
        money -= moneyLoose;
        Debug.Log("faccia: " + face + " perso; soldi: " + money);
      }

      timeOffset = Time.fixedTime + sleepTime;
    }
  }

  int ComputeDiceThrow()
  {
    return Random.Range(min, max);
  }
}
