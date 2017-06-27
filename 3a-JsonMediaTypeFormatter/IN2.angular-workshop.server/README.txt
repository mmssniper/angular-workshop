****************START 3a - Json Media Type Formatter *******************************************************************************************

1) WebApiConfig ---> var jsonFormatter = config.Formatters.JsonFormatter;
2) promjena serijalizacije datuma: jsonFormatter.SerializerSettings.DateFormatHandling = Newtonsoft.Json.DateFormatHandling.MicrosoftDateFormat;
3) promjena razmaka: jsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
4) promjena u Camel Case serijalizaciju: jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
****************END 3a - Json Media Type Formatter *******************************************************************************************

