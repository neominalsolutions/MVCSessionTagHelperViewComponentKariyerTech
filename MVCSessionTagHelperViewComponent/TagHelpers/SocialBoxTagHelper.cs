using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCSessionTagHelperViewComponent.TagHelpers
{
    [HtmlTargetElement("social-box",Attributes = "text,count,icon-class")]
    public class SocialBoxTagHelper: TagHelper
    {
        public string Text { get; set; }
        public int Count { get; set; }
        public string IconClass { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
           
            output.Content.AppendHtml($"<div class='ui labeled button' tabindex='0'><div class='ui button'><i class='{IconClass} icon'></i> {Text}</div><a class='ui basic label'>{(String.Format("{0:n0}", Count)).Replace(".",",")}</a></div>");

            base.Process(context, output);
        }
    }
}
