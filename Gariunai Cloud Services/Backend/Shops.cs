using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Gariunai_Cloud_Services.Entities;
using Microsoft.EntityFrameworkCore;

internal class Shops : IEnumerable<Shop>
{
    private readonly List<Shop> _shopList;

    public Shops()
    {
        var db = new DataAccess();
        _shopList = db.Shops
            .Include(s => s.Followers)
            .Include(s => s.Produce)
            .Include(s => s.Notifications)
            .Include(s => s.Owner)
            .ToList();
    }

    public Shop this[int index]  
    {  
        get => _shopList[index];
        set => _shopList.Insert(index, value);
    } 

    public IEnumerator<Shop> GetEnumerator()
    {
        return _shopList.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}