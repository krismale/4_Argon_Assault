using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionEffect;
    [Tooltip("The parent for the explosion in hierarchy")][SerializeField] Transform explosionParent;
    [SerializeField] Text scoreBoard;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        
    }

    private void AddNonTriggerBoxCollider()
    {
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        GameObject spawnedExplosion = Instantiate(explosionEffect, transform.position, Quaternion.identity, explosionParent);
        spawnedExplosion.SetActive(true);
        ScoreBoard scoreBoardScript = scoreBoard.GetComponent<ScoreBoard>();
        scoreBoardScript.ScoreHit();
        Destroy(gameObject);
    }
}
