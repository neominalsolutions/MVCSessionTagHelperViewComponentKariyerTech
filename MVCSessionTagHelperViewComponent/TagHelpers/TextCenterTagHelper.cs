using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSessionTagHelperViewComponent.TagHelpers
{
    [HtmlTargetElement("text-center",Attributes ="content-text")]
    public class TextCenterTagHelper: TagHelper
    {

        public string ContentText { get; set; }


        // HTML çıktı üreteceğiz
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            //<p style="text-align:center">${Content}</p>
            output.TagName = "p";
            output.Attributes.Add("style", "text-align:center");
            output.Content.SetContent(ContentText);
            base.Process(context, output);
        }

    }
}
