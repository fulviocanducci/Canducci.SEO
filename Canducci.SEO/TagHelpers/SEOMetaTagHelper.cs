using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Threading.Tasks;

namespace Canducci.SEO.TagHelpers
{
    [HtmlTargetElement("seo", Attributes = DataAttributeName)]
    public class SEOMetaTagHelper : TagHelper
    {
        private const string DataAttributeName = "items";
        public SEOMetaTagHelper()
        {
        }

        [HtmlAttributeName(DataAttributeName)]
        public SEOMeta Data { get; set; }

        protected void Render(TagHelperContext context, TagHelperOutput output)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            if (output == null)
            {
                throw new ArgumentNullException(nameof(output));
            }

            if (Data != null)
            {
                foreach (var meta in Data)
                {
                    if (meta is MetaName metaName)
                    {
                        output.Content.AppendHtmlLine(metaName);
                    }
                    if (meta is MetaProperty metaProperty)
                    {
                        output.Content.AppendHtmlLine(metaProperty);
                    }                    
                }
                output.TagName = "";
            }
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            Render(context, output);
        }

        public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
        {
            var childContent = await output.GetChildContentAsync();
            if (childContent.IsEmptyOrWhiteSpace)
            {
                Render(context, output);
            }
        }
    }
}
