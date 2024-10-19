using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MauDoan.Context;
using MauDoan.Models;

namespace MauDoan.Context
{
    [MetadataType(typeof(UserMasterData))]

    public partial class User
    {
       
    }

    public partial class ProductMasterData
    {
        [NotMapped]

        public System.Web.HttpPostedFileBase ImageUpload { get; set; }
    }
}