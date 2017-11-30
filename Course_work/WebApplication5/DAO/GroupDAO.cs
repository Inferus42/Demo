using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication5.Models;


namespace WebApplication4.DAO
{
    public class GroupDAO
    {
        private SeaPortEntities _entities = new SeaPortEntities();
        public IEnumerable<Group> getAllGroups()
        {
            return (from c in _entities.Group
                    select c);

        }
    }


}
