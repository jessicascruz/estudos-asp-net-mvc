using System.Collections.Generic;
using System.Web;

namespace Mvc_Upload.Models
{
    public class Remessa
    {
        public IEnumerable<HttpPostedFileBase> Arquivos { get; set; }
    }
}