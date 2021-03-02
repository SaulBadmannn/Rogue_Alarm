using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarm : MonoBehaviour
{
    [SerializeField] private AudioSource _alarmSound;
    [SerializeField] private float _delayAlarm = 0.3f;
    [SerializeField] private float _stepAlarmVolume = 0.1f;
    private bool _isActivated = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.TryGetComponent<Rogue>(out Rogue rogue))
        {
            var alarmYowl = IsYowl();

            if (_isActivated == false)
            {
                Debug.Log("Запустить сигналку!");
                _alarmSound.Play();
                _isActivated = true;
                StartCoroutine(alarmYowl);
            }
            else
            {
                Debug.Log("Выключить сигналку!");
                _isActivated = false;
                _alarmSound.Stop();
                StopCoroutine(alarmYowl);
            }
        }
    }

    private IEnumerator IsYowl()
    {
        while (_isActivated == true)
        {
            while (_alarmSound.volume > 0)
            {
                _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, 0, _stepAlarmVolume);
                yield return new WaitForSeconds(_delayAlarm);
            }
            while (_alarmSound.volume < 1)
            {
                _alarmSound.volume = Mathf.MoveTowards(_alarmSound.volume, 1, _stepAlarmVolume);
                yield return new WaitForSeconds(_delayAlarm);
            }
        }
    }
}
