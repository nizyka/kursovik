using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курс
{
   public class Date_base
    {
       private static Entities1 _context;
        public static Entities1 GetContext()
        {
            if (_context == null) _context = new Entities1();
            return _context;
        }
        //обовление базы при добавлении/изменении данных
        public static void ApplyDataBaseChange() => _context?.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
    }
}
