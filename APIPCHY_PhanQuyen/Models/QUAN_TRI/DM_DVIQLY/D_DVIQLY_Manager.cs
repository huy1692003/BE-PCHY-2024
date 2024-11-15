using APIPCHY.Helpers;
using System.Collections.Generic;
using System.Data;
using System;
namespace APIPCHY_PhanQuyen.Models.QLKC.D_DVIQLY
{
    public class D_DVIQLY_Manager
    {
        DataHelper helper = new DataHelper();
        public List<D_DVIQLY_Model> getAllD_DVIQLY()
        {
            try
            {
                DataTable tb = helper.ExcuteReader("PKG_QLKC_SANG.getAllDM_DVIQLY");
                List<D_DVIQLY_Model> result = new List<D_DVIQLY_Model>();
                if (tb != null)
                {
                    for (int i = 0; i < tb.Rows.Count; i++)
                    {
                        D_DVIQLY_Model model = new D_DVIQLY_Model();
                        model.DM_DONVI_KPI_NPC = tb.Rows[i]["DM_DONVI_KPI_NPC"] != DBNull.Value ? tb.Rows[i]["DM_DONVI_KPI_NPC"].ToString() : null;
                        model.MA_DVIQLY = tb.Rows[i]["MA_DVIQLY"] != DBNull.Value ? tb.Rows[i]["MA_DVIQLY"].ToString() : null;
                        model.TEN_DVIQLY = tb.Rows[i]["TEN_DVIQLY"] != DBNull.Value ? tb.Rows[i]["TEN_DVIQLY"].ToString() : null;
                        model.MA_DVICTREN = tb.Rows[i]["MA_DVICTREN"] != DBNull.Value ? tb.Rows[i]["MA_DVICTREN"].ToString() : null;
                        model.CAP_DVI = tb.Rows[i]["CAP_DVI"] != DBNull.Value ? int.Parse(tb.Rows[i]["CAP_DVI"].ToString()) : null;
                        model.DIA_CHI = tb.Rows[i]["DIA_CHI"] != DBNull.Value ? tb.Rows[i]["DIA_CHI"].ToString() : null;
                        model.ID_DIA_CHINH = tb.Rows[i]["ID_DIA_CHINH"] != DBNull.Value ? int.Parse(tb.Rows[i]["ID_DIA_CHINH"].ToString()) : null;
                        model.DIEN_THOAI = tb.Rows[i]["DIEN_THOAI"] != DBNull.Value ? tb.Rows[i]["DIEN_THOAI"].ToString() : null;
                        model.DTHOAI_KDOANH = tb.Rows[i]["DTHOAI_KDOANH"] != DBNull.Value ? tb.Rows[i]["DTHOAI_KDOANH"].ToString() : null;
                        model.DTHOAI_NONG = tb.Rows[i]["DTHOAI_NONG"] != DBNull.Value ? tb.Rows[i]["DTHOAI_NONG"].ToString() : null;
                        model.DTHOAI_TRUC = tb.Rows[i]["DTHOAI_TRUC"] != DBNull.Value ? tb.Rows[i]["DTHOAI_TRUC"].ToString() : null;
                        model.FAX = tb.Rows[i]["FAX"] != DBNull.Value ? tb.Rows[i]["FAX"].ToString() : null;
                        model.EMAIL = tb.Rows[i]["EMAIL"] != DBNull.Value ? tb.Rows[i]["EMAIL"].ToString() : null;
                        model.MA_STHUE = tb.Rows[i]["MA_STHUE"] != DBNull.Value ? tb.Rows[i]["MA_STHUE"].ToString() : null;
                        model.DAI_DIEN = tb.Rows[i]["DAI_DIEN"] != DBNull.Value ? tb.Rows[i]["DAI_DIEN"].ToString() : null;
                        model.CHUC_VU = tb.Rows[i]["CHUC_VU"] != DBNull.Value ? tb.Rows[i]["CHUC_VU"].ToString() : null;
                        model.SO_UQUYEN = tb.Rows[i]["SO_UQUYEN"] != DBNull.Value ? tb.Rows[i]["SO_UQUYEN"].ToString() : null;
                        model.NGAY_UQUYEN = tb.Rows[i]["NGAY_UQUYEN"] != DBNull.Value ? DateTime.Parse(tb.Rows[i]["NGAY_UQUYEN"].ToString()) : null;
                        model.TEN_DVIUQ = tb.Rows[i]["TEN_DVIUQ"] != DBNull.Value ? tb.Rows[i]["TEN_DVIUQ"].ToString() : null;
                        model.DCHI_DVIUQ = tb.Rows[i]["DCHI_DVIUQ"] != DBNull.Value ? tb.Rows[i]["DCHI_DVIUQ"].ToString() : null;
                        model.CVU_UQUYEN = tb.Rows[i]["CVU_UQUYEN"] != DBNull.Value ? tb.Rows[i]["CVU_UQUYEN"].ToString() : null;
                        model.TNGUOI_UQUYEN = tb.Rows[i]["TNGUOI_UQUYEN"] != DBNull.Value ? tb.Rows[i]["TNGUOI_UQUYEN"].ToString() : null;
                        model.TEN_TINH = tb.Rows[i]["TEN_TINH"] != DBNull.Value ? tb.Rows[i]["TEN_TINH"].ToString() : null;
                        model.WEBSITE = tb.Rows[i]["WEBSITE"] != DBNull.Value ? tb.Rows[i]["WEBSITE"].ToString() : null;
                        model.DB_MADONVI_FMIS = tb.Rows[i]["DB_MADONVI_FMIS"] != DBNull.Value ? tb.Rows[i]["DB_MADONVI_FMIS"].ToString() : null;
                        result.Add(model);

                    }
                }
                else result = null;
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
