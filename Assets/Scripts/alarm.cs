using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alarm : MonoBehaviour
{
    [SerializeField] public AudioSource alarmSound;
    private bool isActivated = false;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.name == "rogue")
        {
            if(isActivated == false)
            {
                Debug.Log("Запустить сигналку!");
                alarmSound.Play();
                isActivated = true;
                var alarmIsPlay = StartCoroutine(isYowl());

            }
            else
            {
                Debug.Log("Выключить сигналку!");
                isActivated = false;
                alarmSound.Stop();
                StopCoroutine(isYowl());
            }
        }
    }

    private IEnumerator isYowl()
    {
        while (isActivated == true)
        {
            while (alarmSound.volume > 0)
            {
                alarmSound.volume -= 0.1f;
                yield return new WaitForSeconds(0.3f);
            }
            while (alarmSound.volume < 1)
            {
                alarmSound.volume += 0.1f;
                yield return new WaitForSeconds(0.3f);
            }
        }
    }
}
