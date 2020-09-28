using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Canducci.SEO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebAppSeo.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }
                
        public SEOMeta SEOMeta { get; set; }
        
        public void OnGet()
        {
            SEOMeta = new SEOMeta
            {
                new MetaName("description", "Description"),
                new MetaName("keywords", "Description"),
                new MetaProperty("article:published_time", 
                    DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK")),
                new MetaProperty("article:section", "news")
            };
        }
    }
}
