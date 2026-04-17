using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.CompilerServices;
using System.Text;
using WebDevDAL;

namespace WebDevPortRn.FINNAS
{
    public class Finnas
    {        

        public Finnas()
        {
            
        }

        public List<Dictionary<string, object>> GetFinnas()
        {
            DataAccess db = new DataAccess();

            return db.ToList(db.Query("SELECT * FROM Gastos"));            
        }

    }
}
