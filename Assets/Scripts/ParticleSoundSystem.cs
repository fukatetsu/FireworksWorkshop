using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Hellmade.Sound;

//Script used in https://www.youtube.com/watch?v=jKSz8JJnL4E
[RequireComponent(typeof(ParticleSystem))]
public class ParticleSoundSystem: MonoBehaviour
{
    private ParticleSystem  _parentParticleSystem;

    private int _currentNumberOfParticles = 0;

    public AudioClip[] BornSounds;
    public AudioClip[] DieSounds;

    [SerializeField] private float DelayTime = 0f;
    private Transform _playerTransform;

    private void Awake()
    {
        _playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        _parentParticleSystem = this.GetComponent<ParticleSystem>();
        if(_parentParticleSystem == null)
            Debug.LogError("Missing ParticleSystem!", this);


        EazySoundManager.IgnoreDuplicateSounds = false;


    }

    // Update is called once per frame
    void Update()
    {
        // var amount = Mathf.Abs(_currentNumberOfParticles - _parentParticleSystem.particleCount);
        var amount = Random.Range(15, 25);

        if (_parentParticleSystem.particleCount < _currentNumberOfParticles) 
        { 
            if(DieSounds[0]!=null){
                 StartCoroutine(PlaySound(DieSounds?[Random.Range(0, DieSounds.Length)], amount));
            }
            
        } 

        if (_parentParticleSystem.particleCount > _currentNumberOfParticles) 
        { 
            if(BornSounds[0]!=null){
                
                StartCoroutine(PlaySound(BornSounds?[Random.Range(0, BornSounds.Length)], amount));
            }
            
        } 

        _currentNumberOfParticles = _parentParticleSystem.particleCount;
    }

    private IEnumerator PlaySound(AudioClip clip, int amount)
    {
        var distanceToPlayer    = Vector3.Distance(this.transform.position, _playerTransform.position);
        var soundDelay          = distanceToPlayer / 343; //Speed of sound https://en.wikipedia.org/wiki/Speed_of_sound

        //Debug.Log($"Distance to player '{distanceToPlayer}', therefore delayed sound of '{soundDelay}' sec.");

        yield return new WaitForSeconds(DelayTime);

        for (int i = 0; i < amount; i++)
        {
            //Debug.Log($"Play sound: '{clip.name}'");
            int soundId         = EazySoundManager.PrepareSound(clip, Random.Range(0.8f, 1.2f), false, this.transform);
            var sound           = EazySoundManager.GetSoundAudio(soundId);
            
            sound.SetVolume(1.0f);
            sound.Min3DDistance = 20;
            sound.Max3DDistance = 250;
            sound.SpatialBlend  = 1f;
            sound.Spread        = 60f;
            sound.DopplerLevel  = 0f;
            sound.Pitch         = Random.Range(0.8f, 1.2f);
            sound.RolloffMode   = AudioRolloffMode.Custom;

            //Realistic audio rolloff: https://forum.unity.com/threads/audio-realistic-sound-rolloff-tool.543362/
            var animCurve = new AnimationCurve(
                                                new Keyframe(sound.Min3DDistance, 1f),
                                                new Keyframe(sound.Min3DDistance + (sound.Max3DDistance - sound.Min3DDistance) / 4f, .35f),
                                                new Keyframe(sound.Max3DDistance, 0f));
            animCurve.SmoothTangents(1, .025f);
            
            // sound.CustomCurve = animCurve;

            StartCoroutine(PlaySound(sound, soundDelay));
            
            //Attempt to avoid multiple of the same audio being played at the exact same time - as it sounds wierd
            yield return new WaitForSeconds(0.05f);
        }
    }

    private IEnumerator PlaySound(Audio sound, float delayInSeconds)
    {
        yield return new WaitForSeconds(delayInSeconds);

        sound.Play();
    }

}