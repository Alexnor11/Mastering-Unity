using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    [SerializeField, Tooltip("Скорость вращения")]
    private float _rotationSpeed;
    
    public static int s_objectsCollected = 0;

    private void Update()
    {
        Vector3 newRotation = transform.eulerAngles;
        newRotation.y += (_rotationSpeed * Time.deltaTime);
        transform.eulerAngles = newRotation;
    }

    public void OnPickeUp(GameObject whoPickeUp)
    {
        if(GetComponent<Weapon>() != null)
        {
            PlayerController player = whoPickeUp.GetComponent<PlayerController>();
            if (player != null)
            {
                // игрок взял в руки оружие
                player.EquipWeapon(GetComponent<Weapon>());

                // отключение сценария "подбора предметов"
                enabled = false;
            }
            return;
        }

    }
}
