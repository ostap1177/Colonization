using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class OreSpawn : MonoBehaviour
{
    [SerializeField] private Collider _spawnTerritory;
    [SerializeField] private Ore _ore;
    [SerializeField] private int _oreLimit;
    [SerializeField] private int _delaySpawn;

    private Transform _transform;
    private int _childCountOnStart;
    private Vector3 _spawnBound;
    private float _transformOreY;

    private Coroutine _spawnCoroutine;
    private WaitForSeconds _waitForSeconds;

    private void Awake()
    {
        _transform = transform;
        _childCountOnStart = _transform.childCount;

        _waitForSeconds = new WaitForSeconds(_delaySpawn);

        _spawnBound = _spawnTerritory.bounds.extents;
        _transformOreY = -0.5f;
    }

    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (_spawnCoroutine != null)
        {
           StopCoroutine(_spawnCoroutine);
        }

        _spawnCoroutine = StartCoroutine(DelaySpawnOre());
    }

    private IEnumerator DelaySpawnOre()
    {
        while (true)
        {
            SpawnOre(GetSpawtPosition());

            yield return _waitForSeconds;
        }
    }

    private void SpawnOre(Vector3 spawtPosition)
    {
        if (_transform.childCount < _oreLimit + _childCountOnStart)
        {
            Ore ore = Instantiate(_ore, spawtPosition, Quaternion.identity);
            ore.transform.parent = _transform;
        }
    }

    private Vector3 GetSpawtPosition()
    {
        float vectorX = Random.Range(_spawnBound.x, -_spawnBound.x);
        float vectorZ = Random.Range(_spawnBound.z, -_spawnBound.z);

        Vector3 spawtPosition = new Vector3(vectorX, _transformOreY, vectorZ);

        return spawtPosition;
    }
}
