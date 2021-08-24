using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float distance;
    [SerializeField] private float height;
    [SerializeField] private Vector3 rot;

    private void LateUpdate()
    {
        transform.localRotation = Quaternion.Euler(rot.x, rot.y, rot.z);
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y + height, player.transform.position.z - distance);
    }
}
