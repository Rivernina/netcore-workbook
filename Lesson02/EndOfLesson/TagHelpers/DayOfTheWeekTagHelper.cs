using System;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers
{
    /// <summary>
    /// Renders <see cref="System.DateTime"/> as the day of the week if 
    /// the date is within 7 days from today. Otherwise, standard 
    /// datetime format is rendered.
    /// </summary>
    [HtmlTargetElement("*", Attributes = "day-of-the-week")]
    public class DayOfTheWeekTagHelper : TagHelper
    {
        /// <summary>
        /// An expression to be evaluated against the current model.
        /// </summary>
        [HtmlAttributeName("asp-for")]
        public ModelExpression For { get; set; }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var value = For.Model as DateTime?;
            var now = DateTime.Now;

            if (value >= now && Math.Abs((now - value).Value.Days) < 7)
            {
                output.Content.SetContent(value.Value.DayOfWeek.ToString());
            }
            else if(value < now && Math.Abs((now - value).Value.Days) < 7)
            {
                output.Content.SetContent($"Last {value.Value.DayOfWeek}");
            }
            else
            {
                output.Content.SetContent(string.Format(For.Metadata.DisplayFormatString ?? "{0}", value));
            }
        }
    }
}
