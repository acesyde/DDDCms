using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;

namespace DDDCms.Core.ModelBinder
{
    public class FieldDtoModelBinder : IModelBinder
    {
        private readonly ILogger<FieldDtoModelBinder> _logger;

        public FieldDtoModelBinder(ILogger<FieldDtoModelBinder> logger)
        {
            _logger = logger;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null) throw new ArgumentNullException(nameof(bindingContext));
            
            var modelName = bindingContext.ModelName;
            if (string.IsNullOrEmpty(modelName))
            {
                modelName = "model";
            }
            
            var valueProviderResult = bindingContext.ValueProvider.GetValue(modelName);
            if (valueProviderResult == ValueProviderResult.None)
            {
                return Task.CompletedTask;
            }

            _logger.LogInformation("Binding");
            return Task.CompletedTask;
        }
    }
}