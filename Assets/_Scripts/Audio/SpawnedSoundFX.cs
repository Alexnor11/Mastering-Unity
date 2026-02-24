using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnedSoundFX : MonoBehaviour
{
    public AudioSource _audioSource;

    static string _prefamPath = "Prefabs/SpawnedSoundFX";
    
    public static void Spawn(Vector3 pos, AudioClip clip = null)
    {
        // создание объекта звукового эффекта
        GameObject prefab = Resources.Load<GameObject>(_prefamPath);
        GameObject newObj = Instantiate(prefab, pos, Quaternion.identity);
        
        // случайное изменение тона
        float rand = Random.Range(0.95f, 1.05f);
        SpawnedSoundFX soundScript = newObj.GetComponent<SpawnedSoundFX>();
        soundScript._audioSource.pitch = rand;

        // код: замена аудиофайла
        if (clip)
        {
            soundScript._audioSource.clip = clip;
            soundScript._audioSource.Play();
        }
    }
}
