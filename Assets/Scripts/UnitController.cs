using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    private AudioSource _audioSource;
    private ParticleSystem _hitParticle;

    [SerializeField]
    private AudioClip [] _hitClip;
    [SerializeField]
    private GameObject _weapon;

    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _hitParticle = _weapon.transform.GetChild(0).GetComponent<ParticleSystem>();
    }

    public void Hit()
    {
        var clip = Random.Range(0, _hitClip.Length);
        _audioSource.PlayOneShot(_hitClip[clip]);

        _hitParticle.Play();
    }
}
