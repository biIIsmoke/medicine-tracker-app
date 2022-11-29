
using Item.Model;
using Item.View;

namespace Item.Controller
{
    public class ItemController
    {
        private IItemView _itemView;
        private IItemRepository _itemRepository;
        
        public ItemController(IItemView itemView, 
            IItemRepository itemRepository)
        {
            _itemView = itemView;
            _itemRepository = itemRepository;
        }
        
    }
}

