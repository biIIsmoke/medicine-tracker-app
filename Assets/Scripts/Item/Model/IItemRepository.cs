namespace Item.Model
{
    public interface IItemRepository
    {
        void AddItem(ItemModel item);
        void DeleteItem(ItemModel item);
    }
}