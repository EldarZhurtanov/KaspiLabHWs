using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoHW
{
    class Program
    {
        static void Main(string[] args)
        {
            var agreements = AgreementGetter.GetAgreementByDoc("iin", "021108123456");
            
            foreach(var agreement in agreements)
            {
                Console.WriteLine(agreement.id
                    + "\t|\t" + agreement.CreationDate
                    + "\t|\t" + (agreement.LockDate > DateTime.Now || agreement.LockDate  == null? "активен" : "отключен")
                    + "\t|\t" + agreement.Type
                    + "\t|\t" + agreement.CurrentSum
                    );
            }

            Console.ReadLine();
        }
    }
}
