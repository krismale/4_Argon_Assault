using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionEffect;
    [Tooltip("The parent for the explosion in hierarchy")][SerializeField] Transform explosionParent;
    [SerializeField] Text scoreBoard;
    [Tooltip("How much the score increases when this enemy is hit")][SerializeField] int valuePerKill = 12;
    [SerializeField] int maxHits = 10;

    int hits = 0;

    // Start is called before the first frame update
    void Start()
    {
        AddNonTriggerBoxCollider();
        if(!scoreBoard)
        {
            scoreBoard = FindObjectOfType<Text>();
        }
    }

    private void AddNonTriggerBoxCollider()
    {
        BoxCollider collider = gameObject.AddComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        ++hits;
        //to consider hit FX

        if (hits >= maxHits)
        {
            KillEnemy();
        }

    }

    private void KillEnemy()
    {
        GameObject spawnedExplosion = Instantiate(explosionEffect, transform.position, Quaternion.identity, explosionParent);
        spawnedExplosion.SetActive(true);
        ScoreBoard scoreBoardScript = scoreBoard.GetComponent<ScoreBoard>();
        scoreBoardScript.ScoreHit(valuePerKill);
        Destroy(gameObject);
    }
}
