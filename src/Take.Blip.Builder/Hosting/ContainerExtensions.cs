﻿using Lime.Messaging;
using Lime.Protocol.Serialization;
using Lime.Protocol.Serialization.Newtonsoft;
using Serilog;
using Serilog.Core;
using SimpleInjector;
using Take.Blip.Builder.Actions;
using Take.Blip.Builder.Actions.ExecuteScript;
using Take.Blip.Builder.Actions.ForwardMessageToDesk;
using Take.Blip.Builder.Actions.ManageList;
using Take.Blip.Builder.Actions.MergeContact;
using Take.Blip.Builder.Actions.ProcessCommand;
using Take.Blip.Builder.Actions.ProcessHttp;
using Take.Blip.Builder.Actions.Redirect;
using Take.Blip.Builder.Actions.SendCommand;
using Take.Blip.Builder.Actions.SendMessage;
using Take.Blip.Builder.Actions.SendMessageFromHttp;
using Take.Blip.Builder.Actions.SendRawMessage;
using Take.Blip.Builder.Actions.SetBucket;
using Take.Blip.Builder.Actions.SetVariable;
using Take.Blip.Builder.Actions.TrackEvent;
using Take.Blip.Builder.Diagnostics;
using Take.Blip.Builder.Storage;
using Take.Blip.Builder.Storage.Memory;
using Take.Blip.Builder.Utils;
using Take.Blip.Builder.Variables;
using Take.Blip.Client;
using Take.Blip.Client.Extensions;

namespace Take.Blip.Builder.Hosting
{
    public static class ContainerExtensions
    {
        public static Container RegisterBuilder(this Container container)
        {
            container.RegisterSingleton<IFlowManager, FlowManager>();
            container.RegisterSingleton<IStateManager, StateManager>();
            container.RegisterSingleton<IContextProvider, ExtensionContextProvider>();
            container.RegisterSingleton<INamedSemaphore, MemoryNamedSemaphore>();
            container.RegisterSingleton<IActionProvider, ActionProvider>();
            container.RegisterSingleton<IDocumentSerializer, DocumentSerializer>();
            container.RegisterSingleton<IEnvelopeSerializer, EnvelopeSerializer>();
            container.RegisterSingleton<IConfiguration, ConventionsConfiguration>();
            container.RegisterSingleton<IVariableReplacer, VariableReplacer>();
            container.RegisterSingleton<IHttpClient, HttpClientWrapper>();
            container.RegisterSingleton<ILogger>(LoggerProvider.Logger);
            container.RegisterSingleton<IDocumentTypeResolver>(new DocumentTypeResolver().WithBlipDocuments());
            container.RegisterSingleton<ITraceProcessor, TraceProcessor>();

            container.RegisterCollection<IAction>(
                new[]
                {
                    typeof(ExecuteScriptAction),
                    typeof(SendMessageAction),
                    typeof(SendMessageFromHttpAction),
                    typeof(SendRawMessageAction),
                    typeof(SendCommandAction),
                    typeof(ProcessCommandAction),
                    typeof(TrackEventAction),
                    typeof(ProcessHttpAction),
                    typeof(ManageListAction),
                    typeof(MergeContactAction),
                    typeof(SetVariableAction),
                    typeof(SetBucketAction),
                    typeof(RedirectAction),
                    typeof(ForwardMessageToDeskAction),
                });
            container.RegisterCollection<IVariableProvider>(
                new[]
                {
                    typeof(BucketVariableProvider),
                    typeof(CalendarVariableProvider),
                    typeof(ContactVariableProvider),
                    typeof(ExtensionContextVariableProvider),
                    typeof(RandomVariableProvider),
                    typeof(FlowConfigurationVariableProvider),
                    typeof(InputVariableProvider),
                    typeof(StateVariableProvider),
                });

            return container;
        }
    }
}