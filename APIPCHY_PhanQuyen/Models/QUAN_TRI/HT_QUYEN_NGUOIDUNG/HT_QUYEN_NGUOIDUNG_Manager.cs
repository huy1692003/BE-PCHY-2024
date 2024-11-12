using APIPCHY.Helpers;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Data;
using System;

namespace APIPCHY_PhanQuyen.Models.QLKC.HT_QUYEN_NGUOIDUNG
{
    public class HT_QUYEN_NGUOIDUNG_Manager
    {
        DataHelper helper = new DataHelper();
        public List<HT_QUYEN_NGUOIDUNG_Model> Get_QUYEN_NGUOIDUNG()
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return new List<HT_QUYEN_NGUOIDUNG_Model>();
            }
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleDataAdapter dap = new OracleDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLTN_TANH.get_QUYEN_NGUOIDUNG";
                cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);

                List<HT_QUYEN_NGUOIDUNG_Model> result = new List<HT_QUYEN_NGUOIDUNG_Model>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    HT_QUYEN_NGUOIDUNG_Model qnd = new HT_QUYEN_NGUOIDUNG_Model
                    {
                        ID = int.Parse(dr["ID"]?.ToString()),
                        TenNguoiDung = dr["HO_TEN"]?.ToString(),
                        TenDonVi = dr["TEN_DVIQLY"]?.ToString(),
                        TenNhom = dr["TEN_NHOM"]?.ToString(),
                    };

                    result.Add(qnd);

                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        public HT_QUYEN_NGUOIDUNG_Model Insert_HT_QUYEN_NGUOIDUNG(HT_QUYEN_NGUOIDUNG_Model qnd)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return null;
            }
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cn;
            OracleTransaction transaction;
            transaction = cn.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLTN_TANH.grant_HT_QUYEN_NGUOIDUNG";
                cmd.Parameters.Add("p_MA_NGUOI_DUNG", qnd.MA_NGUOI_DUNG);
                cmd.Parameters.Add("p_NHOM_QUYEN_ID", int.Parse(qnd.MA_NHOM_TV));
                cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return qnd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }

        public HT_QUYEN_NGUOIDUNG_Model Update_HT_QUYEN_NGUOIDUNG(HT_QUYEN_NGUOIDUNG_Model quyen)
        {
            string strErr = "";
            using (OracleConnection cn = new ConnectionOracle().getConnection())
            {
                cn.Open();

                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = cn;
                    using (OracleTransaction transaction = cn.BeginTransaction())
                    {
                        cmd.Transaction = transaction;

                        try
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = @"PKG_QLTN_TANH.update_HT_QUYEN_NGUOIDUNG";

                            cmd.Parameters.Add("p_ID", OracleDbType.Int32).Value = Convert.ToInt32(quyen.ID); // Chuyển đổi sang int
                            cmd.Parameters.Add("p_MA_NGUOI_DUNG", quyen.MA_NGUOI_DUNG);
                            cmd.Parameters.Add("p_NHOM_QUYEN_ID", quyen.MA_NHOM_TV);
                            cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;

                            cmd.ExecuteNonQuery();
                            transaction.Commit();
                            return quyen;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Cập nhật quyền người dùng thất bại: " + ex.Message);
                        }
                    }
                }
            }
        }

        public void Delete_HT_QUYEN_NGUOIDUNG(int id)
        {
            string strErr = "";
            using (OracleConnection cn = new ConnectionOracle().getConnection())
            {
                cn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleTransaction transaction = cn.BeginTransaction();
                cmd.Transaction = transaction;

                try
                {
                    cmd.Parameters.Clear();
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = @"PKG_QLTN_TANH.delete_HT_QUYEN_NGUOIDUNG";

                    cmd.Parameters.Add("p_ID", OracleDbType.Int32).Value = id;
                    cmd.Parameters.Add("p_Error", OracleDbType.Varchar2, 200).Direction = ParameterDirection.Output;

                    cmd.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw ex; // Hoặc xử lý lỗi theo cách bạn muốn
                }
                finally
                {
                    if (cn.State != ConnectionState.Closed)
                    {
                        cn.Close();
                    }
                }
            }
        }

    }

}
