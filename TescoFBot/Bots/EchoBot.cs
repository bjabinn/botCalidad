// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with Bot Builder V4 SDK Template for Visual Studio EchoBot v4.3.0

using System.Collections.Generic;
using JSONUtils;
using System;
using Newtonsoft;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Integration.AspNet.Core;
using Microsoft.Bot.Schema;
using System.Threading;
using Microsoft.Bot.Configuration;
using Newtonsoft.Json;
using System.Web;
using System.Net.Http;

namespace TescoFBot.Bots
{
    public class EchoBot : ActivityHandler
    {
        public const string Greeting = "Greeting";
        public const string ActualizarPPM = "ActualizarPPM";
        public const string CambiarChecklist = "CambiarChecklist";
        public const string CancelarReunion = "CancelarReunion";
        public const string CerrarRiesgo = "CerrarRiesgo";
        public const string EncontrarPPQA = "EncontrarPPQA";
        public const string PlanContinuidad = "PlanContinuidad";
        public const string ProbarFenix = "ProbarFenix";
        public const string SeguimientoRiesgo = "SeguimientoRiesgo";
        public const string SignificadoNC = "SignificadoNC";
        public const string None = "None";


        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            var client = new HttpClient();
            var endpointUri = "https://westeurope.api.cognitive.microsoft.com/luis/v2.0/apps/1ab8cedf-6602-4c4c-8236-ab5424e70186?verbose=true&timezoneOffset=60&subscription-key=66e3e38b31d643a395986edbaf858336&q=" + turnContext.Activity.Text;
            var response = await client.GetAsync(endpointUri);
            var strResponseContent = await response.Content.ReadAsStringAsync();

            var topScoringIntent = JsonConvert.DeserializeObject<RootObject>(strResponseContent);

            var topIntent = topScoringIntent.intents[0].intent;
                switch (topIntent)
                {
                    case Greeting:
                        await turnContext.SendActivityAsync(MessageFactory.Text("Greetings, human."), cancellationToken);
                        break;
                    case ActualizarPPM:
                        await turnContext.SendActivityAsync(MessageFactory.Text("Cada vez que se termine una fase del desarrollo, tiene que existir un registro por cada fase, no es válido hacerlo todo el mismo día,ya que todo no se acaba a la vez."), cancellationToken);
                        break;
                    case CambiarChecklist:
                        await turnContext.SendActivityAsync(MessageFactory.Text("Si tanto el de entrada como el de salida, para ello definir cuales son las preguntas que os resultan útilies en vuestro proyecto y en vuestras peticiones, revisa la página donde se detalla la información que vamos a necesitar, y las preguntas que son obligatorias según la petición (https://steps.everis.com/confluence/pages/viewpage.action?pageId=1024131967) manda todo al buzon Calidad.Centers.Sevilla@everis.com, nosotros lo revisamos y nos encargamos de abrir el jira para su aprobación y subida a Fenix."), cancellationToken);
                        break;
                    case CancelarReunion:
                        await turnContext.SendActivityAsync(MessageFactory.Text("En esta página puedes encontrar la forma de realizar la cancelación https://steps.everis.com/confluence/pages/viewpage.action?pageId=1139813988, de reuniones operativas o ejecutivas."), cancellationToken);
                        break;
                    case CerrarRiesgo:
                        await turnContext.SendActivityAsync(MessageFactory.Text("Lo primero has un seguimiento, cuentanos que ha pasado cual es el motivo por el que se cierra, entonces puedes cerrarlo."), cancellationToken);
                        break;
                    case EncontrarPPQA:
                        await turnContext.SendActivityAsync(MessageFactory.Text("Los PPQA de todos los proyectos se encuentran alojados en una página de Confluence del Centro https://steps.everis.com/confluence/pages/viewpage.action?spaceKey=LTNET&title=PPQAs"), cancellationToken);
                        break;
                    case PlanContinuidad:
                        await turnContext.SendActivityAsync(MessageFactory.Text("Todos los servicios que son AM tienen que realizar el plan de continuidad, independientemente que tengan o no ANS"), cancellationToken);
                        break;
                    case ProbarFenix:
                        await turnContext.SendActivityAsync(MessageFactory.Text("Si, existe un entorno de preproducción y formación, en la siguiente página puedes encontrar todo el detalle https://steps.everis.com/confluence/pages/viewpage.action?pageId=951977713"), cancellationToken);
                        break;
                    case SeguimientoRiesgo:
                        await turnContext.SendActivityAsync(MessageFactory.Text("Todos los meses cuando el riesgo se encuentra en estado evalueado o en progreso, como fecha máxima el 27 de cada mes."), cancellationToken);
                        break;
                    case SignificadoNC:
                        await turnContext.SendActivityAsync(MessageFactory.Text("En todos los proyectos en su PPQA se reflejan donde se dejará documentado las buenas prácticas y lecciones aprendidas, verifica que la ruta del documento coincide donde se documenta habitualmente, comprueba que se está haciendo, es decir se esta actualizando o creando dicha documentación al menos cada 2 meses."), cancellationToken);
                        break;
                    case None:
                    default:
                        await turnContext.SendActivityAsync(MessageFactory.Text("No entendí eso."), cancellationToken);
                        break;
                }
            
        }


        

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    await turnContext.SendActivityAsync(MessageFactory.Text($"Hello and Welcome!"), cancellationToken);
                }
            }
        }
    }
}
