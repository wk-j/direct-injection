using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

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
        public void OnProvidersExecuting2(ApplicationModelProviderContext context) {
            var parameters = context.Result.Controllers
                .SelectMany(x => x.Actions)
                .SelectMany(x => x.Parameters)
                .Where(x => x.ParameterType.IsInterface);
            foreach (var item in parameters) {
                item.BindingInfo = new BindingInfo() {
                    BindingSource = BindingSource.Services
                };
            }
        }
        public void OnProvidersExecuting3(ApplicationModelProviderContext context) {
            var parameters =
                from controller in context.Result.Controllers
                from action in controller.Actions
                from parameter in action.Parameters
                where parameter.ParameterType.IsInterface
                select parameter;
            foreach (var item in parameters) {
                item.BindingInfo = new BindingInfo() {
                    BindingSource = BindingSource.Services
                };
            }
        }
    }
}