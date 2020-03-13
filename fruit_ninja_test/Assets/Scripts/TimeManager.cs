using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{

  public float slowdownFactor = 0.15f;
  public float slowdowmTimer = 4.5f;


  public void Slowmotion () {
    Time.timeScale = slowdownFactor;
    Time.fixedDeltaTime = Time.timeScale * .02f;
  }

    // Update is called once per frame
    void Update()
    {
      Time.timeScale += (1f / slowdowmTimer) * Time.unscaledDeltaTime;
      Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
    }
}
