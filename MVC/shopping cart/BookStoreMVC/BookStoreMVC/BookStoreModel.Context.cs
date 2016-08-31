﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    using BookStoreMVC.Models;
    
    public partial class BookStoreDBEntities : DbContext
    {
        public BookStoreDBEntities()
            : base("name=BookStoreDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Book1> Books1 { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Publisher> Publishers { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }        
    
        public virtual int AddNewBook(Nullable<int> bookId, string title, string description, Nullable<int> price, Nullable<int> iSBN, Nullable<System.DateTime> publicationDate, Nullable<int> categoryId, Nullable<int> publisherId)
        {
            var bookIdParameter = bookId.HasValue ?
                new ObjectParameter("BookId", bookId) :
                new ObjectParameter("BookId", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            var descriptionParameter = description != null ?
                new ObjectParameter("Description", description) :
                new ObjectParameter("Description", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(int));
    
            var iSBNParameter = iSBN.HasValue ?
                new ObjectParameter("ISBN", iSBN) :
                new ObjectParameter("ISBN", typeof(int));
    
            var publicationDateParameter = publicationDate.HasValue ?
                new ObjectParameter("PublicationDate", publicationDate) :
                new ObjectParameter("PublicationDate", typeof(System.DateTime));
    
            var categoryIdParameter = categoryId.HasValue ?
                new ObjectParameter("CategoryId", categoryId) :
                new ObjectParameter("CategoryId", typeof(int));
    
            var publisherIdParameter = publisherId.HasValue ?
                new ObjectParameter("PublisherId", publisherId) :
                new ObjectParameter("PublisherId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("AddNewBook", bookIdParameter, titleParameter, descriptionParameter, priceParameter, iSBNParameter, publicationDateParameter, categoryIdParameter, publisherIdParameter);
        }
    
        public virtual int delete_Books_by_Id(Nullable<int> bookid)
        {
            var bookidParameter = bookid.HasValue ?
                new ObjectParameter("Bookid", bookid) :
                new ObjectParameter("Bookid", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("delete_Books_by_Id", bookidParameter);
        }
    
        public virtual ObjectResult<string> get_Books_by_Author(string authorName)
        {
            var authorNameParameter = authorName != null ?
                new ObjectParameter("AuthorName", authorName) :
                new ObjectParameter("AuthorName", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("get_Books_by_Author", authorNameParameter);
        }
    
        public virtual ObjectResult<string> get_Books_By_Author_publisher()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("get_Books_By_Author_publisher");
        }
    
        public virtual ObjectResult<get_Books_By_Each_publisher_Result> get_Books_By_Each_publisher()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<get_Books_By_Each_publisher_Result>("get_Books_By_Each_publisher");
        }
    
        public virtual ObjectResult<GetBookByAuthorCategory_Result> GetBookByAuthorCategory()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBookByAuthorCategory_Result>("GetBookByAuthorCategory");
        }
    
        public virtual ObjectResult<GetBookByCategory_Result> GetBookByCategory()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBookByCategory_Result>("GetBookByCategory");
        }
    
        public virtual ObjectResult<GetBookById_Result> GetBookById(Nullable<int> bookId)
        {
            var bookIdParameter = bookId.HasValue ?
                new ObjectParameter("BookId", bookId) :
                new ObjectParameter("BookId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBookById_Result>("GetBookById", bookIdParameter);
        }
    
        public virtual ObjectResult<GetBooksByYear_Result> GetBooksByYear(Nullable<int> year)
        {
            var yearParameter = year.HasValue ?
                new ObjectParameter("Year", year) :
                new ObjectParameter("Year", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetBooksByYear_Result>("GetBooksByYear", yearParameter);
        }
    
        public virtual int Insert_Books()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Insert_Books");
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    
        public virtual int Update_Books(Nullable<int> bookid, string title)
        {
            var bookidParameter = bookid.HasValue ?
                new ObjectParameter("Bookid", bookid) :
                new ObjectParameter("Bookid", typeof(int));
    
            var titleParameter = title != null ?
                new ObjectParameter("title", title) :
                new ObjectParameter("title", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Update_Books", bookidParameter, titleParameter);
        }
    
        public virtual int UpdateBook(string title, Nullable<int> price, Nullable<int> publisherId, Nullable<int> bookId)
        {
            var titleParameter = title != null ?
                new ObjectParameter("Title", title) :
                new ObjectParameter("Title", typeof(string));
    
            var priceParameter = price.HasValue ?
                new ObjectParameter("Price", price) :
                new ObjectParameter("Price", typeof(int));
    
            var publisherIdParameter = publisherId.HasValue ?
                new ObjectParameter("PublisherId", publisherId) :
                new ObjectParameter("PublisherId", typeof(int));
    
            var bookIdParameter = bookId.HasValue ?
                new ObjectParameter("BookId", bookId) :
                new ObjectParameter("BookId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UpdateBook", titleParameter, priceParameter, publisherIdParameter, bookIdParameter);
        }
    }
}
