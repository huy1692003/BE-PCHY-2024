﻿using APIPCHY.Helpers;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;

namespace API_PCHY.Models.QLTN.DM_KHACH_HANG
{
    public class DM_KHACH_HANG_Manager
    {
        DataHelper _helper = new DataHelper();


        /***
        ** INSERT DM KHACH HANG 
        */
        public string insert_DM_KHACHHANG(DM_KHACH_HANG_Model khachHang)
        {
            try
            {
                string result = _helper.ExcuteNonQuery(
                    "PKG_QLTN_TANH.insert_DM_KHACH_HANG", "p_Error",
                    "p_TEN_KH", "p_GHI_CHU", "p_SO_DT", "p_EMAIL", "p_MA_SO_THUE",
                    "p_DIA_CHI", "p_NGUOI_TAO", 
                    khachHang.ten_kh,
                    khachHang.ghi_chu,
                    khachHang.so_dt,
                    khachHang.email,
                    khachHang.ma_so_thue,
                    khachHang.dia_chi,
                    khachHang.nguoi_tao
                );

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        /***
        ** UPDATE DM KHACH HANG 
        */
        public string update_DM_KHACHHANG(DM_KHACH_HANG_Model khachHang)
        {
            try
            {
                string result = _helper.ExcuteNonQuery(
                    "PKG_QLTN_TANH.update_DM_KHACH_HANG", "p_Error",
                    "p_ID", "p_TEN_KH", "p_GHI_CHU", "p_SO_DT", "p_EMAIL",
                    "p_MA_SO_THUE", "p_DIA_CHI", "p_NGUOI_SUA", "p_NGAY_SUA",
                    khachHang.id,  
                    khachHang.ten_kh,
                    khachHang.ghi_chu,
                    khachHang.so_dt,
                    khachHang.email,
                    khachHang.ma_so_thue,
                    khachHang.dia_chi,
                    khachHang.nguoi_sua,
                    khachHang.ngay_sua ?? (object)DBNull.Value 
                );

                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /**
         * DELETE: XOA KHACH HANG
         */

        public string delete_DM_KHACHHANG(int id)
        {
            try
            {
                string result = _helper.ExcuteNonQuery(
                    "PKG_QLTN_TANH.delete_DM_KHACH_HANG", "p_Error",
                    "p_ID", id);

                return result;
            }
            catch (Exception ex)
            {
                return $"Lỗi: {ex.Message}";
            }
        }


        public List<DM_KHACH_HANG_Model> FILTER_DM_KHACH_HANG(DM_KHACH_HANG_Request request, out int totalRecords, out int totalPages)
        {
            OracleConnection cn = new ConnectionOracle().getConnection();
            try
            {
                cn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLTN_TANH.search_DM_KHACH_HANG";

                // Các tham số đầu vào
                cmd.Parameters.Add("p_TEN_KH", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(request.TEN_KH) ? (object)DBNull.Value : request.TEN_KH;
                cmd.Parameters.Add("p_SO_DT", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(request.SO_DT) ? (object)DBNull.Value : request.SO_DT;
                cmd.Parameters.Add("p_EMAIL", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(request.EMAIL) ? (object)DBNull.Value : request.EMAIL;

                cmd.Parameters.Add("p_pageNumber", OracleDbType.Int32).Value = request.PageIndex;   // pageNumber
                cmd.Parameters.Add("p_pageSize", OracleDbType.Int32).Value = request.PageSize;      // pageSize

                cmd.Parameters.Add("p_totalRecords", OracleDbType.Decimal).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                // Thực thi thủ tục
                OracleDataAdapter dap = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                dap.Fill(ds);

                // Lấy tổng số bản ghi từ tham số OUT
                totalRecords = 0;
                if (cmd.Parameters["p_totalRecords"].Value != DBNull.Value)
                {
                    var oracleDecimalValue = (Oracle.ManagedDataAccess.Types.OracleDecimal)cmd.Parameters["p_totalRecords"].Value;
                    totalRecords = oracleDecimalValue.ToInt32();
                }

                // Tính toán tổng số trang
                totalPages = (int)Math.Ceiling((double)totalRecords / request.PageSize);

                // Lấy dữ liệu khách hàng
                List<DM_KHACH_HANG_Model> results = new List<DM_KHACH_HANG_Model>();
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        var result = new DM_KHACH_HANG_Model
                        {
                            id = dr["ID"] != DBNull.Value ? Convert.ToInt32(dr["ID"]) : 0,
                            ten_kh = dr["TEN_KH"] != DBNull.Value ? dr["TEN_KH"].ToString() : null,
                            ghi_chu = dr["GHI_CHU"] != DBNull.Value ? dr["GHI_CHU"].ToString() : null,
                            so_dt = dr["SO_DT"] != DBNull.Value ? dr["SO_DT"].ToString() : null,
                            email = dr["EMAIL"] != DBNull.Value ? dr["EMAIL"].ToString() : null,
                            ma_so_thue = dr["MA_SO_THUE"] != DBNull.Value ? dr["MA_SO_THUE"].ToString() : null,
                            dia_chi = dr["DIA_CHI"] != DBNull.Value ? dr["DIA_CHI"].ToString() : null
                        };
                        results.Add(result);
                    }
                }
                else
                {
                    results = new List<DM_KHACH_HANG_Model>();
                }

                return results;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
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