using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActivation : MonoBehaviour
{
    [System.Serializable]
    public class TriggerSubtitle
    {
        public Collider triggerCollider;
        public string subtitle;
    }

    public Text subtitleText;
    public List<TriggerSubtitle> triggerSubtitles = new List<TriggerSubtitle>();
    private int currentSubtitleIndex = 0;

    void Start()
    {
        // Inicialmente, desactivar los subt�tulos
        subtitleText.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Buscar el trigger actual en la lista de triggerSubtitles
            foreach (TriggerSubtitle triggerSubtitle in triggerSubtitles)
            {
                if (triggerSubtitle.triggerCollider == other)
                {
                    // Mostrar el subt�tulo asociado al trigger
                    subtitleText.text = triggerSubtitle.subtitle;
                    subtitleText.gameObject.SetActive(true);
                    break;
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Ocultar los subt�tulos al salir del trigger
            subtitleText.gameObject.SetActive(false);
        }
    }
}
