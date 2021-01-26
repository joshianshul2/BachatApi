using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessEntities;

namespace BusinessServices
{
    public interface IItemMasterServices
    {
        ItemMasterEntity GetItemById(int id);
       
        IEnumerable<ItemMasterEntity> GetAllItem();
        int CreateItem(ItemMasterEntity ItemMasterEntity);
        bool UpdateItem(int id, ItemMasterEntity itemMasterEntity);
        bool DeleteItem(int id);
    }
}
