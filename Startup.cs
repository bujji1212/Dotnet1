using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Google.Cloud.Dialogflow.V2;
using Google.Protobuf;
using System.IO;


namespace fulfillment
{
             public class Startup
    {
           // A Protobuf JSON parser configured to ignore unknown fields. This makes             // the action robust against new fields being introduced by Dialogflow.
            private static readonly JsonParser jsonParser =
                new JsonParser(JsonParser.Settings.Default.WithIgnoreUnknownFields(true));

         


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
                 if (env.IsDevelopment())
                 {
                     app.UseDeveloperExceptionPage();
                 }

            app.Run(async (context) =>
             {
               //  WebhookRequest request;
               //  string json;
                 /*   using (StreamReader reader = new StreamReader(context.Request.Body))
                    {

                        json = reader.ReadToEnd();
                        request = jsonParser.Parse<WebhookRequest>(json);

                    } */

                 var response = new WebhookResponse
                 {
                     FulfillmentText = "Hello from Csharp"  //request.QueryResult.Intent.DisplayName
                 };

                 await context.Response.WriteAsync((response.ToString()));
             });

           


        }
    }




}
