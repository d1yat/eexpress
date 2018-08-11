using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EExpress.Enums
{
    public enum Status : int
    {
        Deactivate = 0,
        Activate
    }
    public enum CetakHarga : int
    {
        Tidak = 0,
        Ya
    }
    public enum Payment : int
    {
        Cash = 1,
        Credit
    }
    public enum HargaKhusus : int
    {
        Tidak = 0,
        Ya
    }
    public enum CetakPenerima : int
    {
        Tidak = 0,
        Ya
    }
    public enum HargaSpecial : int
    {
        Tidak = 0,
        Ya
    }
}