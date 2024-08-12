using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralTools : SingletonClass<GeneralTools>
{
    public IEnumerator Timer(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback?.Invoke();
    }
}
