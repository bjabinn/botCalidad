// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.3.0

using Microsoft.Bot.Connector.Authentication;
using Microsoft.Extensions.Configuration;

namespace TescoFBot
{
    public class ConfigurationCredentialProvider : SimpleCredentialProvider
    {
        public ConfigurationCredentialProvider(IConfiguration configuration)
            : base(configuration["MicrosoftAppId"], configuration["MicrosoftAppPassword"])
        {
            configuration["MicrosoftAppId"] = "089d84da-7dda-4edd-90c3-d065696f0026";
            configuration["MicrosoftAppPassword"] = "cwNUU52~#(}ooldqLTFA549";
        }
    }
}
