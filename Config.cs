﻿namespace SendPentaNotification;

public static class Config
{
    public const string FirebaseAdmJson = @"{
          ""type"": ""service_account"",
          ""project_id"": ""your_project_id"",
          ""private_key_id"": ""your_private_key_id"",
          ""private_key"": ""private_key"",
          ""client_email"": ""client_email"",
          ""client_id"": ""client_id"",
          ""auth_uri"": ""auth_uri"",
          ""token_uri"": ""token_uri"",
          ""auth_provider_x509_cert_url"": ""auth_provider_x509_cert_url"",
          ""client_x509_cert_url"": ""client_x509_cert_url"",
          ""universe_domain"": ""googleapis.com""
        }";
}
