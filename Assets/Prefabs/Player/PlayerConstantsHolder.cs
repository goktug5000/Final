using UnityEngine;
using Cinemachine;

public class PlayerConstantsHolder : ConstantHolder
{
    public static PlayerConstantsHolder _playerConstantsHolder;

    [Header("G�l�c�k")]
    [SerializeField] public Attack playerAttack;
    [SerializeField] public Equipment playerEquipment;
    [SerializeField] public Inventory playerInventory;
    [SerializeField] public Movement playerMovement;
    [SerializeField] public PlayerQuests playerQuests;

    [SerializeField] public CinemachineVirtualCamera virtualCameraTP;
    [SerializeField] public CinemachineVirtualCamera virtualCameraTPS;
    [SerializeField] public Camera mainCamera;
    [SerializeField] public GameObject[] hitBoxes = new GameObject[2];

    void Awake()
    {
        if (_playerConstantsHolder != null)
        {
            Destroy(this);
        }
        else
        {
            _playerConstantsHolder = this;
        }
    }
}
