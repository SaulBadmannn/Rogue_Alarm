using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] public AudioSource alarmSound;
    [SerializeField] private float _delayAlarm = 0.3f;
    [SerializeField] private float _stepAlarmVolume = 0.1f;
    private bool isActivated = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent<Rogue>(out Rogue rogue))
        {
            var alarmYowl = IsYowl();

            if (isActivated == false)
            {
                Debug.Log("Запустить сигналку!");
                alarmSound.Play();
                isActivated = true;
                StartCoroutine(alarmYowl);
            }
            else
            {
                Debug.Log("Выключить сигналку!");
                isActivated = false;
                alarmSound.Stop();
                StopCoroutine(alarmYowl);
            }
        }
    }

    private IEnumerator IsYowl()
    {
        while (isActivated == true)
        {
            while (alarmSound.volume > 0)
            {
                alarmSound.volume = Mathf.MoveTowards(alarmSound.volume, 0, _stepAlarmVolume);
                yield return new WaitForSeconds(_delayAlarm);
            }
            while (alarmSound.volume < 1)
            {
                alarmSound.volume = Mathf.MoveTowards(alarmSound.volume, 1, _stepAlarmVolume);
                yield return new WaitForSeconds(_delayAlarm);
            }
        }
    }
}
