using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
  [Header("Health")] 
  public int lives = 3;
  public int maxLives = 3;

  [Header("DamageControl")] 
  public bool canTakeDamage;
  public float canTakeDamageTime = 0.2F;
  public float canTakeDamageCounter;

  private AudioSource _audioSource;
  public AudioClip[] hurtClips;
  public AudioClip[] pickupClips;
  
  private SceneController sceneController;
  private void Start()
  {
    _audioSource = GetComponent<AudioSource>();
    sceneController = GetComponent<SceneController>();
  }

  private void Update()
  {
    if (Time.time > canTakeDamageCounter)
    {
      canTakeDamage = true;
    }
  }

  private void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Heart"))
    {
      if (lives >= maxLives) return;
      lives += 1;
      _audioSource.PlayOneShot(pickupClips[Random.Range(0,pickupClips.Length)]);
      Destroy(other.gameObject);
    }
  }
  private void OnCollisionStay2D(Collision2D other)
  {
    if (other.gameObject.CompareTag("Enemy"))
    {
      TakeDamage();
    }
  }

  private bool yes; // makes death only happen once
  public void TakeDamage()
  {
    if (canTakeDamage == false) return;
    
    _audioSource.PlayOneShot(hurtClips[Random.Range(0, pickupClips.Length)]);

    if (lives > 0)
    {
      lives -= 1; // lives --;
      canTakeDamage = false;
      canTakeDamageCounter = Time.time + canTakeDamageTime;
    }
    else if (lives <= 0 && !yes)
    {
      yes = true;
      print("Dead");
      
      Invoke("ReloadScene", .7f);
    }
  }

  public void HealDamage()
  {
    if (lives >= 3)
    {
      return;
    }
    else
    {
      lives++;
    }
  }

  private void ReloadScene()
  {
      sceneController.Loadscene();
  }
}