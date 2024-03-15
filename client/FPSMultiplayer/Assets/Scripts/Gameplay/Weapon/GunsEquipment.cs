using System;
using UnityEngine;

namespace Gameplay.Weapon
{
    public class GunsEquipment : MonoBehaviour
    {
        [SerializeField] private Gun[] _guns;
        [SerializeField] private Gun _current;

        public Gun Current => _current;

        public event Action<int> Equipped;
        
        public void Equip(int gunId)
        {
            var data = FindGunById(gunId);
            _current.Hide();
            _current = data;
            _current.Show();
            Equipped?.Invoke(gunId);
        }

        private Gun FindGunById(int id)
        {
            foreach (var gunData in _guns)
            {
                if (gunData.Id == id)
                    return gunData;
            }

            throw new ArgumentException("Invalid gun id!");
        }
    }
}