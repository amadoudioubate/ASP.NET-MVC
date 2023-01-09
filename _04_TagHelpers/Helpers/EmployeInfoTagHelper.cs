using Microsoft.AspNetCore.Razor.TagHelpers;

namespace _04_TagHelpers.Helpers
{
    public class EmployeInfoTagHelper : TagHelper
    {
        [HtmlAttributeName("for-name")]
        
        public string Name { get; set; } = String.Empty;

        [HtmlAttributeName("for-salary")] 
        public string Salary { get; set; } = String.Empty;

        [HtmlAttributeName("for-type")]
        public string Type { get; set; } = String.Empty;

        [HtmlAttributeName("for-email")]
        public string Email { get; set; } = String.Empty;


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";

            output.Attributes.SetAttribute("class", "text-danger");
            
            output.TagMode = TagMode.StartTagAndEndTag;

            output.PreContent.SetHtmlContent($"{Email} {Name} est {Type} et gagne {Salary}.");
        }
    }
}
