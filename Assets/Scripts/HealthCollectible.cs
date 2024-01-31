using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class HealthCollectible : MonoBehaviour
{
    public ParticleSystem lifeEffect;
    public AudioClip collectedClip;

    void OnTriggerEnter2D(Collider2D other)
    {
        RubyController controller = other.GetComponent<RubyController>();

        if (controller != null && controller.health < controller.maxHealth)
        {
            Debug.Log("lifeEffect");
            StartCoroutine(PlayEffectAndDestroy(controller));
        }
    }

    IEnumerator PlayEffectAndDestroy(RubyController controller)
    {
        // Play the life effect
        lifeEffect.Play();

        // Wait for the duration of the life effect
        yield return new WaitForSeconds(lifeEffect.main.duration);

        // Change health and destroy the object
        controller.ChangeHealth(1);
        controller.PlaySound(collectedClip);
        Destroy(gameObject);
    }
}

