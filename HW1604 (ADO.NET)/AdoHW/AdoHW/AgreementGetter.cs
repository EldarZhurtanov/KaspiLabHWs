using AdoHW.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoHW
{
    public class AgreementGetter
    {
        private static string connectionString = @"Data Source=ELDAR\SQLEXPRESS;Initial Catalog=kaspilab;Integrated Security=true";

        public static IEnumerable<Agreement> GetAgreementByDoc(string DocType, string DocNumber)
        {
            string queryString =
                @"SELECT Agreement.id, Agreement.CreationDate, Agreement.LockDate, BankAcc.CurrentSum, (SELECT Value from DictValue where id = AggTemplate.AggTypeId)
                    FROM Agreement INNER JOIN
                         Client ON Agreement.ClientId = Client.id INNER JOIN
                         СertDoc ON Client.id = СertDoc.ClientId INNER JOIN
                         AggTemplate ON Agreement.TemplateId = AggTemplate.id INNER JOIN
                         BankAcc ON Agreement.id = BankAcc.AgrId
						 WHERE СertDoc.TypeId = (SELECT id FROM DictValue WHERE Value = @docType)
                            AND СertDoc.Number = @docNumber";

            List<Agreement> agreements = new List<Agreement>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);

                command.Parameters.AddWithValue("@docType", DocType);
                command.Parameters.AddWithValue("@docNumber", DocNumber);

                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        long id = reader.GetInt64(0);
                        DateTime creationDate = reader.GetDateTime(1);
                        decimal currentSum = reader.GetDecimal(3);
                        string type = reader.GetString(4);
                        DateTime? lockDate = null;

                        if (agreements.Count() > 0)
                            if (!reader.IsDBNull(2))
                                lockDate = reader.GetDateTime(2);

                        agreements.Add(new Agreement
                        {
                            id = id,
                            CreationDate = creationDate,
                            LockDate = lockDate,
                            CurrentSum = currentSum,
                            Type = type
                        });
                    }
                reader.Close();
                }
            }
            return agreements;
        }

    }
}
