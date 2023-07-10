using System.Collections.Generic;
using _Code.Counters.Logic;
using _Code.Counters.SoundLogic;
using _Code.Extensions;
using _Code.KitchenObjects;
using _Code.KitchenObjects.Factory;
using _Code.KitchenObjects.PlateLogic;
using UnityEngine;
using Zenject;

namespace _Code.Counters
{
    public class GlassCounter : SelectableCounter
    {
        [SerializeField] private Transform _platesParent;
        [SerializeField] private float _spawnCooldown;
        [SerializeField] private InteractAndDenySoundCounter _sounds;

        private const byte MaxGlassAmount = 3;
        private const float GlassHeight = .15f;

        private Stack<Glass> _glasses;
        private IKitchenObjectsFactory _factory;
        private float _spawnTimer;

        [Inject]
        private void Construct(IKitchenObjectsFactory factory)
        {
            _factory = factory;
            Debug.Log(_factory == null);
        }

        private void Awake() => 
            _glasses = new Stack<Glass>();

        private void Update()
        {
            if (_glasses.Count < MaxGlassAmount)
            {
                if (_spawnTimer < _spawnCooldown)
                    CountTime();
                else
                {
                    CreateGlass();
                    _spawnTimer = 0;
                }
            }
        }

        public Glass Interact(KitchenObject playersObject)
        {
            if (playersObject == null)
                return PopGlassWithSound();

            _sounds.PlayDenySound();
            return null;
        }

        private Glass PopGlassWithSound()
        {
            _sounds.PlayInteractSound();
            return _glasses.Pop() as Glass;
        }

        private void PutPlayersObjectOnPlate(KitchenObject playersObject, Plate plate)
        {
            playersObject.HasBeenTaken?.Invoke();
            plate.TakeKitchenObject(playersObject);
        }

        private void CreateGlass()
        {
            Glass glass = _factory.CreateGlass();
            glass.SetParent(_platesParent);

            if (_glasses.Count > 0)
                glass.transform.position = glass.transform.position.AddY(_glasses.Count * GlassHeight);

            _glasses.Push(glass);
        }

        private void CountTime()
        {
            if (_spawnTimer + Time.deltaTime > _spawnCooldown)
                _spawnTimer = _spawnCooldown;
            else
                _spawnTimer += Time.deltaTime;
        }
    }
}