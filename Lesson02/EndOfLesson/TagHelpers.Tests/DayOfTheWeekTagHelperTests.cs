using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;
using TagHelpers.Tests.Intrastructure;
using Xunit;

namespace TagHelpers.Tests
{
    public class DayOfTheWeekTagHelperTests : BaseTagHelperTest
    {

        /// <summary>
        /// Simplified override of <see cref="Setup(DateTime?, Action{TagHelperContext, TagHelperOutput})"/> which set the tag to a span.
        /// </summary>
        private void Setup(DateTime? model, Action<TagHelperContext, TagHelperOutput> callback)
        {
            Setup("span", model, callback);
        }

        /// <summary>
        /// Common setup method use to initialize each test.
        /// </summary>
        /// <param name="tag">The tag the day of week tag helper attribute appears on.</param>
        /// <param name="model">The value of the tag helper model</param>
        /// <param name="callback">A callback that can be used to gain access to the dependencies we need for our tag helper tests</param>
        private void Setup(string tag, object model, Action<TagHelperContext, TagHelperOutput> callback)
        {
            TagHelperAttributeList attributes = new TagHelperAttributeList
            {
                new TagHelperAttribute("asp-for", model),
                new TagHelperAttribute("day-of-the-week")
            };
            TagHelperContext context = null;
            TagHelperOutput output = new TagHelperOutput(tag, attributes, BlankContent);
            callback(context, output);
        }

        [Fact]
        public void TagHelper_ShouldSetContentToDayOfWeekWhenWithin7DaysOfToday()
        {
            // Assemble
            DateTime value = DateTime.Now;
            var myTagHelper = new DayOfTheWeekTagHelper();
            myTagHelper.For = GetModelExpression(value);
            Setup(value, (context, output) =>
            {
                // Act
                myTagHelper.Process(context, output);

                // Assert
                Assert.Equal(value.DayOfWeek.ToString(), output.Content.GetContent());
            });
        }

        [Fact]
        public void TagHelper_ShouldSetContentToNothingWhenValueIsNotProvided()
        {
            // Assemble
            DateTime? value = null;
            var myTagHelper = new DayOfTheWeekTagHelper();
            myTagHelper.For = GetModelExpression(value);
            Setup(value, (context, output) =>
            {
                // Act
                myTagHelper.Process(context, output);

                // Assert
                Assert.Equal("", output.Content.GetContent());
            });
        }

        [Fact]
        public void TagHelper_ShouldSetContentToDateWhenWithin7DaysOfToday()
        {
            // Assemble
            DateTime value = DateTime.Now.AddDays(8);
            var myTagHelper = new DayOfTheWeekTagHelper();
            myTagHelper.For = GetModelExpression(value);
            Setup(value, (context, output) =>
            {
                // Act
                myTagHelper.Process(context, output);

                // Assert
                Assert.Equal(value.ToString(), output.Content.GetContent());
            });
        }

        [Fact]
        public void TagHelper_ShouldSetContentToDateAndRespectFormat()
        {
            // Assemble
            DateTime value = DateTime.Now.AddDays(8);
            var myTagHelper = new DayOfTheWeekTagHelper();
            myTagHelper.For = GetModelExpression(value, "{0:yyyy}");
            Setup(value, (context, output) =>
            {
                // Act
                myTagHelper.Process(context, output);

                // Assert
                Assert.Equal(value.ToString("yyyy"), output.Content.GetContent());
            });
        }
    }
}
