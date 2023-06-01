using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuelManagment
{
    class Context
    {
        private static dbFuelManagmentEntities _context;

        public static dbFuelManagmentEntities GetContext()
        {
            if (_context == null)
            {
                _context = new dbFuelManagmentEntities();
            }

            return _context;
        }
    }
}
