using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Item.Model
{
    public class ItemRepository : IItemRepository
    {
        private const string _itemsKey = "ItemsKey";
        private List<ItemModel> _items;
        
        public ItemRepository()
        {
            if (PlayerPrefs.HasKey(_itemsKey))
            {
                var itemsString = PlayerPrefs.GetString(_itemsKey);

                try
                {
                    _items = JsonConvert.DeserializeObject<List<ItemModel>>(itemsString);
                }
                catch(Exception e)
                {
                    _items = new List<ItemModel>();
                }
            }
            else
            {
                _items = new List<ItemModel>();
            }
        }

        public void AddItem(ItemModel item)
        {
            _items.Add(item);
        }

        public void DeleteItem(ItemModel item)
        {
            foreach (var element in _items)
            {
                if (element == item)
                {
                    _items.Remove(item);
                    return;
                }
            }
        }
    }
    
    public class ItemModel
    {
        private readonly int _itemID;
        private string _name;
        private float _amount;
        private float _dailyUsage;
        private string _description;
        private bool _isActive;

        public ItemModel(int itemID, string name, float amount, float dailyUsage, string description, bool isActive)
        {
            _itemID = itemID;
            _name = name;
            _amount = amount;
            _dailyUsage = dailyUsage;
            _description = description;
            _isActive = isActive;
        }
        
        public static bool operator==(ItemModel item1, ItemModel item2)
        {
            return item1._itemID==item2._itemID;
        }
        public static bool operator!=(ItemModel item1, ItemModel item2)
        {
            return item1._itemID!=item2._itemID;
        }
	
        public override bool Equals(object obj)
        {
            if(obj == null || GetType() != obj.GetType()) return false;
		
            var other = (ItemModel)obj;
            return _itemID.Equals(other._itemID);
        }
        
        public override int GetHashCode()
        {
            return _itemID.GetHashCode();
        }
    }
}

