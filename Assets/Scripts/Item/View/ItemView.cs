using UnityEngine;
using Zenject;

namespace Item.View
{
    public class ItemView : MonoBehaviour, IItemView
    {
        [SerializeField] private GameObject _item;
        [Inject]
        public void Construct()
        {
            
        }
        
        
    }
}

