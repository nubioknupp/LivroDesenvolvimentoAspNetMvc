using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AplicacaoComCodeFirst.Models
{
    public class BlogContext : DbContext
    {

        //public BlogContext() : base("name=BlogContext")
        //{
        //    Database.Connection.ConnectionString =
        //        @"Server=NUBIO-KNUPP\SQLEXPRESS;Database=BlogBDLivro;User Id=sa;Password=a50b21c7;";

        //    // @" driver={SQL Server};server=NUBIO-KNUPP\SQLEXPRESS;database=BlogBDLivro;uid=sa;pwd=a50b21c7;";

        //    //            Database.Connection.ConnectionString =
        //    //                            @"data source=NUBIO-KNUPP\SQLEXPRESS;
        //    //                initial catalog=BlogBDLivro;Integrated Security=SSPI;";

        //    //@" driver={SQL Server};server=NUBIO-KNUPP\SQLEXPRESS;database=BlogBDLivro;uid=sa;pwd=a50b21c7;";
        //}

        public DbSet<Posts> Posts { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
    }
}