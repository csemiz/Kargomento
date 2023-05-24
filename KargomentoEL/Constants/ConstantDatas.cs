using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargomentoEL.Constants
{
    public class ConstantDatas
    {
        public static string EMPLOYEEROLE { get; set; } = "Employee";
        public static string ADMINROLE { get; set; } = "Admin";
        public static string BRANCHMANAGERROLE { get; set; } = "BranchManager";
        public static string CARGO_STATUS_CARGO_ACCEPTED { get; set; } = "Gönderi Kabul Edildi";
        public static string CARGO_STATUS_CARGO_ONWAY{ get; set; } = "Gönderi Yolda";
        public static string CARGO_STATUS_TRANSFER_CENTER { get; set; } = "Transfer Merkezinde";
        public static string CARGO_STATUS_DELIVERY_BRANCH { get; set; } = "Teslimat Şubesinde";
        public static string CARGO_STATUS_CARGO_DISTRIBUTION { get; set; } = "Gönderi Dağıtıma Çıktı";
        public static string CARGO_STATUS_CARGO_DELIVERED { get; set; } = "Teslim Edildi";

    }
}
