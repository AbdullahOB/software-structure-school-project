//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace YZMYapimiProjesi.DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class KullaniciRole
    {
        public int Id { get; set; }
        public int RoleId { get; set; }
        public int KullaniciId { get; set; }
    
        public virtual KullaniciTable KullaniciTable { get; set; }
        public virtual Role Role { get; set; }
    }
}