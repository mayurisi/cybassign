//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BookStoreMVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class Publisher
    {
        public Publisher()
        {
            this.Books = new HashSet<Book>();
        }
    
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public Nullable<long> Phone { get; set; }
    
        public virtual ICollection<Book> Books { get; set; }
    }
}
