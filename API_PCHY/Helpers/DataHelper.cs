using Oracle.ManagedDataAccess.Client;
using System;
using System.Data;
using System.Data.SqlClient;

namespace APIPCHY.Helpers
{
    public class DataHelper
    {
        //string connectionString = "User Id=QLKC;Password=qlkc;Data Source=117.0.33.2:1522/QLKC";
        OracleConnection cn;

        public DataHelper(string conn)
        {
            cn = new OracleConnection(conn);

        }

        public DataHelper()
        {
            cn = new ConnectionOracle().getConnection();
        }

        public bool Open()
        {
            try
            {
                if (cn.State != ConnectionState.Open)
                {
                    cn.Open();
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public void Close()
        {
            if (cn.State != ConnectionState.Closed)
            {
                cn.Close();
            }
        }

        //public DataTable ExcuteReader
        public string ExcuteNonQuery(string procedureName, string paramOut, params object[] param_list)
        {

            OracleCommand cmd = new OracleCommand { CommandText = procedureName, CommandType = CommandType.StoredProcedure, Connection = cn };

            OracleTransaction transaction;
            Open();
            string strErr = "";
            transaction = cn.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                int paramInput = (param_list.Length) / 2;
                cmd.Parameters.Clear();
                for (int i = 0; i < paramInput; i++)
                {
                    string paramKey = Convert.ToString(param_list);
                    object paramValue = param_list[i + paramInput];
                    cmd.Parameters.Add(new OracleParameter(paramKey, paramValue));
                }
                cmd.Parameters.Add(paramOut, OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception err)
            {
                strErr = err.ToString();
                transaction.Rollback();
            }
            finally
            {
                Close();
            }

            return strErr;
        }

        public DataTable ExcuteReader(string ProcedureName, params object[] param_list)
        {
            DataTable tb = new DataTable();
            try
            {
                OracleCommand cmd = new OracleCommand { CommandType = CommandType.StoredProcedure, CommandText = ProcedureName, Connection = cn };
                Open();
                int paramterInput = (param_list.Length) / 2;
                for (int i = 0; i < paramterInput; i++)
                {
                    string paramName = Convert.ToString(param_list[i]);
                    object paramValue = param_list[i + paramterInput];
                    if (paramName.ToLower().Contains("json"))
                    {
                        cmd.Parameters.Add(new OracleParameter
                        {
                            ParameterName = paramName,
                            OracleDbType = OracleDbType.NVarchar2,
                            Value = paramValue ?? DBNull.Value
                        });
                    }
                    else
                    {
                        cmd.Parameters.Add(new OracleParameter(paramName, paramValue ?? DBNull.Value));
                    }
                }

                OracleParameter refCursor = new OracleParameter
                {
                    ParameterName = "p_getDB",
                    OracleDbType = OracleDbType.RefCursor,
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(refCursor);


                OracleDataAdapter ad = new OracleDataAdapter(cmd);
                ad.Fill(tb);
                ad.Dispose();
                cmd.Dispose();
                cn.Dispose();
            }
            catch (Exception ex)
            {
                tb = null;
                // Log lỗi nếu cần
            }
            finally
            {
                Close();
            }
            return tb;
        }
    }
}
