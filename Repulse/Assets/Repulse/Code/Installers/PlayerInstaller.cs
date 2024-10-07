using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private PlayerMovement _playerPrefab;
    [SerializeField] private Transform _playerSpawnPoint;

    private PlayerMovement _playerMovement;

    private Camera _camera;

    public override void InstallBindings()
    {
        CreatePlayer();
        BindPlayer();
        BindPlayerCamera();
    }

    private void CreatePlayer()
    {
        _playerMovement = Container.
            InstantiatePrefabForComponent<PlayerMovement>
            (_playerPrefab, _playerSpawnPoint.position,
            _playerSpawnPoint.rotation, null);
    }

    private void BindPlayer()
    {
        Container.
            Bind<PlayerMovement>().
            FromInstance(_playerMovement).
            AsSingle();
    }

    private void BindPlayerCamera()
    {
        _camera = _playerMovement.gameObject.GetComponentInChildren<Camera>();

        Container.
            Bind<Camera>().
            FromInstance(_camera).
            AsSingle();
    }

}
