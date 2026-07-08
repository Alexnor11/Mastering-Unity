using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    public bool hasBeenPickedUp = false;

    [SerializeField, Tooltip("Скорость вращения")]
    private float _rotationSpeed;

    public static int s_objectsCollected = 0;

    private void Update()
    {
        Vector3 newRotation = transform.eulerAngles;
        newRotation.y += (_rotationSpeed * Time.deltaTime);
        transform.eulerAngles = newRotation;
    }

    public void OnPickUp(GameObject whoPickeUp)
    {
        if (GetComponent<Weapon>() != null)
        {
            if (hasBeenPickedUp) return;

            Weapon weapon = GetComponent<Weapon>();
            PlayerController player = whoPickeUp.GetComponent<PlayerController>();

            if (weapon != null && player != null)
            {
                // игрок взял в руки оружие
                player.EquipWeapon(weapon);                
                // отключение сценария "подбора предметов"                         
                enabled = false;
            }
            return;
        }        

        // воспроизведение звукового эффекта
        SpawnedSoundFX.Spawn(transform.position);

        s_objectsCollected++;
        Debug.Log(s_objectsCollected + " items picked up.");
        Destroy(gameObject);

    }
}