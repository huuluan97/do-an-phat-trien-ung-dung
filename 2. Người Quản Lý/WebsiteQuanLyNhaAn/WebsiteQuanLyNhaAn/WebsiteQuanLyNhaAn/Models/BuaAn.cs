//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebsiteQuanLyNhaAn.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class BuaAn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BuaAn()
        {
            this.ChiTietBuaAns = new HashSet<ChiTietBuaAn>();
        }
    
        public int MaBuaAn { get; set; }
        public int SoLuong { get; set; }
        public System.DateTime NgayAn { get; set; }
        public int MaNV { get; set; }
    
        public virtual TaiKhoan TaiKhoan { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietBuaAn> ChiTietBuaAns { get; set; }
    }
}
