using System;
using System.Collections.Generic;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Internal;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelpers.Tests.Intrastructure
{
    public class BaseTagHelperTest
    {

        /// <summary>
        /// Pieced this together from aspnet/Mvc github. See remarks for link.
        /// </summary>
        /// <remarks>Reference: https://github.com/aspnet/Mvc/blob/67a1f2dda9bcb5795033b0c0ce775d931627fe17/test/Microsoft.AspNetCore.Mvc.TagHelpers.Test/LabelTagHelperTest.cs#L156</remarks>
        protected ModelExpression GetModelExpression(DateTime? instance, string format = null)
        {
            var providers = new List<IMetadataDetailsProvider>
            {
                new DefaultMetaDataHelperProvider(format)
            };
            var compositeDetailsProvider = new DefaultCompositeMetadataDetailsProvider(providers);
            var metadataProvider = new DefaultModelMetadataProvider(compositeDetailsProvider);
            var containerExplorer = metadataProvider.GetModelExplorerForType(typeof(DateTime?), instance);
            var modelExplorer = containerExplorer.GetExplorerForModel(instance);
            var modelExpression = new ModelExpression("", modelExplorer);
            return modelExpression;
        }

        /// <summary>
        /// Create a blank content so we can see how our tag helper renders content
        /// </summary>
        protected Task<TagHelperContent> BlankContent(bool useCachedResult, HtmlEncoder encoder)
        {
            var tagHelperContent = new DefaultTagHelperContent();
            tagHelperContent.SetContent(string.Empty);
            return Task.FromResult<TagHelperContent>(tagHelperContent);
        }
    }
}
