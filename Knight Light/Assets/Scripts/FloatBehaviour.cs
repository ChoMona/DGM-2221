using UnityEngine;
using UnityEngine.Events;

public class FloatBehaviour : MonoBehaviour
{
    public float value = 1f;

    public UnityEvent triggerEnterEvent, atZeroEvent;
    private void OnTriggerEnter(Collider other)
    {
        triggerEnterEvent.Invoke();
    }

    public void UpdateValue(float number)
    {
        if (value <= 0)
        {
            atZeroEvent.Invoke();
        }
        value += number;
    }
}
