using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;

namespace TagHelpers.Tests
{
    internal class DefaultMetaDataHelperProvider : IDisplayMetadataProvider
    {
        private readonly string format;

        public DefaultMetaDataHelperProvider(string format)
        {
            this.format = format;
        }
        public void CreateDisplayMetadata(DisplayMetadataProviderContext context)
        {
            context.DisplayMetadata.DisplayFormatString = format;
        }
    }
}
