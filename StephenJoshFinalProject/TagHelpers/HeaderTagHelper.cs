using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StephenJoshFinalProject.TagHelpers
{
    public class HeaderTagHelper: TagHelper
    {

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.TagName = "div";     //replaces the header tag with the div tag
            output.Attributes.SetAttribute("class", "alert alert-info text-center");
            //output.Content.SetContent();



            //the TagHelper header is the prefix of the TagHelper class -> "Header"TagHelper

        }


    }
}
