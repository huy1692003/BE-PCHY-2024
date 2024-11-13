using APIPCHY.Helpers;
using APIPCHY_PhanQuyen.Services;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace APIPCHY_PhanQuyen.Models.QLKC.HT_NGUOIDUNG
{
    public class HT_NGUOIDUNG_Manager
    {

        private readonly IConfiguration _configuration; // Thêm biến cấu hình

        public HT_NGUOIDUNG_Manager(IConfiguration configuration)
        {
            _configuration = configuration; // Khởi tạo biến cấu hình
        }

        DataHelper helper = new DataHelper();

        private string secret;

        public HT_NGUOIDUNG_Model login_HT_NGUOIDUNG(string username, string password)
        {
            try
            {
                DataTable ds = helper.ExcuteReader("PKG_QLKC_THUAN.login_HT_NGUOIDUNG", "p_TEN_DANG_NHAP", "p_MAT_KHAU", username, password);
                if (ds != null && ds.Rows.Count > 0)
                {
                    HT_NGUOIDUNG_Model user = new HT_NGUOIDUNG_Model();
                    user.id = ds.Rows[0]["ID"] != DBNull.Value ? ds.Rows[0]["ID"].ToString() : null;
                    user.dm_donvi_id = ds.Rows[0]["DM_DONVI_ID"] != DBNull.Value ? ds.Rows[0]["DM_DONVI_ID"].ToString():null;
                    user.ten_donvi = ds.Rows[0]["TEN"] != DBNull.Value ? ds.Rows[0]["TEN"].ToString() : null;
                    user.dm_phongban_id = ds.Rows[0]["DM_PHONGBAN_ID"] != DBNull.Value ? ds.Rows[0]["DM_PHONGBAN_ID"].ToString() : null;
                    user.ten_phongban = ds.Rows[0]["TEN_PB"] != DBNull.Value ? ds.Rows[0]["TEN_PB"].ToString() : null;
                    user.dm_kieucanbo_id = ds.Rows[0]["DM_KIEUCANBO_ID"] != DBNull.Value ? ds.Rows[0]["DM_KIEUCANBO_ID"].ToString() : null;
                    user.dm_chucvu_id = ds.Rows[0]["DM_CHUCVU_ID"] != DBNull.Value ? ds.Rows[0]["DM_CHUCVU_ID"].ToString() : null;
                    user.ten_dang_nhap = ds.Rows[0]["TEN_DANG_NHAP"] != DBNull.Value ? ds.Rows[0]["TEN_DANG_NHAP"].ToString() : null;
                    user.mat_khau = ds.Rows[0]["MAT_KHAU"] != DBNull.Value ? ds.Rows[0]["MAT_KHAU"].ToString() : null;
                    user.ho_ten = ds.Rows[0]["HO_TEN"] != DBNull.Value ? ds.Rows[0]["HO_TEN"].ToString() : null;
                    user.email = ds.Rows[0]["EMAIL"] != DBNull.Value ? ds.Rows[0]["EMAIL"].ToString() : null;
                    user.ldap = ds.Rows[0]["LDAP"] != DBNull.Value ? ds.Rows[0]["LDAP"].ToString() : null;
                    user.trang_thai = ds.Rows[0]["TRANG_THAI"] != DBNull.Value ? int.Parse(ds.Rows[0]["TRANG_THAI"].ToString()) : null;
                    user.ngay_tao = ds.Rows[0]["NGAY_TAO"] != DBNull.Value ? DateTime.Parse(ds.Rows[0]["NGAY_TAO"].ToString()) : null;
                    user.nguoi_tao = ds.Rows[0]["NGUOI_TAO"] != DBNull.Value ? ds.Rows[0]["NGUOI_TAO"].ToString() : null;
                    user.ngay_cap_nhat = ds.Rows[0]["NGAY_CAP_NHAT"] != DBNull.Value ? DateTime.Parse(ds.Rows[0]["NGAY_CAP_NHAT"].ToString()) : null;
                    user.nguoi_cap_nhat = ds.Rows[0]["NGUOI_CAP_NHAT"] != DBNull.Value ? ds.Rows[0]["NGUOI_CAP_NHAT"].ToString() : null;
                    user.so_dien_thoai = ds.Rows[0]["SO_DIEN_THOAI"] != DBNull.Value ? ds.Rows[0]["SO_DIEN_THOAI"].ToString() : null;
                    user.gioi_tinh = ds.Rows[0]["GIOI_TINH"] != DBNull.Value ? int.Parse(ds.Rows[0]["GIOI_TINH"].ToString()) : null;
                    user.so_cmnd = ds.Rows[0]["SO_CMND"] != DBNull.Value ? ds.Rows[0]["SO_CMND"].ToString() : null;
                    user.trang_thai_dong_bo = ds.Rows[0]["TRANG_THAI_DONG_BO"] != DBNull.Value ? int.Parse(ds.Rows[0]["TRANG_THAI_DONG_BO"].ToString()) : null;
                    user.db_taikhoandangnhap = ds.Rows[0]["DB_TAIKHOANDANGNHAP"] != DBNull.Value ? ds.Rows[0]["DB_TAIKHOANDANGNHAP"].ToString() : null;
                    user.db_ngay = ds.Rows[0]["DB_NGAY"] != DBNull.Value ? DateTime.Parse(ds.Rows[0]["DB_NGAY"].ToString()) : null;
                    user.db_donvi_lamviec_id = ds.Rows[0]["DM_DONVI_LAMVIEC_ID"] != DBNull.Value ? ds.Rows[0]["DM_DONVI_LAMVIEC_ID"].ToString() : null;
                    user.ht_vaitro_id = ds.Rows[0]["HT_VAITRO_ID"] != DBNull.Value ? ds.Rows[0]["HT_VAITRO_ID"].ToString() : null;
                    user.sign_alias = ds.Rows[0]["SIGN_ALIAS"] != DBNull.Value ? ds.Rows[0]["SIGN_ALIAS"].ToString() : null;
                    user.sign_username = ds.Rows[0]["SIGN_USERNAME"] != DBNull.Value ? ds.Rows[0]["SIGN_USERNAME"].ToString() : null;
                    user.sign_password = ds.Rows[0]["SIGN_PASSWORD"] != DBNull.Value ? ds.Rows[0]["SIGN_PASSWORD"].ToString() : null;
                    user.hrms_type = ds.Rows[0]["HRMS_TYPE"] != DBNull.Value ? int.Parse(ds.Rows[0]["HRMS_TYPE"].ToString()) : null;
                    user.sign_image = ds.Rows[0]["SIGN_IMAGE"] != DBNull.Value ? ds.Rows[0]["SIGN_IMAGE"].ToString() : null;
                    user.anhchukynhay = ds.Rows[0]["ANHCHUKYNHAY"] != DBNull.Value ? ds.Rows[0]["ANHCHUKYNHAY"].ToString() : null;
                    user.roleid = ds.Rows[0]["ROLEID"] != DBNull.Value ? ds.Rows[0]["ROLEID"].ToString() : null;
                    user.phong_ban = ds.Rows[0]["PHONG_BAN"] != DBNull.Value ? ds.Rows[0]["PHONG_BAN"].ToString() : null;
                    user.anhdaidien = ds.Rows[0]["ANHDAIDIEN"] != DBNull.Value ? ds.Rows[0]["ANHDAIDIEN"].ToString() : null;

                    TokenService tokenService = new TokenService(_configuration);

                    string token = tokenService.GenerateJwtToken(user);
                    user.token = token;

                    return user;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public List<HTNguoiDungDTO> GET_HT_NGUOIDUNG(int pageIndex, int pageSize, out long total)
        {
            List<HTNguoiDungDTO> result = new List<HTNguoiDungDTO>();

            using (OracleConnection cn = new ConnectionOracle().getConnection())
            {
                cn.Open();
                try
                {
                    OracleCommand cmd = new OracleCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = @"PKG_QLTN_TANH.get_ALL_NGUOIDUNG";

                    cmd.Parameters.Add("p_pageIndex", OracleDbType.Int32).Value = pageIndex;
                    cmd.Parameters.Add("p_pageSize", OracleDbType.Int32).Value = pageSize;

                    cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("p_totalRecords", OracleDbType.Int32).Direction = ParameterDirection.Output;

                    OracleDataAdapter dap = new OracleDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    dap.Fill(ds);

                    // Xử lý dữ liệu phân trang
                    if (ds.Tables.Count > 0)
                    {
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            HTNguoiDungDTO user = new HTNguoiDungDTO
                            {
                                ID = dr["ID"].ToString(),
                                DM_DONVI_ID = dr["DM_DONVI_ID"].ToString(),
                                DM_PHONGBAN_ID = dr["DM_PHONGBAN_ID"].ToString(),
                                DM_CHUCVU_ID = dr["DM_CHUCVU_ID"].ToString(),
                                TEN_DANG_NHAP = dr["TEN_DANG_NHAP"].ToString(),
                                MAT_KHAU = dr["MAT_KHAU"].ToString(),
                                HO_TEN = dr["HO_TEN"].ToString(),
                                EMAIL = dr["EMAIL"].ToString(),
                                LDAP = dr["LDAP"].ToString(),
                                TRANG_THAI = dr["TRANG_THAI"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["TRANG_THAI"]),
                                NGAY_TAO = dr["NGAY_TAO"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["NGAY_TAO"]),
                                NGUOI_TAO = dr["NGUOI_TAO"].ToString(),
                                NGAY_CAP_NHAT = dr["NGAY_CAP_NHAT"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dr["NGAY_CAP_NHAT"]),
                                NGUOI_CAP_NHAT = dr["NGUOI_CAP_NHAT"].ToString(),
                                SO_DIEN_THOAI = dr["SO_DIEN_THOAI"].ToString(),
                                GIOI_TINH = dr["GIOI_TINH"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["GIOI_TINH"]),
                                SO_CMND = dr["SO_CMND"].ToString(),
                                TRANG_THAI_DONG_BO = dr["TRANG_THAI_DONG_BO"] == DBNull.Value ? (int?)null : Convert.ToInt32(dr["TRANG_THAI_DONG_BO"]),
                                ROLEID = dr["ROLEID"].ToString(),
                                PHONG_BAN = dr["PHONG_BAN"].ToString(),
                                ANHDAIDIEN = dr["ANHDAIDIEN"].ToString()
                            };

                            result.Add(user);
                        }
                    }

                    // Lấy tổng số bản ghi
                    var totalRecord = Convert.ToInt64(cmd.Parameters["p_totalRecords"].Value.ToString());
                    total = (long)Math.Ceiling((double)totalRecord / pageSize);
                }
                catch (Exception ex)
                {
                    throw new Exception("An error occurred while fetching data.", ex);
                }
            }

            return result;
        }





        //them nguoi dung
        public HTNguoiDungDTO Insert_QLTN_NGUOI_DUNG(HTNguoiDungDTO data)
        {
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cn;
            OracleTransaction transaction;
            transaction = cn.BeginTransaction();
            cmd.Transaction = transaction;

            try
            {
                string hashPassword=PasswordHasher.HashString(data.MAT_KHAU);
                cmd.Parameters.Clear();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLTN_TANH.insert_HT_NGUOIDUNG";
                cmd.Parameters.Add("p_DM_DONVI_ID", OracleDbType.Varchar2).Value = data.DM_DONVI_ID;
                cmd.Parameters.Add("p_DM_PHONGBAN_ID", OracleDbType.Varchar2).Value = data.DM_PHONGBAN_ID;
                cmd.Parameters.Add("p_DM_KIEUCANBO_ID", OracleDbType.Varchar2).Value = data.DM_KIEUCANBO_ID;
                cmd.Parameters.Add("p_DM_CHUCVU_ID", OracleDbType.Varchar2).Value = data.DM_CHUCVU_ID;
                cmd.Parameters.Add("p_TEN_DANG_NHAP", OracleDbType.Varchar2).Value = data.TEN_DANG_NHAP;
                cmd.Parameters.Add("p_MAT_KHAU", OracleDbType.Varchar2).Value =hashPassword;
                cmd.Parameters.Add("p_HO_TEN", OracleDbType.Varchar2).Value = data.HO_TEN;
                cmd.Parameters.Add("p_EMAIL", OracleDbType.Varchar2).Value = data.EMAIL;
                cmd.Parameters.Add("p_LDAP", OracleDbType.Varchar2).Value = data.LDAP;
                cmd.Parameters.Add("p_TRANG_THAI", OracleDbType.Int32).Value = data.TRANG_THAI;
                cmd.Parameters.Add("p_NGAY_TAO", OracleDbType.Date).Value = data.NGAY_TAO != DateTime.MinValue ? (object)data.NGAY_TAO : DBNull.Value;
                cmd.Parameters.Add("p_NGUOI_TAO", OracleDbType.Varchar2).Value = data.NGUOI_TAO;
                cmd.Parameters.Add("p_NGAY_CAP_NHAT", OracleDbType.Date).Value = data.NGAY_CAP_NHAT != DateTime.MinValue ? (object)data.NGAY_CAP_NHAT : DBNull.Value;
                cmd.Parameters.Add("p_NGUOI_CAP_NHAT", OracleDbType.Varchar2).Value = data.NGUOI_CAP_NHAT;
                cmd.Parameters.Add("p_SO_DIEN_THOAI", OracleDbType.Varchar2).Value = data.SO_DIEN_THOAI;
                cmd.Parameters.Add("p_GIOI_TINH", OracleDbType.Int32).Value = data.GIOI_TINH;
                cmd.Parameters.Add("p_SO_CMND", OracleDbType.Varchar2).Value = data.SO_CMND;
                cmd.Parameters.Add("p_TRANG_THAI_DONG_BO", OracleDbType.Int32).Value = data.TRANG_THAI_DONG_BO;
                cmd.Parameters.Add("p_DB_TAIKHOANDANGNHAP", OracleDbType.Varchar2).Value = data.DB_TAIKHOANDANGNHAP;
                cmd.Parameters.Add("p_DB_NGAY", OracleDbType.Date).Value = data.DB_NGAY != DateTime.MinValue ? (object)data.DB_NGAY : DBNull.Value;
                cmd.Parameters.Add("p_DM_DONVI_LAMVIEC_ID", OracleDbType.Varchar2).Value = data.DM_DONVI_LAMVIEC_ID;
                cmd.Parameters.Add("p_HT_VAITRO_ID", OracleDbType.Varchar2).Value = data.HT_VAITRO_ID;
                cmd.Parameters.Add("p_SIGN_ALIAS", OracleDbType.Varchar2).Value = data.SIGN_ALIAS;
                cmd.Parameters.Add("p_SIGN_USERNAME", OracleDbType.Varchar2).Value = data.SIGN_USERNAME;
                cmd.Parameters.Add("p_SIGN_PASSWORD", OracleDbType.Varchar2).Value = data.SIGN_PASSWORD;
                cmd.Parameters.Add("p_HRMS_TYPE", OracleDbType.Int32).Value = data.HRMS_TYPE; // Đảm bảo giá trị là số nguyên
                cmd.Parameters.Add("p_SIGN_IMAGE", OracleDbType.Varchar2).Value = data.SIGN_IMAGE;
                cmd.Parameters.Add("p_ANHCHUKYNHAY", OracleDbType.Varchar2).Value = data.ANHCHUKYNHAY;
                cmd.Parameters.Add("p_ROLEID", OracleDbType.Varchar2).Value = data.ROLEID;
                cmd.Parameters.Add("p_PHONG_BAN", OracleDbType.Varchar2).Value = data.PHONG_BAN;
                cmd.Parameters.Add("p_ANHDAIDIEN", OracleDbType.Varchar2).Value = data.ANHDAIDIEN;
                cmd.Parameters.Add("p_Error", OracleDbType.Varchar2, 4000).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                transaction.Commit();
                return data;
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



        //get by id nguoi dung
        public HTNguoiDungDTO GETDATA_DM_NGUOIDUNG_byID(string Id)
        {
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleDataAdapter dap = new OracleDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLTN_TANH.get_HT_NGUOIDUNG_byID";
                cmd.Parameters.Add("p_ID", Id);
                cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }


                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    DataRow dr = ds.Tables[0].Rows[0];
                    HTNguoiDungDTO result = new HTNguoiDungDTO
                    {
                        ID = dr["ID"].ToString(),
                        TEN_DON_VI = dr["TEN_DON_VI"].ToString(),
                        TEN_PHONG_BAN = dr["TEN_PHONG_BAN"].ToString(),
                        TEN_CHUC_VU = dr["TEN_CHUC_VU"].ToString(),
                        TEN_DANG_NHAP = dr["TEN_DANG_NHAP"].ToString(),
                        HO_TEN = dr["HO_TEN"].ToString(),
                        EMAIL = dr["EMAIL"].ToString(),
                        LDAP = dr["LDAP"].ToString(),
                        TRANG_THAI = dr["TRANG_THAI"] != DBNull.Value ? Convert.ToInt32(dr["TRANG_THAI"]) : (int?)null,
                        NGAY_TAO = dr["NGAY_TAO"] != DBNull.Value ? Convert.ToDateTime(dr["NGAY_TAO"]) : (DateTime?)null,
                        NGUOI_TAO = dr["NGUOI_TAO"].ToString(),
                        NGAY_CAP_NHAT = dr["NGAY_CAP_NHAT"] != DBNull.Value ? Convert.ToDateTime(dr["NGAY_CAP_NHAT"]) : (DateTime?)null,
                        NGUOI_CAP_NHAT = dr["NGUOI_CAP_NHAT"].ToString(),
                        SO_DIEN_THOAI = dr["SO_DIEN_THOAI"].ToString(),
                        GIOI_TINH = dr["GIOI_TINH"] != DBNull.Value ? Convert.ToInt32(dr["GIOI_TINH"]) : (int?)null,
                        TRANG_THAI_DONG_BO = dr["TRANG_THAI_DONG_BO"] != DBNull.Value ? Convert.ToInt32(dr["TRANG_THAI_DONG_BO"]) : (int?)null,
                        DB_TAIKHOANDANGNHAP = dr["DB_TAIKHOANDANGNHAP"].ToString(),
                        DB_NGAY = dr["DB_NGAY"] != DBNull.Value ? Convert.ToDateTime(dr["DB_NGAY"]) : (DateTime?)null,
                        DM_DONVI_LAMVIEC_ID = dr["DM_DONVI_LAMVIEC_ID"].ToString(),
                        HT_VAITRO_ID = dr["HT_VAITRO_ID"].ToString(),
                    };

                    return result;
                }
                else
                {
                    return null;
                }

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


        public HTNguoiDungDTO Update_HT_NGUOIDUNG(HTNguoiDungDTO nguoidung)
        {
            using (OracleConnection cn = new ConnectionOracle().getConnection())
            {
                cn.Open();

                using (OracleCommand cmd = new OracleCommand())
                {
                    using (OracleTransaction transaction = cn.BeginTransaction())
                    {
                        cmd.Connection = cn;
                        cmd.Transaction = transaction;

                        try
                        {
                            cmd.Parameters.Clear();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = @"PKG_QLTN_TANH.update_HT_NGUOIDUNG";

                            cmd.Parameters.Add("p_ID", OracleDbType.Varchar2).Value = nguoidung.ID;
                            cmd.Parameters.Add("p_DM_DONVI_ID", OracleDbType.Varchar2).Value = nguoidung.DM_DONVI_ID;
                            cmd.Parameters.Add("p_DM_PHONGBAN_ID", OracleDbType.Varchar2).Value = nguoidung.DM_PHONGBAN_ID;
                            cmd.Parameters.Add("p_DM_KIEUCANBO_ID", OracleDbType.Varchar2).Value = nguoidung.DM_KIEUCANBO_ID;
                            cmd.Parameters.Add("p_DM_CHUCVU_ID", OracleDbType.Varchar2).Value = nguoidung.DM_CHUCVU_ID;
                            cmd.Parameters.Add("p_TEN_DANG_NHAP", OracleDbType.Varchar2).Value = nguoidung.TEN_DANG_NHAP;
                            cmd.Parameters.Add("p_MAT_KHAU", OracleDbType.Varchar2).Value = nguoidung.MAT_KHAU;
                            cmd.Parameters.Add("p_HO_TEN", OracleDbType.Varchar2).Value = nguoidung.HO_TEN;
                            cmd.Parameters.Add("p_EMAIL", OracleDbType.Varchar2).Value = nguoidung.EMAIL;
                            cmd.Parameters.Add("p_LDAP", OracleDbType.Varchar2).Value = nguoidung.LDAP;
                            cmd.Parameters.Add("p_TRANG_THAI", OracleDbType.Int32).Value = nguoidung.TRANG_THAI;
                            cmd.Parameters.Add("p_NGAY_TAO", OracleDbType.Date).Value = nguoidung.NGAY_TAO ?? (object)DBNull.Value;
                            cmd.Parameters.Add("p_NGUOI_TAO", OracleDbType.Varchar2).Value = nguoidung.NGUOI_TAO;
                            cmd.Parameters.Add("p_NGAY_CAP_NHAT", OracleDbType.Date).Value = nguoidung.NGAY_CAP_NHAT ?? (object)DBNull.Value;
                            cmd.Parameters.Add("p_NGUOI_CAP_NHAT", OracleDbType.Varchar2).Value = nguoidung.NGUOI_CAP_NHAT;
                            cmd.Parameters.Add("p_SO_DIEN_THOAI", OracleDbType.Varchar2).Value = nguoidung.SO_DIEN_THOAI;
                            cmd.Parameters.Add("p_GIOI_TINH", OracleDbType.Int32).Value = nguoidung.GIOI_TINH ?? (object)DBNull.Value;
                            cmd.Parameters.Add("p_SO_CMND", OracleDbType.Varchar2).Value = nguoidung.SO_CMND;
                            cmd.Parameters.Add("p_TRANG_THAI_DONG_BO", OracleDbType.Int32).Value = nguoidung.TRANG_THAI_DONG_BO ?? (object)DBNull.Value;
                            cmd.Parameters.Add("p_DB_TAIKHOANDANGNHAP", OracleDbType.Varchar2).Value = nguoidung.DB_TAIKHOANDANGNHAP;
                            cmd.Parameters.Add("p_DB_NGAY", OracleDbType.Date).Value = nguoidung.DB_NGAY ?? (object)DBNull.Value;
                            cmd.Parameters.Add("p_DM_DONVI_LAMVIEC_ID", OracleDbType.Varchar2).Value = nguoidung.DM_DONVI_LAMVIEC_ID;
                            cmd.Parameters.Add("p_HT_VAITRO_ID", OracleDbType.Varchar2).Value = nguoidung.HT_VAITRO_ID;
                            cmd.Parameters.Add("p_SIGN_ALIAS", OracleDbType.Varchar2).Value = nguoidung.SIGN_ALIAS;
                            cmd.Parameters.Add("p_SIGN_USERNAME", OracleDbType.Varchar2).Value = nguoidung.SIGN_USERNAME;
                            cmd.Parameters.Add("p_SIGN_PASSWORD", OracleDbType.Varchar2).Value = nguoidung.SIGN_PASSWORD;
                            cmd.Parameters.Add("p_HRMS_TYPE", OracleDbType.Int32).Value = nguoidung.HRMS_TYPE ?? (object)DBNull.Value;
                            cmd.Parameters.Add("p_SIGN_IMAGE", OracleDbType.Varchar2).Value = nguoidung.SIGN_IMAGE;
                            cmd.Parameters.Add("p_ANHCHUKYNHAY", OracleDbType.Varchar2).Value = nguoidung.ANHCHUKYNHAY;
                            cmd.Parameters.Add("p_ROLEID", OracleDbType.Varchar2).Value = nguoidung.ROLEID;
                            cmd.Parameters.Add("p_PHONG_BAN", OracleDbType.Varchar2).Value = nguoidung.PHONG_BAN;
                            cmd.Parameters.Add("p_ANHDAIDIEN", OracleDbType.Varchar2).Value = nguoidung.ANHDAIDIEN;

                            cmd.ExecuteNonQuery();
                            transaction.Commit();

                            return nguoidung;
                        }
                        catch (Exception ex)
                        {
                            throw ex;
                        }
                    }
                }
            }
        }



        public List<UserResponse> FILTER_HT_NGUOIDUNG(UserFilterRequest request)
        {
            OracleConnection cn = new ConnectionOracle().getConnection();
            try
            {
                cn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PKG_QLTN_TANH.search_HT_NGUOIDUNG";

                // Add input parameters with checks for null or empty
                cmd.Parameters.Add("p_HO_TEN", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(request.HO_TEN) ? (object)DBNull.Value : request.HO_TEN;
                cmd.Parameters.Add("p_TEN_DANG_NHAP", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(request.TEN_DANG_NHAP) ? (object)DBNull.Value : request.TEN_DANG_NHAP;
                cmd.Parameters.Add("p_TRANG_THAI", OracleDbType.Int32).Value = request.TRANG_THAI.HasValue ? (object)request.TRANG_THAI.Value : DBNull.Value;
                cmd.Parameters.Add("p_DM_DONVI_ID", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(request.DM_DONVI_ID) ? (object)DBNull.Value : request.DM_DONVI_ID;
                cmd.Parameters.Add("p_DM_PHONGBAN_ID", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(request.DM_PHONGBAN_ID) ? (object)DBNull.Value : request.DM_PHONGBAN_ID;
                cmd.Parameters.Add("p_DM_CHUCVU_ID", OracleDbType.Varchar2).Value = string.IsNullOrEmpty(request.DM_CHUCVU_ID) ? (object)DBNull.Value : request.DM_CHUCVU_ID;

                cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                OracleDataAdapter dap = new OracleDataAdapter(cmd);
                DataSet ds = new DataSet();
                dap.Fill(ds);

                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    List<UserResponse> results = new List<UserResponse>();
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        UserResponse result = new UserResponse
                        {
                            HO_TEN = dr["HO_TEN"] != DBNull.Value ? dr["HO_TEN"].ToString() : null,
                            TEN_DANG_NHAP = dr["TEN_DANG_NHAP"] != DBNull.Value ? dr["TEN_DANG_NHAP"].ToString() : null,
                            TRANG_THAI = dr["TRANG_THAI"] != DBNull.Value ? Convert.ToInt32(dr["TRANG_THAI"]) : 0,
                            TEN_DONVI = dr["TEN_DONVI"] != DBNull.Value ? dr["TEN_DONVI"].ToString() : null,
                            TEN_PHONGBAN = dr["TEN_PHONGBAN"] != DBNull.Value ? dr["TEN_PHONGBAN"].ToString() : null,
                            TEN_CHUCVU = dr["TEN_CHUCVU"] != DBNull.Value ? dr["TEN_CHUCVU"].ToString() : null,
                            EMAIL = dr["EMAIL"] != DBNull.Value ? dr["EMAIL"].ToString() : null,
                        };
                        results.Add(result);
                    }
                    return results;
                }
                else
                {
                    return new List<UserResponse>();
                }
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

        //Đổi mật khẩu người dùng 
        public string Reset_Password_HT_NGUOIDUNG(string ID, string currentPassword, string newPassword)
        {
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = cn;
            OracleTransaction transaction = cn.BeginTransaction();
            cmd.Transaction = transaction;
            try
            {
                string hashedPasswordFromDB = Get_HT_NGUOIDUNG_Password(ID);
                if (!PasswordHasher.VerifyHashedString(hashedPasswordFromDB, currentPassword))
                {
                    return "Mật khẩu hiện tại không chính xác.";
                }

                string hashedNewPassword = PasswordHasher.HashString(newPassword);
                cmd.Parameters.Clear();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = @"PKG_QLTN_DAT.update_password_HT_NGUOIDUNG";
                cmd.Parameters.Add("p_USER_ID", ID);
                cmd.Parameters.Add("p_NEW_PASSWORD", hashedNewPassword);
                cmd.Parameters.Add("p_Error", OracleDbType.NVarchar2, 200).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                transaction.Commit();
                return "Cập nhật mật khẩu thành công.";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return $"Có lỗi xảy ra: {ex.Message}";
            }
            finally
            {
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }
            }
        }


        public string Get_HT_NGUOIDUNG_Password(string ID)
        {
            string password = null;
            string strErr = "";
            OracleConnection cn = new ConnectionOracle().getConnection();
            cn.Open();
            if (strErr != null && strErr != "")
            {
                return null;
            }
            try
            {
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = cn;
                OracleDataAdapter dap = new OracleDataAdapter();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = @"PKG_QLTN_TANH.get_HT_NGUOIDUNG_byID";
                cmd.Parameters.Add("p_ID", ID);
                cmd.Parameters.Add("p_getDB", OracleDbType.RefCursor).Direction = ParameterDirection.Output;

                dap.SelectCommand = cmd;
                DataSet ds = new DataSet();
                dap.Fill(ds);
                Console.WriteLine(ds);
                if (cn.State != ConnectionState.Closed)
                {
                    cn.Close();
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    password = ds.Tables[0].Rows[0]["MAT_KHAU"].ToString();
                }
                return password;
            }
            catch (Exception ex)
            {
                return null;
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


