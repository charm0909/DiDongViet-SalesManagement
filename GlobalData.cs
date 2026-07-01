using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DiDongViet_SalesManagement.DTO;

namespace DiDongViet_SalesManagement
{
    /// <summary>
    /// Lớp toàn cục để lưu trữ dữ liệu người dùng hiện tại
    /// </summary>
    public static class GlobalData
    {
        public static LoginDTO CurrentUser { get; set; }
    }
}
