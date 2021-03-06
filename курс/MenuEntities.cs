using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace курс
{
    class MenuEntities
    {
        private static Entities _context;
        public static Entities GetContext()
        {
            if (_context == null) _context = new Entities();
            return _context;
        }
        public static void ApplyDataBaseChange() => _context?.ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
    }
}
}
