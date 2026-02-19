using System.Collections;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.InputSystem;

public class CoroutineExample : MonoBehaviour
{
    bool open = false;
    Coroutine coroutine = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coroutine = StartCoroutine(TimerCR(2.0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.oKey.wasPressedThisFrame)
        {
            open = true;
        }
        if (Keyboard.current.pKey.wasPressedThisFrame)
        {
            if (coroutine != null)
            {
                StopCoroutine(coroutine);
                print("stopped");
                coroutine = null;
            }
            else {
                coroutine = StartCoroutine(TimerCR(2.0f));

            }
        }

        
    }

    IEnumerator TimerCR(float delay)
    {
        yield return new WaitUntil(IsOpen);
        print("hello");
        yield return new WaitForSeconds(delay);
        print("world");
        yield return new WaitForSeconds(delay);
        print("coroutine");

        while (true)
        {
            print("looping");
            yield return new WaitForSeconds(delay);
            delay /= 1.5f;
        }
    }

    bool IsOpen() => open;
}
