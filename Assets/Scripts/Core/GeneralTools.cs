using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralTools : SingletonClass<GeneralTools>
{
    public IEnumerator Timer(float time, Action callback)
    {
        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return null;
        }
        callback?.Invoke();
       
    }
}
