﻿using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlatesCounter : BaseCounter
{
    [SerializeField] private Transform _platesParent;
    [SerializeField] private float _spawnCooldown;
    [SerializeField] private InteractAndDenySoundCounter _sounds;

    private const byte _maxPlatesAmount = 3;
    private const float _plateHeight = .15f;

    private IKitchenObjectsFactory _factory;
    private Stack<KitchenObject> _plates;
    private float _spawnTimer;

    [Inject]
    private void Construct(IKitchenObjectsFactory factory) => 
        _factory = factory;

    private void Awake() => 
        _plates = new Stack<KitchenObject>();

    private void Update()
    {
        if (_plates.Count < _maxPlatesAmount)
        {
            if (_spawnTimer < _spawnCooldown)
                CountTime();
            else
            {
                CreatePlate();
                _spawnTimer = 0;
            }
        }
    }

    public override KitchenObject Interact(KitchenObject playersObject)
    {
        if (_plates.Count < 1)
        {
            _sounds.PlayDenySound();
            return null;
        }

        if (playersObject == null)
        {
            return PopPlateWithSound();
        }
        else if (playersObject is not Plate && playersObject.IsCooked)
        {
            Plate plate = PopPlateWithSound();
            PutPlayersObjectOnPlate(playersObject, plate);
            return plate;
        }

        _sounds.PlayDenySound();
        return null;
    }

    private Plate PopPlateWithSound()
    {
        _sounds.PlayInteractSound();
        return _plates.Pop() as Plate;
    }

    private void PutPlayersObjectOnPlate(KitchenObject playersObject, Plate plate)
    {
        playersObject.HasBeenTaken?.Invoke();
        plate.TakeKitchenObject(playersObject);
    }

    private void CreatePlate()
    {
        KitchenObject plate = _factory.CreateKitchenObject(KitchenObjectType.Plate);
        plate.SetParent(_platesParent);

        if (_plates.Count > 0)
            plate.transform.position = plate.transform.position.AddY(_plates.Count * _plateHeight);
        
        _plates.Push(plate);
    }

    private void CountTime()
    {
        if (_spawnTimer + Time.deltaTime > _spawnCooldown)
            _spawnTimer = _spawnCooldown;
        else
            _spawnTimer += Time.deltaTime;
    }
}