using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsyncFunction : MonoBehaviour
{
    private static bool isCoroutineExecuting;

    public static IEnumerator ExecuteAfterTime(float time, Action task)
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        task();
        isCoroutineExecuting = false;
    }

    public void Asyncf(float t, Action task)
    {
        StartCoroutine(ExecuteAfterTime(t, () =>
        {
            //Add somwthing here
            task();
        }));
    }


    public static IEnumerator DelayInvoke(Action action, float delaySeconds)
    {
        yield return new WaitForSeconds(delaySeconds);
        action();
    }

}