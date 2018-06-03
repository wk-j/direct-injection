
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DirectInjection.Providers {
    public class ActionDependencyModelProvider : IApplicationModelProvider {
        public int Order => -901;

        public void OnProvidersExecuted(ApplicationModelProviderContext context) {
        }

        public void OnProvidersExecuting(ApplicationModelProviderContext context) {
            foreach (var controller in context.Result.Controllers) {
                foreach (var action in controller.Actions) {
                    foreach (var parameter in action.Parameters) {
                        if (parameter.ParameterType.IsInterface) {
                            parameter.BindingInfo = new BindingInfo() {
                                BindingSource = BindingSource.Services
                            };
                        }
                    }
                }
            }
        }
    }
}